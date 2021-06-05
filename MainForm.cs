﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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

        private List<string> currentUserProducts;
        //internal bool isUserExists;

        public MainForm()
        {
            InitializeComponent();
            currentUserProducts = new List<string>();
        }

        // Update information in Product page
        private void UpdateProductPage()
        {
            currentUserProducts.Clear();
            productsListBox.Items.Clear();

            var userProducts = new List<string>();

            // string sqlExpression = $"SELECT ProductName FROM Products " +
            //                        $"WHERE ProductId IN " +
            //                        $"(" +
            //                        $"SELECT ProductId FROM UsersHaveProducts " +
            //                        $"WHERE UserId = {userId}" +
            //                        $")";
            string sqlExpression = $"SELECT Products.ProductName, UsersHaveProducts.Amount, Units.UnitName " +
                                   $"FROM Products, UsersHaveProducts, Units " +
                                   $"WHERE UsersHaveProducts.ProductId = Products.ProductId " +
                                   $"AND Products.UnitId = Units.UnitId " +
                                   $"AND UserId = {userId}";
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);

            SqlDataReader reader = null;
            try
            {
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        currentUserProducts.Add(reader.GetString(0));
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
            recipesListBox.Items.Clear();

            var userRecipes = new List<string>();
            
            string sqlExpression = $"SELECT RecipeName FROM Recipes " +
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
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
            SqlDataReader reader = null;
            try
            {
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userRecipes.Add(reader.GetString(0));
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

            recipesListBox.Items.AddRange(userRecipes.ToArray());
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

        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            string deletedProductName = productNameTextBox.Text;

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
                UpdateProductPage();
            }
            else
            {
                MessageBox.Show("У вас нет такого продукта");
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
                            currentUserProducts.Add(reader.GetString(0));
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
            }
        }
    }
}
