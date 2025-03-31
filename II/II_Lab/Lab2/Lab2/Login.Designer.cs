namespace Lab2
{
    partial class Login
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
            lbHello = new Label();
            btExit = new Button();
            SuspendLayout();
            // 
            // lbHello
            // 
            lbHello.AutoSize = true;
            lbHello.Location = new Point(332, 221);
            lbHello.Name = "lbHello";
            lbHello.Size = new Size(38, 15);
            lbHello.TabIndex = 0;
            lbHello.Text = "label1";
            // 
            // btExit
            // 
            btExit.Location = new Point(319, 291);
            btExit.Name = "btExit";
            btExit.Size = new Size(75, 23);
            btExit.TabIndex = 1;
            btExit.Text = "Exit";
            btExit.UseVisualStyleBackColor = true;
            btExit.Click += btExit_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btExit);
            Controls.Add(lbHello);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbHello;
        private Button btExit;
    }
}