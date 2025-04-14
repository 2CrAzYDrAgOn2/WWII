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
            textBoxVeteranIDVeteranMedals = new TextBox();
            labelMedalIDVeteranMedals = new Label();
            textBoxMedalIDVeteranMedals = new TextBox();
            labelAwardDate = new Label();
            dateTimePickerAwardDate = new DateTimePicker();
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
            labelTitle.TabIndex = 4;
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
            label1.Size = new Size(152, 21);
            label1.TabIndex = 5;
            label1.Text = "Награда ветерана";
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
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelVeteranIDVeteranMedals
            // 
            labelVeteranIDVeteranMedals.AutoSize = true;
            labelVeteranIDVeteranMedals.ForeColor = Color.Black;
            labelVeteranIDVeteranMedals.Location = new Point(226, 500);
            labelVeteranIDVeteranMedals.Margin = new Padding(4, 0, 4, 0);
            labelVeteranIDVeteranMedals.Name = "labelVeteranIDVeteranMedals";
            labelVeteranIDVeteranMedals.Size = new Size(54, 15);
            labelVeteranIDVeteranMedals.TabIndex = 6;
            labelVeteranIDVeteranMedals.Text = "Ветеран:";
            // 
            // textBoxVeteranIDVeteranMedals
            // 
            textBoxVeteranIDVeteranMedals.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxVeteranIDVeteranMedals.Location = new Point(291, 489);
            textBoxVeteranIDVeteranMedals.Margin = new Padding(4, 3, 4, 3);
            textBoxVeteranIDVeteranMedals.Name = "textBoxVeteranIDVeteranMedals";
            textBoxVeteranIDVeteranMedals.Size = new Size(455, 33);
            textBoxVeteranIDVeteranMedals.TabIndex = 0;
            // 
            // labelMedalIDVeteranMedals
            // 
            labelMedalIDVeteranMedals.AutoSize = true;
            labelMedalIDVeteranMedals.ForeColor = Color.Black;
            labelMedalIDVeteranMedals.Location = new Point(228, 545);
            labelMedalIDVeteranMedals.Margin = new Padding(4, 0, 4, 0);
            labelMedalIDVeteranMedals.Name = "labelMedalIDVeteranMedals";
            labelMedalIDVeteranMedals.Size = new Size(52, 15);
            labelMedalIDVeteranMedals.TabIndex = 7;
            labelMedalIDVeteranMedals.Text = "Медаль:";
            // 
            // textBoxMedalIDVeteranMedals
            // 
            textBoxMedalIDVeteranMedals.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxMedalIDVeteranMedals.Location = new Point(291, 534);
            textBoxMedalIDVeteranMedals.Margin = new Padding(4, 3, 4, 3);
            textBoxMedalIDVeteranMedals.Name = "textBoxMedalIDVeteranMedals";
            textBoxMedalIDVeteranMedals.Size = new Size(455, 33);
            textBoxMedalIDVeteranMedals.TabIndex = 1;
            // 
            // labelAwardDate
            // 
            labelAwardDate.AutoSize = true;
            labelAwardDate.ForeColor = Color.Black;
            labelAwardDate.Location = new Point(170, 593);
            labelAwardDate.Margin = new Padding(4, 0, 4, 0);
            labelAwardDate.Name = "labelAwardDate";
            labelAwardDate.Size = new Size(110, 15);
            labelAwardDate.TabIndex = 8;
            labelAwardDate.Text = "Дата награждения:";
            // 
            // dateTimePickerAwardDate
            // 
            dateTimePickerAwardDate.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerAwardDate.Location = new Point(291, 579);
            dateTimePickerAwardDate.Name = "dateTimePickerAwardDate";
            dateTimePickerAwardDate.Size = new Size(455, 33);
            dateTimePickerAwardDate.TabIndex = 2;
            // 
            // AddFormVeteranMedals
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelVeteranIDVeteranMedals);
            Controls.Add(textBoxVeteranIDVeteranMedals);
            Controls.Add(labelMedalIDVeteranMedals);
            Controls.Add(textBoxMedalIDVeteranMedals);
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
        private TextBox textBoxVeteranIDVeteranMedals;
        private Label labelMedalIDVeteranMedals;
        private TextBox textBoxMedalIDVeteranMedals;
        private Label labelAwardDate;
        private DateTimePicker dateTimePickerAwardDate;
    }
}