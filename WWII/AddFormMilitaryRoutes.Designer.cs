namespace WWII
{
    partial class AddFormMilitaryRoutes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormMilitaryRoutes));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelRouteName = new Label();
            textBoxRouteName = new TextBox();
            labelStartLocation = new Label();
            textBoxStartLocation = new TextBox();
            labelEndLocation = new Label();
            textBoxEndLocation = new TextBox();
            labelDescriptionMilitaryRoutes = new Label();
            textBoxDescriptionMilitaryRoutes = new TextBox();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 35F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(242, 9);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(429, 62);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(291, 90);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(316, 45);
            label1.TabIndex = 6;
            label1.Text = "Военный маршрут";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(329, 416);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 55);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelRouteName
            // 
            labelRouteName.AutoSize = true;
            labelRouteName.BackColor = Color.Transparent;
            labelRouteName.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelRouteName.ForeColor = Color.Black;
            labelRouteName.Location = new Point(63, 185);
            labelRouteName.Margin = new Padding(4, 0, 4, 0);
            labelRouteName.Name = "labelRouteName";
            labelRouteName.Size = new Size(166, 28);
            labelRouteName.TabIndex = 7;
            labelRouteName.Text = "Наименование:";
            // 
            // textBoxRouteName
            // 
            textBoxRouteName.Font = new Font("Segoe UI", 15F);
            textBoxRouteName.Location = new Point(237, 182);
            textBoxRouteName.Margin = new Padding(4, 3, 4, 3);
            textBoxRouteName.Name = "textBoxRouteName";
            textBoxRouteName.Size = new Size(455, 34);
            textBoxRouteName.TabIndex = 0;
            // 
            // labelStartLocation
            // 
            labelStartLocation.AutoSize = true;
            labelStartLocation.BackColor = Color.Transparent;
            labelStartLocation.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelStartLocation.ForeColor = Color.Black;
            labelStartLocation.Location = new Point(45, 237);
            labelStartLocation.Margin = new Padding(4, 0, 4, 0);
            labelStartLocation.Name = "labelStartLocation";
            labelStartLocation.Size = new Size(184, 28);
            labelStartLocation.TabIndex = 8;
            labelStartLocation.Text = "Начальная точка:";
            // 
            // textBoxStartLocation
            // 
            textBoxStartLocation.Font = new Font("Segoe UI", 15F);
            textBoxStartLocation.Location = new Point(237, 234);
            textBoxStartLocation.Margin = new Padding(4, 3, 4, 3);
            textBoxStartLocation.Name = "textBoxStartLocation";
            textBoxStartLocation.Size = new Size(455, 34);
            textBoxStartLocation.TabIndex = 1;
            // 
            // labelEndLocation
            // 
            labelEndLocation.AutoSize = true;
            labelEndLocation.BackColor = Color.Transparent;
            labelEndLocation.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelEndLocation.ForeColor = Color.Black;
            labelEndLocation.Location = new Point(57, 287);
            labelEndLocation.Margin = new Padding(4, 0, 4, 0);
            labelEndLocation.Name = "labelEndLocation";
            labelEndLocation.Size = new Size(172, 28);
            labelEndLocation.TabIndex = 9;
            labelEndLocation.Text = "Конечная точка:";
            // 
            // textBoxEndLocation
            // 
            textBoxEndLocation.Font = new Font("Segoe UI", 15F);
            textBoxEndLocation.Location = new Point(237, 284);
            textBoxEndLocation.Margin = new Padding(4, 3, 4, 3);
            textBoxEndLocation.Name = "textBoxEndLocation";
            textBoxEndLocation.Size = new Size(455, 34);
            textBoxEndLocation.TabIndex = 2;
            // 
            // labelDescriptionMilitaryRoutes
            // 
            labelDescriptionMilitaryRoutes.AutoSize = true;
            labelDescriptionMilitaryRoutes.BackColor = Color.Transparent;
            labelDescriptionMilitaryRoutes.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelDescriptionMilitaryRoutes.ForeColor = Color.Black;
            labelDescriptionMilitaryRoutes.Location = new Point(115, 339);
            labelDescriptionMilitaryRoutes.Margin = new Padding(4, 0, 4, 0);
            labelDescriptionMilitaryRoutes.Name = "labelDescriptionMilitaryRoutes";
            labelDescriptionMilitaryRoutes.Size = new Size(114, 28);
            labelDescriptionMilitaryRoutes.TabIndex = 10;
            labelDescriptionMilitaryRoutes.Text = "Описание:";
            // 
            // textBoxDescriptionMilitaryRoutes
            // 
            textBoxDescriptionMilitaryRoutes.Font = new Font("Segoe UI", 15F);
            textBoxDescriptionMilitaryRoutes.Location = new Point(237, 336);
            textBoxDescriptionMilitaryRoutes.Margin = new Padding(4, 3, 4, 3);
            textBoxDescriptionMilitaryRoutes.Name = "textBoxDescriptionMilitaryRoutes";
            textBoxDescriptionMilitaryRoutes.Size = new Size(455, 34);
            textBoxDescriptionMilitaryRoutes.TabIndex = 3;
            // 
            // AddFormMilitaryRoutes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(884, 521);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelRouteName);
            Controls.Add(textBoxRouteName);
            Controls.Add(labelStartLocation);
            Controls.Add(textBoxStartLocation);
            Controls.Add(labelEndLocation);
            Controls.Add(textBoxEndLocation);
            Controls.Add(labelDescriptionMilitaryRoutes);
            Controls.Add(textBoxDescriptionMilitaryRoutes);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormMilitaryRoutes";
            Text = "Добавить военный маршрут";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelRouteName;
        private TextBox textBoxRouteName;
        private Label labelStartLocation;
        private TextBox textBoxStartLocation;
        private Label labelEndLocation;
        private TextBox textBoxEndLocation;
        private Label labelDescriptionMilitaryRoutes;
        private TextBox textBoxDescriptionMilitaryRoutes;
    }
}