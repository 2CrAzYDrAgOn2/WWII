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
            labelOrderIDOrderDetails = new Label();
            textBoxOrderIDOrderDetails = new TextBox();
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
            labelTitle.TabIndex = 3;
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
            label1.TabIndex = 4;
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
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelOrderIDOrderDetails
            // 
            labelOrderIDOrderDetails.AutoSize = true;
            labelOrderIDOrderDetails.BackColor = Color.Transparent;
            labelOrderIDOrderDetails.ForeColor = Color.Black;
            labelOrderIDOrderDetails.Location = new Point(195, 500);
            labelOrderIDOrderDetails.Margin = new Padding(4, 0, 4, 0);
            labelOrderIDOrderDetails.Name = "labelOrderIDOrderDetails";
            labelOrderIDOrderDetails.Size = new Size(85, 15);
            labelOrderIDOrderDetails.TabIndex = 5;
            labelOrderIDOrderDetails.Text = "Номер заказа:";
            // 
            // textBoxOrderIDOrderDetails
            // 
            textBoxOrderIDOrderDetails.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOrderIDOrderDetails.Location = new Point(291, 489);
            textBoxOrderIDOrderDetails.Margin = new Padding(4, 3, 4, 3);
            textBoxOrderIDOrderDetails.Name = "textBoxOrderIDOrderDetails";
            textBoxOrderIDOrderDetails.Size = new Size(455, 33);
            textBoxOrderIDOrderDetails.TabIndex = 0;
            // 
            // AddFormVeteranMedals
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelOrderIDOrderDetails);
            Controls.Add(textBoxOrderIDOrderDetails);
            Controls.Add(buttonSave);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddFormVeteranMedals";
            Text = "Добавить награду ветерана";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelOrderIDOrderDetails;
        private TextBox textBoxOrderIDOrderDetails;
    }
}