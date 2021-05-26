
namespace HomeKitchenAssistant
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.loginChoiseButton = new System.Windows.Forms.Button();
            this.currentUserHeaderLabel = new System.Windows.Forms.Label();
            this.currentUserLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginChoiseButton
            // 
            this.loginChoiseButton.Location = new System.Drawing.Point(609, 369);
            this.loginChoiseButton.Name = "loginChoiseButton";
            this.loginChoiseButton.Size = new System.Drawing.Size(113, 30);
            this.loginChoiseButton.TabIndex = 0;
            this.loginChoiseButton.Text = "Войти в аккаунт";
            this.loginChoiseButton.UseVisualStyleBackColor = true;
            this.loginChoiseButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // currentUserHeaderLabel
            // 
            this.currentUserHeaderLabel.AutoSize = true;
            this.currentUserHeaderLabel.Location = new System.Drawing.Point(12, 369);
            this.currentUserHeaderLabel.Name = "currentUserHeaderLabel";
            this.currentUserHeaderLabel.Size = new System.Drawing.Size(129, 13);
            this.currentUserHeaderLabel.TabIndex = 1;
            this.currentUserHeaderLabel.Text = "Текущий пользователь:";
            // 
            // currentUserLabel
            // 
            this.currentUserLabel.AutoSize = true;
            this.currentUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentUserLabel.Location = new System.Drawing.Point(12, 389);
            this.currentUserLabel.Name = "currentUserLabel";
            this.currentUserLabel.Size = new System.Drawing.Size(11, 13);
            this.currentUserLabel.TabIndex = 2;
            this.currentUserLabel.Text = "-";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.currentUserLabel);
            this.Controls.Add(this.currentUserHeaderLabel);
            this.Controls.Add(this.loginChoiseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Домашний кухонный помощник";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label currentUserHeaderLabel;
        internal System.Windows.Forms.Label currentUserLabel;
        internal System.Windows.Forms.Button loginChoiseButton;
    }
}

