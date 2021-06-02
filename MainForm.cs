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
        //internal bool isUserExists;

        public MainForm()
        {
            InitializeComponent();
        }

        internal void UpdateTabControl()
        {
            tabControl1.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["HomeKitchenAssistantDb"].ConnectionString);

            sqlConnection.Open();
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
    }
}
