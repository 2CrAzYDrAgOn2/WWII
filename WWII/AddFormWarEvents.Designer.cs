namespace WWII
{
    partial class AddFormWarEvents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormWarEvents));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelEventName = new Label();
            textBoxEventName = new TextBox();
            labelEventDate = new Label();
            dateTimePickerEventDate = new DateTimePicker();
            labelEventLocation = new Label();
            textBoxEventLocation = new TextBox();
            labelDescriptionWarEvents = new Label();
            textBoxDescriptionWarEvents = new TextBox();
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
            labelTitle.TabIndex = 5;
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
            label1.Size = new Size(135, 21);
            label1.TabIndex = 6;
            label1.Text = "Событие войны";
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
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelEventName
            // 
            labelEventName.AutoSize = true;
            labelEventName.ForeColor = Color.Black;
            labelEventName.Location = new Point(188, 506);
            labelEventName.Margin = new Padding(4, 0, 4, 0);
            labelEventName.Name = "labelEventName";
            labelEventName.Size = new Size(93, 15);
            labelEventName.TabIndex = 7;
            labelEventName.Text = "Наименование:";
            // 
            // textBoxEventName
            // 
            textBoxEventName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEventName.Location = new Point(292, 495);
            textBoxEventName.Margin = new Padding(4, 3, 4, 3);
            textBoxEventName.Name = "textBoxEventName";
            textBoxEventName.Size = new Size(455, 33);
            textBoxEventName.TabIndex = 0;
            // 
            // labelEventDate
            // 
            labelEventDate.AutoSize = true;
            labelEventDate.ForeColor = Color.Black;
            labelEventDate.Location = new Point(246, 554);
            labelEventDate.Margin = new Padding(4, 0, 4, 0);
            labelEventDate.Name = "labelEventDate";
            labelEventDate.Size = new Size(35, 15);
            labelEventDate.TabIndex = 8;
            labelEventDate.Text = "Дата:";
            // 
            // dateTimePickerEventDate
            // 
            dateTimePickerEventDate.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerEventDate.Location = new Point(292, 540);
            dateTimePickerEventDate.Name = "dateTimePickerEventDate";
            dateTimePickerEventDate.Size = new Size(455, 33);
            dateTimePickerEventDate.TabIndex = 1;
            // 
            // labelEventLocation
            // 
            labelEventLocation.AutoSize = true;
            labelEventLocation.ForeColor = Color.Black;
            labelEventLocation.Location = new Point(173, 599);
            labelEventLocation.Margin = new Padding(4, 0, 4, 0);
            labelEventLocation.Name = "labelEventLocation";
            labelEventLocation.Size = new Size(108, 15);
            labelEventLocation.TabIndex = 9;
            labelEventLocation.Text = "Местоположение:";
            // 
            // textBoxEventLocation
            // 
            textBoxEventLocation.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEventLocation.Location = new Point(292, 588);
            textBoxEventLocation.Margin = new Padding(4, 3, 4, 3);
            textBoxEventLocation.Name = "textBoxEventLocation";
            textBoxEventLocation.Size = new Size(455, 33);
            textBoxEventLocation.TabIndex = 2;
            // 
            // labelDescriptionWarEvents
            // 
            labelDescriptionWarEvents.AutoSize = true;
            labelDescriptionWarEvents.ForeColor = Color.Black;
            labelDescriptionWarEvents.Location = new Point(221, 644);
            labelDescriptionWarEvents.Margin = new Padding(4, 0, 4, 0);
            labelDescriptionWarEvents.Name = "labelDescriptionWarEvents";
            labelDescriptionWarEvents.Size = new Size(65, 15);
            labelDescriptionWarEvents.TabIndex = 10;
            labelDescriptionWarEvents.Text = "Описание:";
            // 
            // textBoxDescriptionWarEvents
            // 
            textBoxDescriptionWarEvents.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxDescriptionWarEvents.Location = new Point(292, 633);
            textBoxDescriptionWarEvents.Margin = new Padding(4, 3, 4, 3);
            textBoxDescriptionWarEvents.Name = "textBoxDescriptionWarEvents";
            textBoxDescriptionWarEvents.Size = new Size(455, 33);
            textBoxDescriptionWarEvents.TabIndex = 3;
            // 
            // AddFormWarEvents
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelEventName);
            Controls.Add(textBoxEventName);
            Controls.Add(labelEventDate);
            Controls.Add(dateTimePickerEventDate);
            Controls.Add(labelEventLocation);
            Controls.Add(textBoxEventLocation);
            Controls.Add(labelDescriptionWarEvents);
            Controls.Add(textBoxDescriptionWarEvents);
            Controls.Add(buttonSave);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormWarEvents";
            Text = "Добавить событие войны";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelEventName;
        private TextBox textBoxEventName;
        private Label labelEventDate;
        private DateTimePicker dateTimePickerEventDate;
        private Label labelEventLocation;
        private TextBox textBoxEventLocation;
        private Label labelDescriptionWarEvents;
        private TextBox textBoxDescriptionWarEvents;
    }
}