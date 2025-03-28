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
            labelName = new Label();
            textBoxName = new TextBox();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(245, 9);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(175, 25);
            labelTitle.TabIndex = 9;
            labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(246, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(144, 21);
            label1.TabIndex = 10;
            label1.Text = "Военная техника";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.BackColor = Color.Transparent;
            labelName.ForeColor = Color.Black;
            labelName.Location = new Point(190, 500);
            labelName.Margin = new Padding(4, 0, 4, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(93, 15);
            labelName.TabIndex = 11;
            labelName.Text = "Наименование:";
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxName.Location = new Point(294, 489);
            textBoxName.Margin = new Padding(4, 3, 4, 3);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(455, 33);
            textBoxName.TabIndex = 7;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(332, 762);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 65);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // AddFormMilitaryEquipment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(buttonSave);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddFormMilitaryEquipment";
            Text = "Добавить военную технику";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Label labelName;
        private TextBox textBoxName;
        private Button buttonSave;
    }
}