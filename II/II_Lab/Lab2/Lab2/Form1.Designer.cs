namespace Lab2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tpEx1 = new TabPage();
            btLogin = new Button();
            lbPassword = new Label();
            lbUsername = new Label();
            tbPassword = new TextBox();
            tbUsername = new TextBox();
            tpEx2 = new TabPage();
            btExit = new Button();
            btDelete = new Button();
            btCopy = new Button();
            lbCopy = new ListBox();
            lbRead = new ListBox();
            tpEx3 = new TabPage();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tbResult = new TextBox();
            tbNum2 = new TextBox();
            tbNum1 = new TextBox();
            menuStrip1 = new MenuStrip();
            tsBinaryOperators = new ToolStripComboBox();
            tpEx4 = new TabPage();
            tbEx4 = new TabControl();
            tabPage1 = new TabPage();
            pbCar = new PictureBox();
            lbCars = new ListBox();
            tabPage2 = new TabPage();
            groupBox2 = new GroupBox();
            rbCar = new RadioButton();
            rbHorse = new RadioButton();
            rbDog = new RadioButton();
            groupBox1 = new GroupBox();
            rbGreen = new RadioButton();
            rbRed = new RadioButton();
            rbBlue = new RadioButton();
            btShow = new Button();
            tabControl1.SuspendLayout();
            tpEx1.SuspendLayout();
            tpEx2.SuspendLayout();
            tpEx3.SuspendLayout();
            menuStrip1.SuspendLayout();
            tpEx4.SuspendLayout();
            tbEx4.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCar).BeginInit();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.AllowDrop = true;
            tabControl1.Controls.Add(tpEx1);
            tabControl1.Controls.Add(tpEx2);
            tabControl1.Controls.Add(tpEx3);
            tabControl1.Controls.Add(tpEx4);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += Tabs_SelectedIndexChanged;
            // 
            // tpEx1
            // 
            tpEx1.Controls.Add(btLogin);
            tpEx1.Controls.Add(lbPassword);
            tpEx1.Controls.Add(lbUsername);
            tpEx1.Controls.Add(tbPassword);
            tpEx1.Controls.Add(tbUsername);
            tpEx1.Location = new Point(4, 24);
            tpEx1.Name = "tpEx1";
            tpEx1.Padding = new Padding(3);
            tpEx1.Size = new Size(792, 422);
            tpEx1.TabIndex = 0;
            tpEx1.Text = "Exercise 1";
            tpEx1.UseVisualStyleBackColor = true;
            // 
            // btLogin
            // 
            btLogin.Location = new Point(356, 260);
            btLogin.Name = "btLogin";
            btLogin.Size = new Size(75, 23);
            btLogin.TabIndex = 4;
            btLogin.Text = "Button";
            btLogin.UseVisualStyleBackColor = true;
            btLogin.Click += btLogin_Click;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(173, 155);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(57, 15);
            lbPassword.TabIndex = 3;
            lbPassword.Text = "Password";
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Location = new Point(173, 100);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(60, 15);
            lbUsername.TabIndex = 2;
            lbUsername.Text = "Username";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(268, 152);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(242, 23);
            tbPassword.TabIndex = 1;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(268, 97);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(242, 23);
            tbUsername.TabIndex = 0;
            // 
            // tpEx2
            // 
            tpEx2.Controls.Add(btExit);
            tpEx2.Controls.Add(btDelete);
            tpEx2.Controls.Add(btCopy);
            tpEx2.Controls.Add(lbCopy);
            tpEx2.Controls.Add(lbRead);
            tpEx2.Location = new Point(4, 24);
            tpEx2.Name = "tpEx2";
            tpEx2.Padding = new Padding(3);
            tpEx2.Size = new Size(792, 422);
            tpEx2.TabIndex = 1;
            tpEx2.Text = "Exercise 2";
            tpEx2.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            btExit.Location = new Point(340, 221);
            btExit.Name = "btExit";
            btExit.Size = new Size(75, 23);
            btExit.TabIndex = 4;
            btExit.Text = "Exit";
            btExit.UseVisualStyleBackColor = true;
            btExit.Click += btExit_Click;
            // 
            // btDelete
            // 
            btDelete.Location = new Point(340, 99);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(75, 23);
            btDelete.TabIndex = 3;
            btDelete.Text = "Delete";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // btCopy
            // 
            btCopy.Location = new Point(340, 41);
            btCopy.Name = "btCopy";
            btCopy.Size = new Size(75, 23);
            btCopy.TabIndex = 2;
            btCopy.Text = "Copy";
            btCopy.UseVisualStyleBackColor = true;
            btCopy.Click += btCopy_Click;
            // 
            // lbCopy
            // 
            lbCopy.FormattingEnabled = true;
            lbCopy.Location = new Point(610, 16);
            lbCopy.Name = "lbCopy";
            lbCopy.Size = new Size(162, 139);
            lbCopy.TabIndex = 1;
            // 
            // lbRead
            // 
            lbRead.FormattingEnabled = true;
            lbRead.Location = new Point(26, 16);
            lbRead.Name = "lbRead";
            lbRead.Size = new Size(154, 139);
            lbRead.TabIndex = 0;
            // 
            // tpEx3
            // 
            tpEx3.Controls.Add(label3);
            tpEx3.Controls.Add(label2);
            tpEx3.Controls.Add(label1);
            tpEx3.Controls.Add(tbResult);
            tpEx3.Controls.Add(tbNum2);
            tpEx3.Controls.Add(tbNum1);
            tpEx3.Controls.Add(menuStrip1);
            tpEx3.Location = new Point(4, 24);
            tpEx3.Name = "tpEx3";
            tpEx3.Size = new Size(792, 422);
            tpEx3.TabIndex = 2;
            tpEx3.Text = "Exercise 3";
            tpEx3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(530, 81);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 6;
            label3.Text = "Result";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 134);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 5;
            label2.Text = "number 2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 81);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 4;
            label1.Text = "number 1";
            // 
            // tbResult
            // 
            tbResult.Location = new Point(445, 112);
            tbResult.Name = "tbResult";
            tbResult.Size = new Size(210, 23);
            tbResult.TabIndex = 2;
            // 
            // tbNum2
            // 
            tbNum2.Location = new Point(126, 131);
            tbNum2.Name = "tbNum2";
            tbNum2.Size = new Size(100, 23);
            tbNum2.TabIndex = 1;
            // 
            // tbNum1
            // 
            tbNum1.Location = new Point(126, 78);
            tbNum1.Name = "tbNum1";
            tbNum1.Size = new Size(100, 23);
            tbNum1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsBinaryOperators });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(792, 27);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsBinaryOperators
            // 
            tsBinaryOperators.Items.AddRange(new object[] { "+", "-", "/", "*", "%" });
            tsBinaryOperators.Name = "tsBinaryOperators";
            tsBinaryOperators.Size = new Size(121, 23);
            tsBinaryOperators.SelectedIndexChanged += tsBinaryOperators_SelectedIndexChanged;
            // 
            // tpEx4
            // 
            tpEx4.Controls.Add(tbEx4);
            tpEx4.Location = new Point(4, 24);
            tpEx4.Name = "tpEx4";
            tpEx4.Size = new Size(792, 422);
            tpEx4.TabIndex = 3;
            tpEx4.Text = "Exercise 4";
            tpEx4.UseVisualStyleBackColor = true;
            // 
            // tbEx4
            // 
            tbEx4.Controls.Add(tabPage1);
            tbEx4.Controls.Add(tabPage2);
            tbEx4.Dock = DockStyle.Fill;
            tbEx4.Location = new Point(0, 0);
            tbEx4.Name = "tbEx4";
            tbEx4.SelectedIndex = 0;
            tbEx4.Size = new Size(792, 422);
            tbEx4.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pbCar);
            tabPage1.Controls.Add(lbCars);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(784, 394);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // pbCar
            // 
            pbCar.Dock = DockStyle.Fill;
            pbCar.Location = new Point(163, 3);
            pbCar.Name = "pbCar";
            pbCar.Size = new Size(618, 388);
            pbCar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCar.TabIndex = 1;
            pbCar.TabStop = false;
            // 
            // lbCars
            // 
            lbCars.Dock = DockStyle.Left;
            lbCars.FormattingEnabled = true;
            lbCars.Items.AddRange(new object[] { "Volkswagen Passat", "BMW M4", "Bugatti Divo", "Peugeot 207 2011 1.4 HDI 70hp" });
            lbCars.Location = new Point(3, 3);
            lbCars.Name = "lbCars";
            lbCars.Size = new Size(160, 388);
            lbCars.TabIndex = 0;
            lbCars.SelectedIndexChanged += lbCars_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btShow);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(784, 394);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbCar);
            groupBox2.Controls.Add(rbHorse);
            groupBox2.Controls.Add(rbDog);
            groupBox2.Location = new Point(520, 115);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(147, 128);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // rbCar
            // 
            rbCar.AutoSize = true;
            rbCar.Location = new Point(6, 22);
            rbCar.Name = "rbCar";
            rbCar.Size = new Size(43, 19);
            rbCar.TabIndex = 3;
            rbCar.TabStop = true;
            rbCar.Text = "Car";
            rbCar.UseVisualStyleBackColor = true;
            // 
            // rbHorse
            // 
            rbHorse.AutoSize = true;
            rbHorse.Location = new Point(6, 56);
            rbHorse.Name = "rbHorse";
            rbHorse.Size = new Size(56, 19);
            rbHorse.TabIndex = 4;
            rbHorse.TabStop = true;
            rbHorse.Text = "Horse";
            rbHorse.UseVisualStyleBackColor = true;
            // 
            // rbDog
            // 
            rbDog.AutoSize = true;
            rbDog.Location = new Point(6, 89);
            rbDog.Name = "rbDog";
            rbDog.Size = new Size(47, 19);
            rbDog.TabIndex = 5;
            rbDog.TabStop = true;
            rbDog.Text = "Dog";
            rbDog.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbGreen);
            groupBox1.Controls.Add(rbRed);
            groupBox1.Controls.Add(rbBlue);
            groupBox1.Location = new Point(123, 115);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(148, 128);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // rbGreen
            // 
            rbGreen.AutoSize = true;
            rbGreen.Location = new Point(6, 93);
            rbGreen.Name = "rbGreen";
            rbGreen.Size = new Size(56, 19);
            rbGreen.TabIndex = 2;
            rbGreen.TabStop = true;
            rbGreen.Text = "Green";
            rbGreen.UseVisualStyleBackColor = true;
            // 
            // rbRed
            // 
            rbRed.AutoSize = true;
            rbRed.Location = new Point(6, 22);
            rbRed.Name = "rbRed";
            rbRed.Size = new Size(45, 19);
            rbRed.TabIndex = 0;
            rbRed.TabStop = true;
            rbRed.Text = "Red";
            rbRed.UseVisualStyleBackColor = true;
            // 
            // rbBlue
            // 
            rbBlue.AutoSize = true;
            rbBlue.Location = new Point(6, 56);
            rbBlue.Name = "rbBlue";
            rbBlue.Size = new Size(48, 19);
            rbBlue.TabIndex = 1;
            rbBlue.TabStop = true;
            rbBlue.Text = "Blue";
            rbBlue.UseVisualStyleBackColor = true;
            // 
            // btShow
            // 
            btShow.Location = new Point(335, 285);
            btShow.Name = "btShow";
            btShow.Size = new Size(75, 23);
            btShow.TabIndex = 8;
            btShow.Text = "Show";
            btShow.UseVisualStyleBackColor = true;
            btShow.Click += btShow_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tpEx1.ResumeLayout(false);
            tpEx1.PerformLayout();
            tpEx2.ResumeLayout(false);
            tpEx3.ResumeLayout(false);
            tpEx3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tpEx4.ResumeLayout(false);
            tbEx4.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbCar).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpEx1;
        private Label lbPassword;
        private Label lbUsername;
        private TextBox tbPassword;
        private TextBox tbUsername;
        private TabPage tpEx2;
        private TabPage tpEx3;
        private TabPage tpEx4;
        private Button btLogin;
        private ListBox lbCopy;
        private ListBox lbRead;
        private Button btExit;
        private Button btDelete;
        private Button btCopy;
        private TextBox tbResult;
        private TextBox tbNum2;
        private TextBox tbNum1;
        private MenuStrip menuStrip1;
        private ToolStripComboBox tsBinaryOperators;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabControl tbEx4;
        private TabPage tabPage1;
        private PictureBox pbCar;
        private ListBox lbCars;
        private TabPage tabPage2;
        private RadioButton rbBlue;
        private RadioButton rbRed;
        private RadioButton rbDog;
        private RadioButton rbHorse;
        private RadioButton rbCar;
        private RadioButton rbGreen;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btShow;
    }
}
