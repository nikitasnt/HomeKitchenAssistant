﻿using System;
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
    public partial class LoginChoiseForm : Form
    {
        private MainForm mainForm;

        public LoginChoiseForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm(mainForm, this);
            registrationForm.ShowDialog();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(mainForm, this);
            loginForm.ShowDialog();
        }
    }
}
