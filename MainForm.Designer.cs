
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
            this.productsInRecipeLabel = new System.Windows.Forms.Label();
            this.cookButton = new System.Windows.Forms.Button();
            this.productsInRecipeListBox = new System.Windows.Forms.ListBox();
            this.recipeDescriptionLabel = new System.Windows.Forms.Label();
            this.recipeDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.recipeListLabel = new System.Windows.Forms.Label();
            this.recipesListBox = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.leaveFromFamilyButton = new System.Windows.Forms.Button();
            this.addUserButton = new System.Windows.Forms.Button();
            this.addUserTextBox = new System.Windows.Forms.TextBox();
            this.addUserLabel = new System.Windows.Forms.Label();
            this.createFamilyButton = new System.Windows.Forms.Button();
            this.usersInFamilyListBox = new System.Windows.Forms.ListBox();
            this.usersInFamilyLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.amountNumericUpDown)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.tabPage2.Controls.Add(this.productsInRecipeLabel);
            this.tabPage2.Controls.Add(this.cookButton);
            this.tabPage2.Controls.Add(this.productsInRecipeListBox);
            this.tabPage2.Controls.Add(this.recipeDescriptionLabel);
            this.tabPage2.Controls.Add(this.recipeDescriptionTextBox);
            this.tabPage2.Controls.Add(this.recipeListLabel);
            this.tabPage2.Controls.Add(this.recipesListBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(726, 337);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Рецепты";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // productsInRecipeLabel
            // 
            this.productsInRecipeLabel.Location = new System.Drawing.Point(6, 168);
            this.productsInRecipeLabel.Name = "productsInRecipeLabel";
            this.productsInRecipeLabel.Size = new System.Drawing.Size(131, 13);
            this.productsInRecipeLabel.TabIndex = 6;
            this.productsInRecipeLabel.Text = "Список ингридиентов:";
            // 
            // cookButton
            // 
            this.cookButton.Enabled = false;
            this.cookButton.Location = new System.Drawing.Point(454, 260);
            this.cookButton.Name = "cookButton";
            this.cookButton.Size = new System.Drawing.Size(151, 42);
            this.cookButton.TabIndex = 5;
            this.cookButton.Text = "Приготовить";
            this.cookButton.UseVisualStyleBackColor = true;
            this.cookButton.Click += new System.EventHandler(this.cookButton_Click);
            // 
            // productsInRecipeListBox
            // 
            this.productsInRecipeListBox.FormattingEnabled = true;
            this.productsInRecipeListBox.Location = new System.Drawing.Point(6, 184);
            this.productsInRecipeListBox.Name = "productsInRecipeListBox";
            this.productsInRecipeListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.productsInRecipeListBox.Size = new System.Drawing.Size(331, 147);
            this.productsInRecipeListBox.Sorted = true;
            this.productsInRecipeListBox.TabIndex = 4;
            // 
            // recipeDescriptionLabel
            // 
            this.recipeDescriptionLabel.Location = new System.Drawing.Point(343, 3);
            this.recipeDescriptionLabel.Name = "recipeDescriptionLabel";
            this.recipeDescriptionLabel.Size = new System.Drawing.Size(182, 13);
            this.recipeDescriptionLabel.TabIndex = 3;
            this.recipeDescriptionLabel.Text = "Инструкция по приготовлению:";
            // 
            // recipeDescriptionTextBox
            // 
            this.recipeDescriptionTextBox.Location = new System.Drawing.Point(343, 19);
            this.recipeDescriptionTextBox.Multiline = true;
            this.recipeDescriptionTextBox.Name = "recipeDescriptionTextBox";
            this.recipeDescriptionTextBox.ReadOnly = true;
            this.recipeDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.recipeDescriptionTextBox.Size = new System.Drawing.Size(377, 206);
            this.recipeDescriptionTextBox.TabIndex = 2;
            // 
            // recipeListLabel
            // 
            this.recipeListLabel.Location = new System.Drawing.Point(6, 3);
            this.recipeListLabel.Name = "recipeListLabel";
            this.recipeListLabel.Size = new System.Drawing.Size(155, 13);
            this.recipeListLabel.TabIndex = 1;
            this.recipeListLabel.Text = "Список доступных рецептов:";
            // 
            // recipesListBox
            // 
            this.recipesListBox.FormattingEnabled = true;
            this.recipesListBox.Location = new System.Drawing.Point(6, 19);
            this.recipesListBox.Name = "recipesListBox";
            this.recipesListBox.Size = new System.Drawing.Size(331, 147);
            this.recipesListBox.Sorted = true;
            this.recipesListBox.TabIndex = 0;
            this.recipesListBox.SelectedIndexChanged += new System.EventHandler(this.recipesListBox_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.leaveFromFamilyButton);
            this.tabPage3.Controls.Add(this.addUserButton);
            this.tabPage3.Controls.Add(this.addUserTextBox);
            this.tabPage3.Controls.Add(this.addUserLabel);
            this.tabPage3.Controls.Add(this.createFamilyButton);
            this.tabPage3.Controls.Add(this.usersInFamilyListBox);
            this.tabPage3.Controls.Add(this.usersInFamilyLabel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(726, 337);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Семья";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // leaveFromFamilyButton
            // 
            this.leaveFromFamilyButton.Enabled = false;
            this.leaveFromFamilyButton.Location = new System.Drawing.Point(610, 267);
            this.leaveFromFamilyButton.Name = "leaveFromFamilyButton";
            this.leaveFromFamilyButton.Size = new System.Drawing.Size(108, 32);
            this.leaveFromFamilyButton.TabIndex = 6;
            this.leaveFromFamilyButton.Text = "Выйти из семьи";
            this.leaveFromFamilyButton.UseVisualStyleBackColor = true;
            this.leaveFromFamilyButton.Click += new System.EventHandler(this.leaveFromFamilyButton_Click);
            // 
            // addUserButton
            // 
            this.addUserButton.Enabled = false;
            this.addUserButton.Location = new System.Drawing.Point(630, 213);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(88, 23);
            this.addUserButton.TabIndex = 5;
            this.addUserButton.Text = "Добавить";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // addUserTextBox
            // 
            this.addUserTextBox.Enabled = false;
            this.addUserTextBox.Location = new System.Drawing.Point(393, 215);
            this.addUserTextBox.Name = "addUserTextBox";
            this.addUserTextBox.Size = new System.Drawing.Size(231, 20);
            this.addUserTextBox.TabIndex = 4;
            // 
            // addUserLabel
            // 
            this.addUserLabel.Location = new System.Drawing.Point(393, 199);
            this.addUserLabel.Name = "addUserLabel";
            this.addUserLabel.Size = new System.Drawing.Size(131, 13);
            this.addUserLabel.TabIndex = 3;
            this.addUserLabel.Text = "Логин пользователя:";
            // 
            // createFamilyButton
            // 
            this.createFamilyButton.Location = new System.Drawing.Point(490, 82);
            this.createFamilyButton.Name = "createFamilyButton";
            this.createFamilyButton.Size = new System.Drawing.Size(143, 44);
            this.createFamilyButton.TabIndex = 2;
            this.createFamilyButton.Text = "Создать семью";
            this.createFamilyButton.UseVisualStyleBackColor = true;
            this.createFamilyButton.Click += new System.EventHandler(this.createFamilyButton_Click);
            // 
            // usersInFamilyListBox
            // 
            this.usersInFamilyListBox.FormattingEnabled = true;
            this.usersInFamilyListBox.Location = new System.Drawing.Point(6, 19);
            this.usersInFamilyListBox.Name = "usersInFamilyListBox";
            this.usersInFamilyListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.usersInFamilyListBox.Size = new System.Drawing.Size(381, 316);
            this.usersInFamilyListBox.Sorted = true;
            this.usersInFamilyListBox.TabIndex = 1;
            // 
            // usersInFamilyLabel
            // 
            this.usersInFamilyLabel.Location = new System.Drawing.Point(6, 3);
            this.usersInFamilyLabel.Name = "usersInFamilyLabel";
            this.usersInFamilyLabel.Size = new System.Drawing.Size(256, 13);
            this.usersInFamilyLabel.TabIndex = 0;
            this.usersInFamilyLabel.Text = "Список пользователей, входящих в семью:";
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button leaveFromFamilyButton;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button createFamilyButton;
        private System.Windows.Forms.Label addUserLabel;
        private System.Windows.Forms.TextBox addUserTextBox;
        private System.Windows.Forms.Button addUserButton;

        private System.Windows.Forms.ListBox usersInFamilyListBox;

        private System.Windows.Forms.Label usersInFamilyLabel;
        private System.Windows.Forms.ListBox listBox1;

        private System.Windows.Forms.Label productsInRecipeLabel;

        private System.Windows.Forms.Button cookButton;

        private System.Windows.Forms.Button Button;

        private System.Windows.Forms.ListBox productsInRecipeListBox;

        private System.Windows.Forms.TextBox recipeDescriptionTextBox;
        private System.Windows.Forms.Label recipeDescriptionLabel;

        // private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.ListBox recipesListBox;
        private System.Windows.Forms.Label recipeListLabel;

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

