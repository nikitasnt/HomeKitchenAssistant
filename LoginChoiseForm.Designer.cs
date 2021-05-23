
namespace HomeKitchenAssistant
{
    partial class LoginChoiseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginButton = new System.Windows.Forms.Button();
            this.registrationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(64, 21);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(148, 51);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Войти в существующий аккаунт";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // registrationButton
            // 
            this.registrationButton.Location = new System.Drawing.Point(85, 79);
            this.registrationButton.Name = "registrationButton";
            this.registrationButton.Size = new System.Drawing.Size(110, 39);
            this.registrationButton.TabIndex = 1;
            this.registrationButton.Text = "Создать новый аккаунт";
            this.registrationButton.UseVisualStyleBackColor = true;
            // 
            // LoginChoiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.ControlBox = false;
            this.Controls.Add(this.registrationButton);
            this.Controls.Add(this.loginButton);
            this.MaximumSize = new System.Drawing.Size(300, 180);
            this.MinimumSize = new System.Drawing.Size(300, 180);
            this.Name = "LoginChoiseForm";
            this.Text = "Войти или зарегистрироваться";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button registrationButton;
    }
}