using System.Data.SqlClient;

namespace WWII
{
    public partial class AddFormVeteranMedals : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormVeteranMedals()
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
                var veteranName = textBoxVeteranIDVeteranMedals.Text;
                var medalName = textBoxMedalIDVeteranMedals.Text;
                var awardDate = dateTimePickerAwardDate.Value.ToString("yyyy-MM-dd");
                string veteranQuery = $"SELECT VeteranID FROM Veterans WHERE FullName = '{veteranName}'";
                SqlCommand veteranCommand = new(veteranQuery, dataBase.GetConnection());
                object veteranResult = veteranCommand.ExecuteScalar();
                var veteranID = veteranResult.ToString();
                string medalQuery = $"SELECT MedalID FROM Medals WHERE MedalName = '{medalName}'";
                SqlCommand medalCommand = new(medalQuery, dataBase.GetConnection());
                object medalResult = medalCommand.ExecuteScalar();
                var medalID = medalResult.ToString();
                string addQuery = $"INSERT INTO VeteranMedals (VeteranID, MedalID, AwardDate) VALUES ('{veteranID}', '{medalID}', '{awardDate}')";
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