namespace WWII
{
    partial class Signup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signup));
            buttonEnter = new Button();
            textBoxPassword = new TextBox();
            textBoxLogin = new TextBox();
            labelRegister = new Label();
            buttonShow = new Button();
            panel2 = new Panel();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // buttonEnter
            // 
            buttonEnter.BackColor = Color.Transparent;
            buttonEnter.FlatStyle = FlatStyle.Flat;
            buttonEnter.Font = new Font("Segoe UI Semibold", 35F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonEnter.ForeColor = Color.Black;
            buttonEnter.Location = new Point(230, 267);
            buttonEnter.Name = "buttonEnter";
            buttonEnter.Size = new Size(178, 76);
            buttonEnter.TabIndex = 2;
            buttonEnter.Text = "Войти";
            buttonEnter.UseVisualStyleBackColor = false;
            buttonEnter.Click += ButtonEnter_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            textBoxPassword.Location = new Point(102, 198);
            textBoxPassword.MaxLength = 50;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '•';
            textBoxPassword.Size = new Size(433, 50);
            textBoxPassword.TabIndex = 1;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            textBoxLogin.Location = new Point(102, 142);
            textBoxLogin.MaxLength = 50;
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(433, 50);
            textBoxLogin.TabIndex = 0;
            // 
            // labelRegister
            // 
            labelRegister.AutoSize = true;
            labelRegister.BackColor = Color.Transparent;
            labelRegister.Font = new Font("Segoe UI Semibold", 35F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelRegister.ForeColor = Color.Black;
            labelRegister.Location = new Point(157, 58);
            labelRegister.Name = "labelRegister";
            labelRegister.Size = new Size(300, 62);
            labelRegister.TabIndex = 5;
            labelRegister.Text = "Регистрация";
            // 
            // buttonShow
            // 
            buttonShow.BackColor = Color.Transparent;
            buttonShow.BackgroundImage = Properties.Resources.ShowPassword0;
            buttonShow.BackgroundImageLayout = ImageLayout.Stretch;
            buttonShow.FlatStyle = FlatStyle.Flat;
            buttonShow.Location = new Point(541, 198);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(50, 50);
            buttonShow.TabIndex = 4;
            buttonShow.UseVisualStyleBackColor = false;
            buttonShow.Click += ButtonShow_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Location = new Point(55, 198);
            panel2.Name = "panel2";
            panel2.Size = new Size(50, 50);
            panel2.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(55, 142);
            panel1.Name = "panel1";
            panel1.Size = new Size(50, 50);
            panel1.TabIndex = 9;
            // 
            // Signup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(644, 401);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(textBoxLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonEnter);
            Controls.Add(buttonShow);
            Controls.Add(labelRegister);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "Signup";
            Text = "Signup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonEnter;
        private TextBox textBoxPassword;
        private TextBox textBoxLogin;
        private Label labelRegister;
        private Button buttonShow;
        private Panel panel2;
        private Panel panel1;
    }
}