using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeKitchenAssistant
{
    public partial class MainForm : Form
    {
        internal SqlConnection sqlConnection;

        internal string currentUserLogin;
        internal string currentUserName;

        private int userId;
        private bool isUserBelongToFamily;
        private int familyId;
        private List<string> currentUserProducts;
        private List<string> currentFamilyProducts;

        public MainForm()
        {
            InitializeComponent();
            currentUserProducts = new List<string>();
            currentFamilyProducts = new List<string>();
        }

        // Update information in Product page
        private void UpdateProductPage()
        {
            if (!isUserBelongToFamily)
            {
                currentUserProducts.Clear();
            }
            else
            {
                currentFamilyProducts.Clear();
            }
            productsListBox.Items.Clear();

            var userProducts = new List<string>();

            string sqlExpression;
            if (!isUserBelongToFamily)
            {
                sqlExpression = $"SELECT Products.ProductName, UsersHaveProducts.Amount, Units.UnitName " +
                                $"FROM Products, UsersHaveProducts, Units " +
                                $"WHERE UsersHaveProducts.ProductId = Products.ProductId " +
                                $"AND Products.UnitId = Units.UnitId " +
                                $"AND UserId = {userId}";
            }
            else
            {
                sqlExpression = $"SELECT Products.ProductName, FamiliesHaveProducts.Amount, Units.UnitName " +
                                $"FROM Products, FamiliesHaveProducts, Units " +
                                $"WHERE FamiliesHaveProducts.ProductId = Products.ProductId " +
                                $"AND Products.UnitId = Units.UnitId " +
                                $"AND FamilyId = {familyId}";
            }
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);

            SqlDataReader reader = null;
            try
            {
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!isUserBelongToFamily)
                        {
                            currentUserProducts.Add(reader.GetString(0));
                        }
                        else
                        {
                            currentFamilyProducts.Add(reader.GetString(0));
                        }
                        userProducts.Add($"{reader.GetString(0)} - " +
                                         $"{Convert.ToString(reader.GetInt32(1))} {reader.GetString(2)};");
                    }
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }

            productsListBox.Items.AddRange(userProducts.ToArray());
        }
        
        // Update information in Recipe page
        private void UpdateRecipePage()
        {
            cookButton.Enabled = false;
            
            recipesListBox.Items.Clear();
            recipeDescriptionTextBox.Clear();
            productsInRecipeListBox.Items.Clear();

            var userFamilyRecipes = new List<string>();

            string sqlExpression;
            if (!isUserBelongToFamily)
            {
                sqlExpression = $"SELECT RecipeName FROM Recipes " +
                                $"WHERE " +
                                $"( " +
                                $"SELECT COUNT(*) FROM RecipesIncludeProducts " +
                                $"WHERE Recipes.RecipeId = RecipeId " +
                                $") " +
                                $"= " +
                                $"( " +
                                $"SELECT COUNT(*) FROM RecipesIncludeProducts " +
                                $"WHERE Amount <= " +
                                $"( " +
                                $"SELECT Amount FROM UsersHaveProducts " +
                                $"WHERE ProductId = RecipesIncludeProducts.ProductId AND UserId = {userId} " +
                                $") " +
                                $") ";
            }
            else
            {
                sqlExpression = $"SELECT RecipeName FROM Recipes " +
                                $"WHERE " +
                                $"( " +
                                $"SELECT COUNT(*) FROM RecipesIncludeProducts " +
                                $"WHERE Recipes.RecipeId = RecipeId " +
                                $") " +
                                $"= " +
                                $"( " +
                                $"SELECT COUNT(*) FROM RecipesIncludeProducts " +
                                $"WHERE Amount <= " +
                                $"( " +
                                $"SELECT Amount FROM FamiliesHaveProducts " +
                                $"WHERE ProductId = RecipesIncludeProducts.ProductId AND FamilyId = {familyId} " +
                                $") " +
                                $")";
            }
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
            SqlDataReader reader = null;
            try
            {
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userFamilyRecipes.Add(reader.GetString(0));
                    }
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }

            recipesListBox.Items.AddRange(userFamilyRecipes.ToArray());
        }

        private void UpdateFamilyPage()
        {
            // Is user belong to family
            string sqlExpression = $"SELECT FamilyId FROM UsersBelongToFamilies " +
                                   $"WHERE UserId = {userId}";
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
            try
            {
                familyId = Convert.ToInt32(sqlCommand.ExecuteScalar());
                isUserBelongToFamily = Convert.ToBoolean(familyId);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
            }
            
            // Family list
            usersInFamilyListBox.Items.Clear();
            
            if (isUserBelongToFamily)
            {
                string sqlExpressionList = $"SELECT UserLogin, UserName FROM Users " +
                                           $"WHERE UserId IN " +
                                           $"(SELECT UserId FROM UsersBelongToFamilies " +
                                           $"WHERE FamilyId = {familyId})";
                SqlCommand sqlCommandList = new SqlCommand(sqlExpressionList, sqlConnection);
                SqlDataReader reader = null;
                try
                {
                    reader = sqlCommandList.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usersInFamilyListBox.Items.Add($"{reader.GetString(0)} ({reader.GetString(1)})");
                        }
                    }
                }
                catch (SqlException sqlException)
                {
                    Console.WriteLine(sqlException);
                }
                finally
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
                
                // Enable other textBox and buttons
                addUserTextBox.Enabled = true;
                addUserButton.Enabled = true;
                leaveFromFamilyButton.Enabled = true;
                createFamilyButton.Enabled = false;
            }
            else
            {
                usersInFamilyListBox.Items.Add("Вы не состоите в семье");
                
                // Disable other textBox and buttons
                addUserTextBox.Enabled = false;
                addUserButton.Enabled = false;
                leaveFromFamilyButton.Enabled = false;
                createFamilyButton.Enabled = true;
            }
        }

        // Full update information in tabPages in tabControl
        internal void UpdateTabControl()
        {
            // Set user ID
            string sqlExpression = $"SELECT UserId FROM Users WHERE UserLogin = '{currentUserLogin}'";
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
            try
            {
                userId = Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
            }
            
            // Update all pages
            tabControl1.Enabled = true;
            UpdateFamilyPage();
            UpdateProductPage();
            UpdateRecipePage();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Connection to DB

            sqlConnection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["HomeKitchenAssistantDb"].ConnectionString);

            sqlConnection.Open();

            // Getting list of all product names from DB for domainUpDown

            var allProductNamesFromDb = new AutoCompleteStringCollection();

            string sqlExpression = $"SELECT ProductName FROM Products";
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);

            SqlDataReader reader = null;
            try
            {
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        allProductNamesFromDb.Add(reader.GetString(0));
                    }
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }

            productNameTextBox.AutoCompleteCustomSource = allProductNamesFromDb;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var loginChoiseForm = new LoginChoiseForm(this);
            loginChoiseForm.ShowDialog();
        }

        private void productsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productsListBox.SelectedItem != null)
            {
                string productName = productsListBox.SelectedItem.ToString();
            
                // Gey only name without amount
                productNameTextBox.Text = productName.Substring(0, productName.IndexOf('-') - 1);
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            string addedProductName = productNameTextBox.Text;
            
            if (!isUserBelongToFamily)
            {
                // If user have added product
                if (currentUserProducts.Contains(addedProductName))
                {
                    string sqlExpression = $"UPDATE UsersHaveProducts " +
                                           $"SET Amount = Amount + {Convert.ToInt32(amountNumericUpDown.Text)} " +
                                           $"WHERE UserId = {userId} AND " +
                                           $"ProductId = (SELECT ProductId FROM Products " +
                                           $"WHERE ProductName = '{addedProductName}')";
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException sqlException)
                    {
                        Console.WriteLine(sqlException);
                    }

                    UpdateTabControl();
                }
                else
                {
                    string sqlExpression = $"INSERT INTO UsersHaveProducts(UserId, ProductId, Amount) VALUES " +
                                           $"({userId}, " +
                                           $"(SELECT ProductId FROM Products " +
                                           $"WHERE ProductName = '{addedProductName}'), " +
                                           $"{Convert.ToInt32(amountNumericUpDown.Text)})";
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                    try
                    {
                        Console.WriteLine(sqlCommand.ExecuteNonQuery());
                    }
                    catch (SqlException sqlException)
                    {
                        Console.WriteLine(sqlException);
                        MessageBox.Show("Несуществующее название продукта");
                    }

                    UpdateTabControl();
                }
            }
            else
            {
                // If family have added product
                if (currentFamilyProducts.Contains(addedProductName))
                {
                    string sqlExpression = $"UPDATE FamiliesHaveProducts " +
                                           $"SET Amount = Amount + {Convert.ToInt32(amountNumericUpDown.Text)} " +
                                           $"WHERE FamilyId = {familyId} AND " +
                                           $"ProductId = (SELECT ProductId FROM Products " +
                                           $"WHERE ProductName = '{addedProductName}')";
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException sqlException)
                    {
                        Console.WriteLine(sqlException);
                    }

                    UpdateTabControl();
                }
                else
                {
                    string sqlExpression = $"INSERT INTO FamiliesHaveProducts(FamilyId, ProductId, Amount) VALUES " +
                                           $"({familyId}, " +
                                           $"(SELECT ProductId FROM Products " +
                                           $"WHERE ProductName = '{addedProductName}'), " +
                                           $"{Convert.ToInt32(amountNumericUpDown.Text)})";
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                    try
                    {
                        Console.WriteLine(sqlCommand.ExecuteNonQuery());
                    }
                    catch (SqlException sqlException)
                    {
                        Console.WriteLine(sqlException);
                        MessageBox.Show("Несуществующее название продукта");
                    }

                    UpdateTabControl();
                }
            }
        }

        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            string deletedProductName = productNameTextBox.Text;

            if (!isUserBelongToFamily)
            {
                // If user have deleted product
                if (currentUserProducts.Contains(deletedProductName))
                {
                    string sqlExpression = $"UPDATE UsersHaveProducts " +
                                           $"SET Amount = Amount - {Convert.ToInt32(amountNumericUpDown.Text)} " +
                                           $"WHERE UserId = {userId} AND " +
                                           $"ProductId = (SELECT ProductId FROM Products " +
                                           $"WHERE ProductName = '{deletedProductName}')";
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException sqlException)
                    {
                        Console.WriteLine(sqlException);
                    }

                    UpdateTabControl();
                }
                else
                {
                    MessageBox.Show("У вас нет такого продукта");
                }
            }
            else
            {
                // If family have deleted product
                if (currentFamilyProducts.Contains(deletedProductName))
                {
                    string sqlExpression = $"UPDATE FamiliesHaveProducts " +
                                           $"SET Amount = Amount - {Convert.ToInt32(amountNumericUpDown.Text)} " +
                                           $"WHERE FamilyId = {familyId} AND " +
                                           $"ProductId = (SELECT ProductId FROM Products " +
                                           $"WHERE ProductName = '{deletedProductName}')";
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException sqlException)
                    {
                        Console.WriteLine(sqlException);
                    }

                    UpdateTabControl();
                }
                else
                {
                    MessageBox.Show("У вас нет такого продукта");
                }
            }
        }

        private void recipesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (recipesListBox.SelectedItem != null)
            {
                // Show description
                string sqlExpressionForDescription = $"SELECT RecipeDescription FROM Recipes " +
                                                     $"WHERE RecipeName = " +
                                                     $"'{Convert.ToString(recipesListBox.SelectedItem)}'";
                SqlCommand sqlCommandForDescription = new SqlCommand(sqlExpressionForDescription, sqlConnection);
                try
                {
                    recipeDescriptionTextBox.Text = Convert.ToString(sqlCommandForDescription.ExecuteScalar());
                }
                catch (SqlException sqlException)
                {
                    Console.WriteLine(sqlException);
                }
                
                // Show products in recipe
                productsInRecipeListBox.Items.Clear();
                    
                var recipeProducts = new List<string>();
                
                string sqlExpressionForProducts =
                    $"SELECT Products.ProductName, RecipesIncludeProducts.Amount, Units.UnitName " +
                    $"FROM Products, RecipesIncludeProducts, Units " +
                    $"WHERE RecipesIncludeProducts.ProductId = Products.ProductId " +
                    $"AND Products.UnitId = Units.UnitId " +
                    $"AND RecipeId = " +
                    $"(SELECT RecipeId FROM Recipes WHERE RecipeName = '{recipesListBox.SelectedItem}')";
                SqlCommand sqlCommand = new SqlCommand(sqlExpressionForProducts, sqlConnection);
                SqlDataReader reader = null;
                try
                {
                    reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //currentUserProducts.Add(reader.GetString(0));
                            recipeProducts.Add($"{reader.GetString(0)} - " +
                                               $"{Convert.ToString(reader.GetInt32(1))} {reader.GetString(2)};");
                        }
                    }
                }
                catch (SqlException sqlException)
                {
                    Console.WriteLine(sqlException);
                }
                finally
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
                productsInRecipeListBox.Items.AddRange(recipeProducts.ToArray());
                
                // Enable cook button
                cookButton.Enabled = true;
            }
        }

        private void cookButton_Click(object sender, EventArgs e)
        {
            string sqlExpression;
            if (!isUserBelongToFamily)
            {
                sqlExpression = $"UPDATE UsersHaveProducts " +
                                $"SET Amount = Amount - " +
                                $"( " +
                                $"SELECT Amount FROM RecipesIncludeProducts " +
                                $"WHERE RecipeId = " +
                                $"(SELECT RecipeId FROM Recipes " +
                                $"WHERE RecipeName = '{recipesListBox.SelectedItem}') " +
                                $"AND RecipesIncludeProducts.ProductId = UsersHaveProducts.ProductId " +
                                $") " +
                                $"WHERE UserId = {userId}";
            }
            else
            {
                sqlExpression = $"UPDATE FamiliesHaveProducts " +
                                $"SET Amount = Amount - " +
                                $"( " +
                                $"SELECT Amount FROM RecipesIncludeProducts " +
                                $"WHERE RecipeId = " +
                                $"(SELECT RecipeId FROM Recipes " +
                                $"WHERE RecipeName = '{recipesListBox.SelectedItem}') " +
                                $"AND RecipesIncludeProducts.ProductId = FamiliesHaveProducts.ProductId " +
                                $") " +
                                $"WHERE FamilyId = {familyId}";
            }
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
            }
            UpdateTabControl();
        }

        private void createFamilyButton_Click(object sender, EventArgs e)
        {
            // Create family and get ID
            string sqlExpressionCreate = $"INSERT INTO Families DEFAULT VALUES " +
                                         $"SELECT SCOPE_IDENTITY()";
            SqlCommand sqlCommandCreate = new SqlCommand(sqlExpressionCreate, sqlConnection);
            try
            {
                familyId = Convert.ToInt32(sqlCommandCreate.ExecuteScalar());
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
            }
            
            // Add current user to created family
            string sqlExpressionAdd = $"INSERT INTO UsersBelongToFamilies(UserId, FamilyId) " +
                                      $"VALUES ({userId}, {familyId})";
            SqlCommand sqlCommandAdd = new SqlCommand(sqlExpressionAdd, sqlConnection);
            try
            {
                sqlCommandAdd.ExecuteNonQuery();
                
                isUserBelongToFamily = true;

                UpdateTabControl();
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
            }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            // // Is added user belong to family
            // string sqlExpressionInFamily = $"SELECT FamilyId FROM UsersBelongToFamilies " +
            //                                $"WHERE UserId = {userId}";
            // SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
            // try
            // {
            //     familyId = Convert.ToInt32(sqlCommand.ExecuteScalar());
            //     isUserBelongToFamily = Convert.ToBoolean(familyId);
            // }
            // catch (SqlException sqlException)
            // {
            //     Console.WriteLine(sqlException);
            // }
            
            string sqlExpression = $"INSERT INTO UsersBelongToFamilies(UserId, FamilyId) " +
                                   $"VALUES " +
                                   $"((SELECT UserId FROM Users " +
                                   $"WHERE UserLogin = '{addUserTextBox.Text}'), " +
                                   $"{familyId})";
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                MessageBox.Show("Пользователь с таким логином не найден или уже состоит в семье");
            }
            UpdateFamilyPage();
        }

        private void leaveFromFamilyButton_Click(object sender, EventArgs e)
        {
            string sqlExpression = $"DELETE UsersBelongToFamilies " +
                                   $"WHERE UserId = {userId}";
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
            }
            UpdateTabControl();
        }
    }
}
