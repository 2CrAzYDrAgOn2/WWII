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
            labelTitle.Font = new Font("Segoe UI", 35F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(242, 9);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(429, 62);
            labelTitle.TabIndex = 6;
            labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(386, 87);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(147, 45);
            label1.TabIndex = 7;
            label1.Text = "Ветеран";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(336, 464);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 55);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.BackColor = Color.Transparent;
            labelFullName.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelFullName.ForeColor = Color.Black;
            labelFullName.Location = new Point(164, 185);
            labelFullName.Margin = new Padding(4, 0, 4, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(65, 28);
            labelFullName.TabIndex = 8;
            labelFullName.Text = "ФИО:";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Font = new Font("Segoe UI", 15F);
            textBoxFullName.Location = new Point(237, 182);
            textBoxFullName.Margin = new Padding(4, 3, 4, 3);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(455, 34);
            textBoxFullName.TabIndex = 0;
            // 
            // labelBirthDate
            // 
            labelBirthDate.AutoSize = true;
            labelBirthDate.BackColor = Color.Transparent;
            labelBirthDate.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelBirthDate.ForeColor = Color.Black;
            labelBirthDate.Location = new Point(59, 239);
            labelBirthDate.Margin = new Padding(4, 0, 4, 0);
            labelBirthDate.Name = "labelBirthDate";
            labelBirthDate.Size = new Size(170, 28);
            labelBirthDate.TabIndex = 9;
            labelBirthDate.Text = "Дата рождения:";
            // 
            // dateTimePickerBirthDate
            // 
            dateTimePickerBirthDate.Font = new Font("Segoe UI", 15F);
            dateTimePickerBirthDate.Location = new Point(237, 234);
            dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            dateTimePickerBirthDate.Size = new Size(455, 34);
            dateTimePickerBirthDate.TabIndex = 1;
            // 
            // labelDeathDate
            // 
            labelDeathDate.AutoSize = true;
            labelDeathDate.BackColor = Color.Transparent;
            labelDeathDate.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelDeathDate.ForeColor = Color.Black;
            labelDeathDate.Location = new Point(88, 292);
            labelDeathDate.Margin = new Padding(4, 0, 4, 0);
            labelDeathDate.Name = "labelDeathDate";
            labelDeathDate.Size = new Size(141, 28);
            labelDeathDate.TabIndex = 10;
            labelDeathDate.Text = "Дата смерти:";
            // 
            // dateTimePickerDeathDate
            // 
            dateTimePickerDeathDate.Font = new Font("Segoe UI", 15F);
            dateTimePickerDeathDate.Location = new Point(237, 287);
            dateTimePickerDeathDate.Name = "dateTimePickerDeathDate";
            dateTimePickerDeathDate.Size = new Size(455, 34);
            dateTimePickerDeathDate.TabIndex = 2;
            // 
            // labelMilitaryRank
            // 
            labelMilitaryRank.AutoSize = true;
            labelMilitaryRank.BackColor = Color.Transparent;
            labelMilitaryRank.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelMilitaryRank.ForeColor = Color.Black;
            labelMilitaryRank.Location = new Point(142, 341);
            labelMilitaryRank.Margin = new Padding(4, 0, 4, 0);
            labelMilitaryRank.Name = "labelMilitaryRank";
            labelMilitaryRank.Size = new Size(87, 28);
            labelMilitaryRank.TabIndex = 11;
            labelMilitaryRank.Text = "Звание:";
            // 
            // textBoxMilitaryRank
            // 
            textBoxMilitaryRank.Font = new Font("Segoe UI", 15F);
            textBoxMilitaryRank.Location = new Point(237, 338);
            textBoxMilitaryRank.Margin = new Padding(4, 3, 4, 3);
            textBoxMilitaryRank.Name = "textBoxMilitaryRank";
            textBoxMilitaryRank.Size = new Size(455, 34);
            textBoxMilitaryRank.TabIndex = 3;
            // 
            // labelUnitID
            // 
            labelUnitID.AutoSize = true;
            labelUnitID.BackColor = Color.Transparent;
            labelUnitID.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelUnitID.ForeColor = Color.Black;
            labelUnitID.Location = new Point(133, 392);
            labelUnitID.Margin = new Padding(4, 0, 4, 0);
            labelUnitID.Name = "labelUnitID";
            labelUnitID.Size = new Size(96, 28);
            labelUnitID.TabIndex = 12;
            labelUnitID.Text = "Оружие:";
            // 
            // textBoxUnitID
            // 
            textBoxUnitID.Font = new Font("Segoe UI", 15F);
            textBoxUnitID.Location = new Point(237, 389);
            textBoxUnitID.Margin = new Padding(4, 3, 4, 3);
            textBoxUnitID.Name = "textBoxUnitID";
            textBoxUnitID.Size = new Size(455, 34);
            textBoxUnitID.TabIndex = 4;
            // 
            // AddFormVeterans
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(884, 561);
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