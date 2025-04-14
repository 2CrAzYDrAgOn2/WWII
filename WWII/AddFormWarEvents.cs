using System.Data.SqlClient;

namespace WWII
{
    public partial class AddFormWarEvents : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormWarEvents()
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
                var eventName = textBoxEventName.Text;
                var eventDate = dateTimePickerEventDate.Value.ToString("yyyy-MM-dd");
                var eventLocation = textBoxEventLocation.Text;
                var description = textBoxDescriptionWarEvents.Text;
                string addQuery = $"INSERT INTO WarEvents (EventName, EventDate, EventLocation, Description) VALUES ('{eventName}', '{eventDate}', '{eventLocation}', '{description}')";
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