using System;
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
        //internal bool isUserExists;

        public MainForm()
        {
            InitializeComponent();
        }

        // Update information in Product page
        private void UpdateProductPage()
        {
            productsListBox.Items.Clear();

            var userProducts = new List<string>();

            string sqlExpression = $"SELECT ProductName FROM Products " +
                                   $"WHERE ProductId IN " +
                                   $"(" +
                                   $"SELECT ProductId FROM UsersHaveProducts " +
                                   $"WHERE UserId = {userId}" +
                                   $")";
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);

            SqlDataReader reader = null;
            try
            {
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userProducts.Add(reader.GetString(0));
                    }
                }

                //userProducts.Sort();
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
            productNameTextBox.Text = productsListBox.SelectedItem.ToString();
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            string addedProductName = productNameTextBox.Text;
            
            // If user have added product
            if (productsListBox.Items.Contains(addedProductName))
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
                UpdateProductPage();
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
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlException)
                {
                    Console.WriteLine(sqlException);
                    MessageBox.Show("Неправильное название продукта");
                }
                UpdateProductPage();
            }
        }
    }
}
