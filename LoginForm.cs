using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeKitchenAssistant
{
    public partial class LoginForm : Form
    {
        private MainForm mainForm;
        private LoginChoiseForm loginChoiseForm;

        public LoginForm(MainForm mainForm, LoginChoiseForm loginChoiseForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.loginChoiseForm = loginChoiseForm;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userLogin = loginTextBox.Text;
            string userPassword = passwordTextBox.Text;

            string sqlExpression = $"SELECT UserName, UserPassword FROM Users WHERE UserLogin = '{userLogin}'";
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, mainForm.sqlConnection);

            string password;
            SqlDataReader reader = null;
            try
            {
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    password = reader.GetString(1);

                    if (password == userPassword)
                    {
                        //MessageBox.Show("Вы успешно вошли в аккаунт!");
                        this.Close();
                        loginChoiseForm.Close();

                        mainForm.currentUserLogin = userLogin;
                        mainForm.currentUserName = reader.GetString(0);
                        mainForm.currentUserLabel.Text = $"{userLogin} ({reader.GetString(0)})";
                        mainForm.loginChoiseButton.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Введены некорректные данные, либо неверные логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Введены некорректные данные, либо неверные логин или пароль");
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
            mainForm.UpdateTabControl();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
