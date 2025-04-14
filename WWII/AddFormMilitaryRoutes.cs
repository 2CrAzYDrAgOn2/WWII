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
    public partial class AddFormMilitaryRoutes : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormMilitaryRoutes()
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
                var routeName = textBoxRouteName.Text;
                var startLocation = textBoxStartLocation.Text;
                var endLocation = textBoxEndLocation.Text;
                var description = textBoxDescriptionMilitaryRoutes.Text;
                string addQuery = $"INSERT INTO MilitaryRoutes (RouteName, StartLocation, EndLocation, Description) VALUES ('{routeName}', '{startLocation}', '{endLocation}', '{description}')";
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