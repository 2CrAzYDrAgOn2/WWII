using System.Data.SqlClient;

namespace WWII
{
    public partial class AddFormMilitaryUnits : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormMilitaryUnits()
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
                var unitName = textBoxUnitName.Text;
                var description = textBoxDescriptionMilitaryUnits.Text;
                string addQuery = $"INSERT INTO MilitaryUnits (UnitName, Description) VALUES ('{unitName}', '{description}')";
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