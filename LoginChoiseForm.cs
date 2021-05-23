﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeKitchenAssistant
{
    public partial class LoginChoiseForm : Form
    {
        public LoginChoiseForm()
        {
            InitializeComponent();
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
