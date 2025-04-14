using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Diagnostics;

namespace WWII
{
    public partial class AddFormMedals : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormMedals()
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
                var medalName = textBoxMedalName.Text;
                var description = textBoxDescriptionMedals.Text;
                string addQuery = $"INSERT INTO Medals (MedalName, Description) VALUES ('{medalName}', '{description}')";
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