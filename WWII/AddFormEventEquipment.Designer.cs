namespace WWII
{
    partial class AddFormEventEquipment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormEventEquipment));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelEventIDEventEquipment = new Label();
            textBoxEventIDEventEquipment = new TextBox();
            labelEquipmentIDEventEquipment = new Label();
            textBoxEquipmentIDEventEquipment = new TextBox();
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
            label1.Size = new Size(294, 45);
            label1.TabIndex = 4;
            label1.Text = "Событие техники";
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
            // labelEventIDEventEquipment
            // 
            labelEventIDEventEquipment.AutoSize = true;
            labelEventIDEventEquipment.BackColor = Color.Transparent;
            labelEventIDEventEquipment.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelEventIDEventEquipment.ForeColor = Color.Black;
            labelEventIDEventEquipment.Location = new Point(117, 187);
            labelEventIDEventEquipment.Margin = new Padding(4, 0, 4, 0);
            labelEventIDEventEquipment.Name = "labelEventIDEventEquipment";
            labelEventIDEventEquipment.Size = new Size(102, 28);
            labelEventIDEventEquipment.TabIndex = 5;
            labelEventIDEventEquipment.Text = "Событие:";
            // 
            // textBoxEventIDEventEquipment
            // 
            textBoxEventIDEventEquipment.Font = new Font("Segoe UI", 15F);
            textBoxEventIDEventEquipment.Location = new Point(227, 184);
            textBoxEventIDEventEquipment.Margin = new Padding(4, 3, 4, 3);
            textBoxEventIDEventEquipment.Name = "textBoxEventIDEventEquipment";
            textBoxEventIDEventEquipment.Size = new Size(455, 34);
            textBoxEventIDEventEquipment.TabIndex = 0;
            // 
            // labelEquipmentIDEventEquipment
            // 
            labelEquipmentIDEventEquipment.AutoSize = true;
            labelEquipmentIDEventEquipment.BackColor = Color.Transparent;
            labelEquipmentIDEventEquipment.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelEquipmentIDEventEquipment.ForeColor = Color.Black;
            labelEquipmentIDEventEquipment.Location = new Point(58, 239);
            labelEquipmentIDEventEquipment.Margin = new Padding(4, 0, 4, 0);
            labelEquipmentIDEventEquipment.Name = "labelEquipmentIDEventEquipment";
            labelEquipmentIDEventEquipment.Size = new Size(161, 28);
            labelEquipmentIDEventEquipment.TabIndex = 6;
            labelEquipmentIDEventEquipment.Text = "Оборудование:";
            // 
            // textBoxEquipmentIDEventEquipment
            // 
            textBoxEquipmentIDEventEquipment.Font = new Font("Segoe UI", 15F);
            textBoxEquipmentIDEventEquipment.Location = new Point(227, 236);
            textBoxEquipmentIDEventEquipment.Margin = new Padding(4, 3, 4, 3);
            textBoxEquipmentIDEventEquipment.Name = "textBoxEquipmentIDEventEquipment";
            textBoxEquipmentIDEventEquipment.Size = new Size(455, 34);
            textBoxEquipmentIDEventEquipment.TabIndex = 1;
            // 
            // AddFormEventEquipment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(884, 431);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelEventIDEventEquipment);
            Controls.Add(textBoxEventIDEventEquipment);
            Controls.Add(labelEquipmentIDEventEquipment);
            Controls.Add(textBoxEquipmentIDEventEquipment);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormEventEquipment";
            Text = "Добавить событие техники";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelEventIDEventEquipment;
        private TextBox textBoxEventIDEventEquipment;
        private Label labelEquipmentIDEventEquipment;
        private TextBox textBoxEquipmentIDEventEquipment;
    }
}