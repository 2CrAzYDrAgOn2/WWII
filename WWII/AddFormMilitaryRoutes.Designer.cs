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
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(242, 9);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(175, 25);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(243, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(157, 21);
            label1.TabIndex = 6;
            label1.Text = "Военный маршрут";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(329, 762);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 65);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelRouteName
            // 
            labelRouteName.AutoSize = true;
            labelRouteName.ForeColor = Color.Black;
            labelRouteName.Location = new Point(192, 500);
            labelRouteName.Margin = new Padding(4, 0, 4, 0);
            labelRouteName.Name = "labelRouteName";
            labelRouteName.Size = new Size(93, 15);
            labelRouteName.TabIndex = 7;
            labelRouteName.Text = "Наименование:";
            // 
            // textBoxRouteName
            // 
            textBoxRouteName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxRouteName.Location = new Point(291, 489);
            textBoxRouteName.Margin = new Padding(4, 3, 4, 3);
            textBoxRouteName.Name = "textBoxRouteName";
            textBoxRouteName.Size = new Size(455, 33);
            textBoxRouteName.TabIndex = 0;
            // 
            // labelStartLocation
            // 
            labelStartLocation.AutoSize = true;
            labelStartLocation.ForeColor = Color.Black;
            labelStartLocation.Location = new Point(181, 545);
            labelStartLocation.Margin = new Padding(4, 0, 4, 0);
            labelStartLocation.Name = "labelStartLocation";
            labelStartLocation.Size = new Size(104, 15);
            labelStartLocation.TabIndex = 8;
            labelStartLocation.Text = "Начальная точка:";
            // 
            // textBoxStartLocation
            // 
            textBoxStartLocation.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxStartLocation.Location = new Point(291, 534);
            textBoxStartLocation.Margin = new Padding(4, 3, 4, 3);
            textBoxStartLocation.Name = "textBoxStartLocation";
            textBoxStartLocation.Size = new Size(455, 33);
            textBoxStartLocation.TabIndex = 1;
            // 
            // labelEndLocation
            // 
            labelEndLocation.AutoSize = true;
            labelEndLocation.ForeColor = Color.Black;
            labelEndLocation.Location = new Point(188, 593);
            labelEndLocation.Margin = new Padding(4, 0, 4, 0);
            labelEndLocation.Name = "labelEndLocation";
            labelEndLocation.Size = new Size(97, 15);
            labelEndLocation.TabIndex = 9;
            labelEndLocation.Text = "Конечная точка:";
            // 
            // textBoxEndLocation
            // 
            textBoxEndLocation.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEndLocation.Location = new Point(291, 582);
            textBoxEndLocation.Margin = new Padding(4, 3, 4, 3);
            textBoxEndLocation.Name = "textBoxEndLocation";
            textBoxEndLocation.Size = new Size(455, 33);
            textBoxEndLocation.TabIndex = 2;
            // 
            // labelDescriptionMilitaryRoutes
            // 
            labelDescriptionMilitaryRoutes.AutoSize = true;
            labelDescriptionMilitaryRoutes.ForeColor = Color.Black;
            labelDescriptionMilitaryRoutes.Location = new Point(220, 635);
            labelDescriptionMilitaryRoutes.Margin = new Padding(4, 0, 4, 0);
            labelDescriptionMilitaryRoutes.Name = "labelDescriptionMilitaryRoutes";
            labelDescriptionMilitaryRoutes.Size = new Size(65, 15);
            labelDescriptionMilitaryRoutes.TabIndex = 10;
            labelDescriptionMilitaryRoutes.Text = "Описание:";
            // 
            // textBoxDescriptionMilitaryRoutes
            // 
            textBoxDescriptionMilitaryRoutes.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxDescriptionMilitaryRoutes.Location = new Point(291, 624);
            textBoxDescriptionMilitaryRoutes.Margin = new Padding(4, 3, 4, 3);
            textBoxDescriptionMilitaryRoutes.Name = "textBoxDescriptionMilitaryRoutes";
            textBoxDescriptionMilitaryRoutes.Size = new Size(455, 33);
            textBoxDescriptionMilitaryRoutes.TabIndex = 3;
            // 
            // AddFormMilitaryRoutes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 841);
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