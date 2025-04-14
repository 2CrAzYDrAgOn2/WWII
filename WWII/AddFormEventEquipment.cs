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
    public partial class AddFormEventEquipment : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormEventEquipment()
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
                var eventName = textBoxEventIDEventEquipment.Text;
                var equipmentName = textBoxEquipmentIDEventEquipment.Text;
                string eventQuery = $"SELECT WarEventID FROM WarEvents WHERE EventName = '{eventName}'";
                SqlCommand eventCommand = new(eventQuery, dataBase.GetConnection());
                object eventResult = eventCommand.ExecuteScalar();
                var eventID = eventResult.ToString();
                string equipmentQuery = $"SELECT MilitaryEquipmentID FROM MilitaryEquipment WHERE EquipmentName = '{equipmentName}'";
                SqlCommand equipmentCommand = new(equipmentQuery, dataBase.GetConnection());
                object equipmentResult = equipmentCommand.ExecuteScalar();
                var equipmentID = equipmentResult.ToString();
                string addQuery = $"INSERT INTO EventEquipment (EventID, EquipmentID) VALUES ('{eventID}', '{equipmentID}')";
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