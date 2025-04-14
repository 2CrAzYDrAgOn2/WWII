using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WWII
{
    public partial class AddFormMilitaryEquipment : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormMilitaryEquipment()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// ButtonSave_Click() вызывается при нажатии на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.OpenConnection();
                var equipmentName = textBoxEquipmentName.Text;
                var equipmentType = textBoxEquipmentType.Text;
                var description = textBoxDescriptionMilitaryEquipment.Text;
                string addQuery = $"INSERT INTO MilitaryEquipment (EquipmentName, EquipmentType, Description) VALUES ('{equipmentName}', '{equipmentType}', '{description}')";
                var sqlCommand = new SqlCommand(addQuery, dataBase.GetConnection());
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataBase.CloseConnection();
            }
        }
    }
}