namespace WWII
{
    partial class AddFormMilitaryEquipment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormMilitaryEquipment));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelEquipmentName = new Label();
            textBoxEquipmentName = new TextBox();
            labelEquipmentType = new Label();
            textBoxEquipmentType = new TextBox();
            labelDescriptionMilitaryEquipment = new Label();
            textBoxDescriptionMilitaryEquipment = new TextBox();
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
            label1.Size = new Size(287, 45);
            label1.TabIndex = 5;
            label1.Text = "Военная техника";
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
            // labelEquipmentName
            // 
            labelEquipmentName.AutoSize = true;
            labelEquipmentName.BackColor = Color.Transparent;
            labelEquipmentName.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelEquipmentName.ForeColor = Color.Black;
            labelEquipmentName.Location = new Point(63, 185);
            labelEquipmentName.Margin = new Padding(4, 0, 4, 0);
            labelEquipmentName.Name = "labelEquipmentName";
            labelEquipmentName.Size = new Size(166, 28);
            labelEquipmentName.TabIndex = 6;
            labelEquipmentName.Text = "Наименование:";
            // 
            // textBoxEquipmentName
            // 
            textBoxEquipmentName.Font = new Font("Segoe UI", 15F);
            textBoxEquipmentName.Location = new Point(237, 182);
            textBoxEquipmentName.Margin = new Padding(4, 3, 4, 3);
            textBoxEquipmentName.Name = "textBoxEquipmentName";
            textBoxEquipmentName.Size = new Size(455, 34);
            textBoxEquipmentName.TabIndex = 0;
            // 
            // labelEquipmentType
            // 
            labelEquipmentType.AutoSize = true;
            labelEquipmentType.BackColor = Color.Transparent;
            labelEquipmentType.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelEquipmentType.ForeColor = Color.Black;
            labelEquipmentType.Location = new Point(90, 237);
            labelEquipmentType.Margin = new Padding(4, 0, 4, 0);
            labelEquipmentType.Name = "labelEquipmentType";
            labelEquipmentType.Size = new Size(139, 28);
            labelEquipmentType.TabIndex = 7;
            labelEquipmentType.Text = "Тип техники:";
            // 
            // textBoxEquipmentType
            // 
            textBoxEquipmentType.Font = new Font("Segoe UI", 15F);
            textBoxEquipmentType.Location = new Point(237, 234);
            textBoxEquipmentType.Margin = new Padding(4, 3, 4, 3);
            textBoxEquipmentType.Name = "textBoxEquipmentType";
            textBoxEquipmentType.Size = new Size(455, 34);
            textBoxEquipmentType.TabIndex = 1;
            // 
            // labelDescriptionMilitaryEquipment
            // 
            labelDescriptionMilitaryEquipment.AutoSize = true;
            labelDescriptionMilitaryEquipment.BackColor = Color.Transparent;
            labelDescriptionMilitaryEquipment.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelDescriptionMilitaryEquipment.ForeColor = Color.Black;
            labelDescriptionMilitaryEquipment.Location = new Point(115, 290);
            labelDescriptionMilitaryEquipment.Margin = new Padding(4, 0, 4, 0);
            labelDescriptionMilitaryEquipment.Name = "labelDescriptionMilitaryEquipment";
            labelDescriptionMilitaryEquipment.Size = new Size(114, 28);
            labelDescriptionMilitaryEquipment.TabIndex = 8;
            labelDescriptionMilitaryEquipment.Text = "Описание:";
            // 
            // textBoxDescriptionMilitaryEquipment
            // 
            textBoxDescriptionMilitaryEquipment.Font = new Font("Segoe UI", 15F);
            textBoxDescriptionMilitaryEquipment.Location = new Point(237, 287);
            textBoxDescriptionMilitaryEquipment.Margin = new Padding(4, 3, 4, 3);
            textBoxDescriptionMilitaryEquipment.Name = "textBoxDescriptionMilitaryEquipment";
            textBoxDescriptionMilitaryEquipment.Size = new Size(455, 34);
            textBoxDescriptionMilitaryEquipment.TabIndex = 2;
            // 
            // AddFormMilitaryEquipment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(884, 461);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelEquipmentName);
            Controls.Add(textBoxEquipmentName);
            Controls.Add(labelEquipmentType);
            Controls.Add(textBoxEquipmentType);
            Controls.Add(labelDescriptionMilitaryEquipment);
            Controls.Add(textBoxDescriptionMilitaryEquipment);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormMilitaryEquipment";
            Text = "Добавить военную технику";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelEquipmentName;
        private TextBox textBoxEquipmentName;
        private Label labelEquipmentType;
        private TextBox textBoxEquipmentType;
        private Label labelDescriptionMilitaryEquipment;
        private TextBox textBoxDescriptionMilitaryEquipment;
    }
}