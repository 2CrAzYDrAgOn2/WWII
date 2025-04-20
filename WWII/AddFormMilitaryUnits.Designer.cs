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
            buttonSave.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(333, 314);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 55);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
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
            labelTitle.TabIndex = 3;
            labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(297, 97);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(297, 45);
            label1.TabIndex = 4;
            label1.Text = "Военная единица";
            // 
            // labelUnitName
            // 
            labelUnitName.AutoSize = true;
            labelUnitName.BackColor = Color.Transparent;
            labelUnitName.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelUnitName.ForeColor = Color.Black;
            labelUnitName.Location = new Point(53, 187);
            labelUnitName.Margin = new Padding(4, 0, 4, 0);
            labelUnitName.Name = "labelUnitName";
            labelUnitName.Size = new Size(166, 28);
            labelUnitName.TabIndex = 5;
            labelUnitName.Text = "Наименование:";
            // 
            // textBoxUnitName
            // 
            textBoxUnitName.Font = new Font("Segoe UI", 15F);
            textBoxUnitName.Location = new Point(227, 184);
            textBoxUnitName.Margin = new Padding(4, 3, 4, 3);
            textBoxUnitName.Name = "textBoxUnitName";
            textBoxUnitName.Size = new Size(455, 34);
            textBoxUnitName.TabIndex = 0;
            // 
            // labelDescriptionMilitaryUnits
            // 
            labelDescriptionMilitaryUnits.AutoSize = true;
            labelDescriptionMilitaryUnits.BackColor = Color.Transparent;
            labelDescriptionMilitaryUnits.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelDescriptionMilitaryUnits.ForeColor = Color.Black;
            labelDescriptionMilitaryUnits.Location = new Point(105, 239);
            labelDescriptionMilitaryUnits.Margin = new Padding(4, 0, 4, 0);
            labelDescriptionMilitaryUnits.Name = "labelDescriptionMilitaryUnits";
            labelDescriptionMilitaryUnits.Size = new Size(114, 28);
            labelDescriptionMilitaryUnits.TabIndex = 6;
            labelDescriptionMilitaryUnits.Text = "Описание:";
            // 
            // textBoxDescriptionMilitaryUnits
            // 
            textBoxDescriptionMilitaryUnits.Font = new Font("Segoe UI", 15F);
            textBoxDescriptionMilitaryUnits.Location = new Point(227, 236);
            textBoxDescriptionMilitaryUnits.Margin = new Padding(4, 3, 4, 3);
            textBoxDescriptionMilitaryUnits.Name = "textBoxDescriptionMilitaryUnits";
            textBoxDescriptionMilitaryUnits.Size = new Size(455, 34);
            textBoxDescriptionMilitaryUnits.TabIndex = 1;
            // 
            // AddFormMilitaryUnits
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(884, 431);
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