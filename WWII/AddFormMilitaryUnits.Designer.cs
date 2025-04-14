namespace WWII
{
    partial class AddFormMilitaryUnits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormMilitaryUnits));
            buttonSave = new Button();
            labelTitle = new Label();
            label1 = new Label();
            labelUnitName = new Label();
            textBoxUnitName = new TextBox();
            labelDescriptionMilitaryUnits = new Label();
            textBoxDescriptionMilitaryUnits = new TextBox();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(330, 763);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 65);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(243, 10);
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
            label1.Location = new Point(244, 39);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(149, 21);
            label1.TabIndex = 4;
            label1.Text = "Военная единица";
            // 
            // labelUnitName
            // 
            labelUnitName.AutoSize = true;
            labelUnitName.BackColor = Color.Transparent;
            labelUnitName.ForeColor = Color.Black;
            labelUnitName.Location = new Point(193, 456);
            labelUnitName.Margin = new Padding(4, 0, 4, 0);
            labelUnitName.Name = "labelUnitName";
            labelUnitName.Size = new Size(93, 15);
            labelUnitName.TabIndex = 5;
            labelUnitName.Text = "Наименование:";
            // 
            // textBoxUnitName
            // 
            textBoxUnitName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxUnitName.Location = new Point(292, 445);
            textBoxUnitName.Margin = new Padding(4, 3, 4, 3);
            textBoxUnitName.Name = "textBoxUnitName";
            textBoxUnitName.Size = new Size(455, 33);
            textBoxUnitName.TabIndex = 0;
            // 
            // labelDescriptionMilitaryUnits
            // 
            labelDescriptionMilitaryUnits.AutoSize = true;
            labelDescriptionMilitaryUnits.ForeColor = Color.Black;
            labelDescriptionMilitaryUnits.Location = new Point(219, 501);
            labelDescriptionMilitaryUnits.Margin = new Padding(4, 0, 4, 0);
            labelDescriptionMilitaryUnits.Name = "labelDescriptionMilitaryUnits";
            labelDescriptionMilitaryUnits.Size = new Size(65, 15);
            labelDescriptionMilitaryUnits.TabIndex = 6;
            labelDescriptionMilitaryUnits.Text = "Описание:";
            // 
            // textBoxDescriptionMilitaryUnits
            // 
            textBoxDescriptionMilitaryUnits.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxDescriptionMilitaryUnits.Location = new Point(292, 490);
            textBoxDescriptionMilitaryUnits.Margin = new Padding(4, 3, 4, 3);
            textBoxDescriptionMilitaryUnits.Name = "textBoxDescriptionMilitaryUnits";
            textBoxDescriptionMilitaryUnits.Size = new Size(455, 33);
            textBoxDescriptionMilitaryUnits.TabIndex = 1;
            // 
            // AddFormMilitaryUnits
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelUnitName);
            Controls.Add(textBoxUnitName);
            Controls.Add(labelDescriptionMilitaryUnits);
            Controls.Add(textBoxDescriptionMilitaryUnits);
            Controls.Add(buttonSave);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormMilitaryUnits";
            Text = "Добавить военную единицу";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private Label labelUnitName;
        private TextBox textBoxUnitName;
        private Label labelDescriptionMilitaryUnits;
        private TextBox textBoxDescriptionMilitaryUnits;
    }
}