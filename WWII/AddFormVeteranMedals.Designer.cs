namespace WWII
{
    partial class AddFormVeteranMedals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormVeteranMedals));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelVeteranIDVeteranMedals = new Label();
            labelMedalIDVeteranMedals = new Label();
            labelAwardDate = new Label();
            dateTimePickerAwardDate = new DateTimePicker();
            comboBoxVeteranIDVeteranMedals = new ComboBox();
            comboBoxMedalIDVeteranMedals = new ComboBox();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 35F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(227, 24);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(429, 62);
            labelTitle.TabIndex = 4;
            labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(297, 98);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(300, 45);
            label1.TabIndex = 5;
            label1.Text = "Награда ветерана";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(333, 366);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 55);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelVeteranIDVeteranMedals
            // 
            labelVeteranIDVeteranMedals.AutoSize = true;
            labelVeteranIDVeteranMedals.BackColor = Color.Transparent;
            labelVeteranIDVeteranMedals.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelVeteranIDVeteranMedals.ForeColor = Color.Black;
            labelVeteranIDVeteranMedals.Location = new Point(136, 185);
            labelVeteranIDVeteranMedals.Margin = new Padding(4, 0, 4, 0);
            labelVeteranIDVeteranMedals.Name = "labelVeteranIDVeteranMedals";
            labelVeteranIDVeteranMedals.Size = new Size(96, 28);
            labelVeteranIDVeteranMedals.TabIndex = 6;
            labelVeteranIDVeteranMedals.Text = "Ветеран:";
            // 
            // labelMedalIDVeteranMedals
            // 
            labelMedalIDVeteranMedals.AutoSize = true;
            labelMedalIDVeteranMedals.BackColor = Color.Transparent;
            labelMedalIDVeteranMedals.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelMedalIDVeteranMedals.ForeColor = Color.Black;
            labelMedalIDVeteranMedals.Location = new Point(139, 237);
            labelMedalIDVeteranMedals.Margin = new Padding(4, 0, 4, 0);
            labelMedalIDVeteranMedals.Name = "labelMedalIDVeteranMedals";
            labelMedalIDVeteranMedals.Size = new Size(93, 28);
            labelMedalIDVeteranMedals.TabIndex = 7;
            labelMedalIDVeteranMedals.Text = "Медаль:";
            // 
            // labelAwardDate
            // 
            labelAwardDate.AutoSize = true;
            labelAwardDate.BackColor = Color.Transparent;
            labelAwardDate.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelAwardDate.ForeColor = Color.Black;
            labelAwardDate.Location = new Point(32, 292);
            labelAwardDate.Margin = new Padding(4, 0, 4, 0);
            labelAwardDate.Name = "labelAwardDate";
            labelAwardDate.Size = new Size(200, 28);
            labelAwardDate.TabIndex = 8;
            labelAwardDate.Text = "Дата награждения:";
            // 
            // dateTimePickerAwardDate
            // 
            dateTimePickerAwardDate.Font = new Font("Segoe UI", 15F);
            dateTimePickerAwardDate.Location = new Point(237, 287);
            dateTimePickerAwardDate.Name = "dateTimePickerAwardDate";
            dateTimePickerAwardDate.Size = new Size(455, 34);
            dateTimePickerAwardDate.TabIndex = 2;
            // 
            // comboBoxVeteranIDVeteranMedals
            // 
            comboBoxVeteranIDVeteranMedals.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVeteranIDVeteranMedals.Font = new Font("Segoe UI", 14.25F);
            comboBoxVeteranIDVeteranMedals.FormattingEnabled = true;
            comboBoxVeteranIDVeteranMedals.Location = new Point(239, 185);
            comboBoxVeteranIDVeteranMedals.Name = "comboBoxVeteranIDVeteranMedals";
            comboBoxVeteranIDVeteranMedals.Size = new Size(453, 33);
            comboBoxVeteranIDVeteranMedals.TabIndex = 0;
            // 
            // comboBoxMedalIDVeteranMedals
            // 
            comboBoxMedalIDVeteranMedals.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMedalIDVeteranMedals.Font = new Font("Segoe UI", 14.25F);
            comboBoxMedalIDVeteranMedals.FormattingEnabled = true;
            comboBoxMedalIDVeteranMedals.Location = new Point(239, 237);
            comboBoxMedalIDVeteranMedals.Name = "comboBoxMedalIDVeteranMedals";
            comboBoxMedalIDVeteranMedals.Size = new Size(453, 33);
            comboBoxMedalIDVeteranMedals.TabIndex = 1;
            // 
            // AddFormVeteranMedals
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(884, 461);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelVeteranIDVeteranMedals);
            Controls.Add(comboBoxVeteranIDVeteranMedals);
            Controls.Add(labelMedalIDVeteranMedals);
            Controls.Add(comboBoxMedalIDVeteranMedals);
            Controls.Add(labelAwardDate);
            Controls.Add(dateTimePickerAwardDate);
            Controls.Add(buttonSave);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormVeteranMedals";
            Text = "Добавить награду ветерана";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelVeteranIDVeteranMedals;
        private Label labelMedalIDVeteranMedals;
        private Label labelAwardDate;
        private DateTimePicker dateTimePickerAwardDate;
        private ComboBox comboBoxVeteranIDVeteranMedals;
        private ComboBox comboBoxMedalIDVeteranMedals;
    }
}