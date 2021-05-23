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
    public partial class MainForm : Form
    {
        private SqlConnection sqlConnection;

        public MainForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var loginChoiseForm = new LoginChoiseForm();
            loginChoiseForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string connectionString =
                @"Data Source=DESKTOP-RLVLN9U;Initial Catalog=HomeKitchenAssistDb;Integrated Security=True";
        }
    }
}
