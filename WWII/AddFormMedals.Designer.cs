namespace WWII
{
    partial class AddFormMedals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormMedals));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelMedalName = new Label();
            textBoxMedalName = new TextBox();
            labelDescriptionMedals = new Label();
            textBoxDescriptionMedals = new TextBox();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(244, 9);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(175, 25);
            labelTitle.TabIndex = 3;
            labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(245, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(72, 21);
            label1.TabIndex = 4;
            label1.Text = "Медаль";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(331, 762);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 65);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelMedalName
            // 
            labelMedalName.AutoSize = true;
            labelMedalName.ForeColor = Color.Black;
            labelMedalName.Location = new Point(189, 500);
            labelMedalName.Margin = new Padding(4, 0, 4, 0);
            labelMedalName.Name = "labelMedalName";
            labelMedalName.Size = new Size(93, 15);
            labelMedalName.TabIndex = 5;
            labelMedalName.Text = "Наименование:";
            // 
            // textBoxMedalName
            // 
            textBoxMedalName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxMedalName.Location = new Point(293, 489);
            textBoxMedalName.Margin = new Padding(4, 3, 4, 3);
            textBoxMedalName.Name = "textBoxMedalName";
            textBoxMedalName.Size = new Size(455, 33);
            textBoxMedalName.TabIndex = 0;
            // 
            // labelDescriptionMedals
            // 
            labelDescriptionMedals.AutoSize = true;
            labelDescriptionMedals.ForeColor = Color.Black;
            labelDescriptionMedals.Location = new Point(217, 545);
            labelDescriptionMedals.Margin = new Padding(4, 0, 4, 0);
            labelDescriptionMedals.Name = "labelDescriptionMedals";
            labelDescriptionMedals.Size = new Size(65, 15);
            labelDescriptionMedals.TabIndex = 6;
            labelDescriptionMedals.Text = "Описание:";
            // 
            // textBoxDescriptionMedals
            // 
            textBoxDescriptionMedals.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxDescriptionMedals.Location = new Point(293, 534);
            textBoxDescriptionMedals.Margin = new Padding(4, 3, 4, 3);
            textBoxDescriptionMedals.Name = "textBoxDescriptionMedals";
            textBoxDescriptionMedals.Size = new Size(455, 33);
            textBoxDescriptionMedals.TabIndex = 1;
            // 
            // AddFormMedals
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelMedalName);
            Controls.Add(textBoxMedalName);
            Controls.Add(labelDescriptionMedals);
            Controls.Add(textBoxDescriptionMedals);
            Controls.Add(buttonSave);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormMedals";
            Text = "Добавить медаль";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelMedalName;
        private TextBox textBoxMedalName;
        private Label labelDescriptionMedals;
        private TextBox textBoxDescriptionMedals;
    }
}