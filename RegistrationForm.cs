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
    public partial class RegistrationForm : Form
    {
        private MainForm mainForm;
        private LoginChoiseForm loginChoiseForm;

        public RegistrationForm(MainForm mainForm, LoginChoiseForm loginChoiseForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.loginChoiseForm = loginChoiseForm;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string userName = nameTextBox.Text;
            string userLogin = loginTextBox.Text;
            string userPassword = passwordTextBox.Text;

            string sqlExpression = $"INSERT INTO Users VALUES ('{userName}', '{userLogin}', '{userPassword}')";
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, mainForm.sqlConnection);

            bool isUserWasAdded = false;
            try
            {
                isUserWasAdded = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
            }
            finally
            {
                if (isUserWasAdded)
                {
                    //MessageBox.Show("Вы успешно зарегистрированы!");
                    this.Close();
                    loginChoiseForm.Close();

                    mainForm.currentUserLogin = userLogin;
                    mainForm.currentUserName = userName;
                    mainForm.currentUserLabel.Text = $"{userLogin} ({userName})";
                    mainForm.loginChoiseButton.Enabled = false;
                    mainForm.UpdateTabControl();
                }
                else
                {
                    MessageBox.Show("Введены некорректные данные, либо пользователь с таким логином уже существует");
                }
            }
        }
    }
}
