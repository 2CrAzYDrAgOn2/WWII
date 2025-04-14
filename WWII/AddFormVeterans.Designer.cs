namespace WWII
{
    partial class AddFormVeterans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormVeterans));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelFullName = new Label();
            textBoxFullName = new TextBox();
            labelBirthDate = new Label();
            dateTimePickerBirthDate = new DateTimePicker();
            labelDeathDate = new Label();
            dateTimePickerDeathDate = new DateTimePicker();
            labelMilitaryRank = new Label();
            textBoxMilitaryRank = new TextBox();
            labelUnitID = new Label();
            textBoxUnitID = new TextBox();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(243, 9);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(175, 25);
            labelTitle.TabIndex = 6;
            labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(244, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(74, 21);
            label1.TabIndex = 7;
            label1.Text = "Ветеран";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(330, 762);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 65);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.ForeColor = Color.Black;
            labelFullName.Location = new Point(246, 499);
            labelFullName.Margin = new Padding(4, 0, 4, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(37, 15);
            labelFullName.TabIndex = 8;
            labelFullName.Text = "ФИО:";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxFullName.Location = new Point(292, 489);
            textBoxFullName.Margin = new Padding(4, 3, 4, 3);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(455, 33);
            textBoxFullName.TabIndex = 0;
            // 
            // labelBirthDate
            // 
            labelBirthDate.AutoSize = true;
            labelBirthDate.ForeColor = Color.Black;
            labelBirthDate.Location = new Point(181, 546);
            labelBirthDate.Margin = new Padding(4, 0, 4, 0);
            labelBirthDate.Name = "labelBirthDate";
            labelBirthDate.Size = new Size(93, 15);
            labelBirthDate.TabIndex = 9;
            labelBirthDate.Text = "Дата рождения:";
            // 
            // dateTimePickerBirthDate
            // 
            dateTimePickerBirthDate.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerBirthDate.Location = new Point(292, 534);
            dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            dateTimePickerBirthDate.Size = new Size(455, 33);
            dateTimePickerBirthDate.TabIndex = 1;
            // 
            // labelDeathDate
            // 
            labelDeathDate.AutoSize = true;
            labelDeathDate.ForeColor = Color.Black;
            labelDeathDate.Location = new Point(200, 586);
            labelDeathDate.Margin = new Padding(4, 0, 4, 0);
            labelDeathDate.Name = "labelDeathDate";
            labelDeathDate.Size = new Size(78, 15);
            labelDeathDate.TabIndex = 10;
            labelDeathDate.Text = "Дата смерти:";
            // 
            // dateTimePickerDeathDate
            // 
            dateTimePickerDeathDate.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerDeathDate.Location = new Point(292, 579);
            dateTimePickerDeathDate.Name = "dateTimePickerDeathDate";
            dateTimePickerDeathDate.Size = new Size(455, 33);
            dateTimePickerDeathDate.TabIndex = 2;
            // 
            // labelMilitaryRank
            // 
            labelMilitaryRank.AutoSize = true;
            labelMilitaryRank.ForeColor = Color.Black;
            labelMilitaryRank.Location = new Point(231, 634);
            labelMilitaryRank.Margin = new Padding(4, 0, 4, 0);
            labelMilitaryRank.Name = "labelMilitaryRank";
            labelMilitaryRank.Size = new Size(49, 15);
            labelMilitaryRank.TabIndex = 11;
            labelMilitaryRank.Text = "Звание:";
            // 
            // textBoxMilitaryRank
            // 
            textBoxMilitaryRank.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxMilitaryRank.Location = new Point(292, 624);
            textBoxMilitaryRank.Margin = new Padding(4, 3, 4, 3);
            textBoxMilitaryRank.Name = "textBoxMilitaryRank";
            textBoxMilitaryRank.Size = new Size(455, 33);
            textBoxMilitaryRank.TabIndex = 3;
            // 
            // labelUnitID
            // 
            labelUnitID.AutoSize = true;
            labelUnitID.ForeColor = Color.Black;
            labelUnitID.Location = new Point(227, 679);
            labelUnitID.Margin = new Padding(4, 0, 4, 0);
            labelUnitID.Name = "labelUnitID";
            labelUnitID.Size = new Size(54, 15);
            labelUnitID.TabIndex = 12;
            labelUnitID.Text = "Оружие:";
            // 
            // textBoxUnitID
            // 
            textBoxUnitID.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxUnitID.Location = new Point(292, 669);
            textBoxUnitID.Margin = new Padding(4, 3, 4, 3);
            textBoxUnitID.Name = "textBoxUnitID";
            textBoxUnitID.Size = new Size(455, 33);
            textBoxUnitID.TabIndex = 4;
            // 
            // AddFormVeterans
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelFullName);
            Controls.Add(textBoxFullName);
            Controls.Add(labelBirthDate);
            Controls.Add(dateTimePickerBirthDate);
            Controls.Add(labelDeathDate);
            Controls.Add(dateTimePickerDeathDate);
            Controls.Add(labelMilitaryRank);
            Controls.Add(textBoxMilitaryRank);
            Controls.Add(labelUnitID);
            Controls.Add(textBoxUnitID);
            Controls.Add(buttonSave);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormVeterans";
            Text = "Добавить ветерана";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelFullName;
        private TextBox textBoxFullName;
        private Label labelBirthDate;
        private DateTimePicker dateTimePickerBirthDate;
        private Label labelDeathDate;
        private DateTimePicker dateTimePickerDeathDate;
        private Label labelMilitaryRank;
        private TextBox textBoxMilitaryRank;
        private Label labelUnitID;
        private TextBox textBoxUnitID;
    }
}