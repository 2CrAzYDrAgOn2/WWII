using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WWII
{
    public partial class AddFormVeterans : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormVeterans()
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
                var fullName = textBoxFullName.Text;
                var birthDate = dateTimePickerBirthDate.Value.ToString("yyyy-MM-dd");
                var deathDate = dateTimePickerDeathDate.Value.ToString("yyyy-MM-dd");
                var militaryRank = textBoxMilitaryRank.Text;
                var unitName = textBoxUnitID.Text;
                string query = $"SELECT MilitaryUnitID FROM MilitaryUnits WHERE UnitName = '{unitName}'";
                SqlCommand command = new(query, dataBase.GetConnection());
                object result = command.ExecuteScalar();
                var unitID = result.ToString();
                string addQuery = $"INSERT INTO Veterans (FullName, BirthDate, DeathDate, MilitaryRank, UnitID) VALUES ('{fullName}', '{birthDate}', '{deathDate}', '{militaryRank}', '{unitID}')";
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