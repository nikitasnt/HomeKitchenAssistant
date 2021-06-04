
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.loginChoiseButton = new System.Windows.Forms.Button();
            this.currentUserHeaderLabel = new System.Windows.Forms.Label();
            this.currentUserLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.amountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.productAmountLabel = new System.Windows.Forms.Label();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.deleteProductButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.productsListBox = new System.Windows.Forms.ListBox();
            this.productListLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.amountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // loginChoiseButton
            // 
            this.loginChoiseButton.Location = new System.Drawing.Point(609, 372);
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
            this.currentUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.currentUserLabel.Location = new System.Drawing.Point(12, 389);
            this.currentUserLabel.Name = "currentUserLabel";
            this.currentUserLabel.Size = new System.Drawing.Size(0, 13);
            this.currentUserLabel.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 363);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.amountNumericUpDown);
            this.tabPage1.Controls.Add(this.productAmountLabel);
            this.tabPage1.Controls.Add(this.productNameTextBox);
            this.tabPage1.Controls.Add(this.productNameLabel);
            this.tabPage1.Controls.Add(this.deleteProductButton);
            this.tabPage1.Controls.Add(this.addProductButton);
            this.tabPage1.Controls.Add(this.productsListBox);
            this.tabPage1.Controls.Add(this.productListLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(726, 337);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Продукты";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // amountNumericUpDown
            // 
            this.amountNumericUpDown.Location = new System.Drawing.Point(430, 81);
            this.amountNumericUpDown.Maximum = new decimal(new int[] {10000, 0, 0, 0});
            this.amountNumericUpDown.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.amountNumericUpDown.Name = "amountNumericUpDown";
            this.amountNumericUpDown.Size = new System.Drawing.Size(169, 20);
            this.amountNumericUpDown.TabIndex = 8;
            this.amountNumericUpDown.Value = new decimal(new int[] {10, 0, 0, 0});
            // 
            // productAmountLabel
            // 
            this.productAmountLabel.AutoSize = true;
            this.productAmountLabel.Location = new System.Drawing.Point(430, 65);
            this.productAmountLabel.Name = "productAmountLabel";
            this.productAmountLabel.Size = new System.Drawing.Size(123, 13);
            this.productAmountLabel.TabIndex = 7;
            this.productAmountLabel.Text = "Количество (г/мл/шт.):";
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.productNameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.productNameTextBox.Location = new System.Drawing.Point(430, 19);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(288, 20);
            this.productNameTextBox.TabIndex = 6;
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Location = new System.Drawing.Point(430, 3);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(106, 13);
            this.productNameLabel.TabIndex = 5;
            this.productNameLabel.Text = "Название продукта";
            // 
            // deleteProductButton
            // 
            this.deleteProductButton.Location = new System.Drawing.Point(605, 132);
            this.deleteProductButton.Name = "deleteProductButton";
            this.deleteProductButton.Size = new System.Drawing.Size(115, 33);
            this.deleteProductButton.TabIndex = 3;
            this.deleteProductButton.Text = "Удалить";
            this.deleteProductButton.UseVisualStyleBackColor = true;
            this.deleteProductButton.Click += new System.EventHandler(this.deleteProductButton_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(430, 121);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(169, 44);
            this.addProductButton.TabIndex = 2;
            this.addProductButton.Text = "Добавить";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // productsListBox
            // 
            this.productsListBox.FormattingEnabled = true;
            this.productsListBox.Location = new System.Drawing.Point(6, 19);
            this.productsListBox.Name = "productsListBox";
            this.productsListBox.Size = new System.Drawing.Size(418, 316);
            this.productsListBox.Sorted = true;
            this.productsListBox.TabIndex = 1;
            this.productsListBox.SelectedIndexChanged += new System.EventHandler(this.productsListBox_SelectedIndexChanged);
            // 
            // productListLabel
            // 
            this.productListLabel.AutoSize = true;
            this.productListLabel.Location = new System.Drawing.Point(6, 3);
            this.productListLabel.Name = "productListLabel";
            this.productListLabel.Size = new System.Drawing.Size(165, 13);
            this.productListLabel.TabIndex = 0;
            this.productListLabel.Text = "Список имеющихся продуктов:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(726, 337);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Рецепты";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(726, 337);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Семья";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.currentUserLabel);
            this.Controls.Add(this.currentUserHeaderLabel);
            this.Controls.Add(this.loginChoiseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Домашний кухонный помощник";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.amountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.NumericUpDown amountNumericUpDown;

        #endregion
        private System.Windows.Forms.Label currentUserHeaderLabel;
        internal System.Windows.Forms.Label currentUserLabel;
        internal System.Windows.Forms.Button loginChoiseButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox productsListBox;
        private System.Windows.Forms.Label productListLabel;
        private System.Windows.Forms.Button deleteProductButton;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.TextBox productNameTextBox;
        //private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label productAmountLabel;
    }
}

