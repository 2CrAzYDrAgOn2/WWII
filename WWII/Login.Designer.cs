namespace WWII
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            labelRegister = new Label();
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            buttonEnter = new Button();
            labelAuth = new Label();
            buttonShow = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // labelRegister
            // 
            labelRegister.AutoSize = true;
            labelRegister.BackColor = Color.Transparent;
            labelRegister.Font = new Font("Segoe UI Semibold", 35F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelRegister.ForeColor = Color.Black;
            labelRegister.Location = new Point(159, 24);
            labelRegister.Name = "labelRegister";
            labelRegister.Size = new Size(317, 62);
            labelRegister.TabIndex = 6;
            labelRegister.Text = "Авторизация";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxLogin.Location = new Point(104, 108);
            textBoxLogin.MaxLength = 50;
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(433, 50);
            textBoxLogin.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxPassword.Location = new Point(104, 164);
            textBoxPassword.MaxLength = 50;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '•';
            textBoxPassword.Size = new Size(433, 50);
            textBoxPassword.TabIndex = 1;
            // 
            // buttonEnter
            // 
            buttonEnter.BackColor = Color.Transparent;
            buttonEnter.FlatStyle = FlatStyle.Flat;
            buttonEnter.Font = new Font("Segoe UI Semibold", 35F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonEnter.ForeColor = Color.Black;
            buttonEnter.Location = new Point(232, 233);
            buttonEnter.Name = "buttonEnter";
            buttonEnter.Size = new Size(178, 76);
            buttonEnter.TabIndex = 2;
            buttonEnter.Text = "Войти";
            buttonEnter.UseVisualStyleBackColor = false;
            buttonEnter.Click += ButtonEnter_Click;
            // 
            // labelAuth
            // 
            labelAuth.AutoSize = true;
            labelAuth.BackColor = Color.Transparent;
            labelAuth.Font = new Font("Segoe UI", 24F, FontStyle.Underline);
            labelAuth.ForeColor = Color.Black;
            labelAuth.Location = new Point(175, 326);
            labelAuth.Name = "labelAuth";
            labelAuth.Size = new Size(285, 45);
            labelAuth.TabIndex = 3;
            labelAuth.Text = "Ещё нет аккаунта?";
            labelAuth.Click += LabelAuth_Click;
            // 
            // buttonShow
            // 
            buttonShow.BackColor = Color.Transparent;
            buttonShow.BackgroundImage = Properties.Resources.ShowPassword0;
            buttonShow.BackgroundImageLayout = ImageLayout.Stretch;
            buttonShow.FlatStyle = FlatStyle.Flat;
            buttonShow.Location = new Point(543, 164);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(50, 50);
            buttonShow.TabIndex = 5;
            buttonShow.UseVisualStyleBackColor = false;
            buttonShow.Click += ButtonShow_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(54, 108);
            panel1.Name = "panel1";
            panel1.Size = new Size(50, 50);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Location = new Point(54, 164);
            panel2.Name = "panel2";
            panel2.Size = new Size(50, 50);
            panel2.TabIndex = 8;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(644, 401);
            Controls.Add(panel2);
            Controls.Add(textBoxLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonEnter);
            Controls.Add(labelAuth);
            Controls.Add(buttonShow);
            Controls.Add(labelRegister);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelRegister;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Button buttonEnter;
        private Label labelAuth;
        private Button buttonShow;
        private Panel panel1;
        private Panel panel2;
    }
}
