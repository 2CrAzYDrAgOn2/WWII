using Microsoft.Office.Interop.Word;
using System.Data.SqlClient;
using System.Diagnostics;
using Application = Microsoft.Office.Interop.Word.Application;
using Excel = Microsoft.Office.Interop.Excel;

namespace WWII
{
    internal enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Form1 : Form
    {
        private readonly DataBase dataBase = new();
        private readonly bool admin;
        private int selectedRow;
        private System.Windows.Forms.Timer? timer;
        private NotifyIcon? notifyIcon;

        public Form1(bool admin)
        {
            try
            {
                this.admin = admin;
                InitializeComponent();
                StartPosition = FormStartPosition.CenterScreen;
                InitializeNotifyIcon();
                InitializeTimer();
                ClearFields();
                ShowBalloonTip();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// CreateColumns() вызывается при создании колонок
        /// </summary>
        private void CreateColumns()
        {
            try
            {
                dataGridViewMilitaryUnits.Columns.Add("MilitaryUnitID", "Номер");
                dataGridViewMilitaryUnits.Columns.Add("UnitName", "Наименование");
                dataGridViewMilitaryUnits.Columns.Add("Description", "Описание");
                dataGridViewMilitaryUnits.Columns.Add("IsNew", String.Empty);
                dataGridViewWarEvents.Columns.Add("WarEventID", "Номер");
                dataGridViewWarEvents.Columns.Add("EventName", "Наименование");
                dataGridViewWarEvents.Columns.Add("EventDate", "Дата");
                dataGridViewWarEvents.Columns.Add("EventLocation", "Местоположение");
                dataGridViewWarEvents.Columns.Add("Description", "Описание");
                dataGridViewWarEvents.Columns.Add("IsNew", String.Empty);
                dataGridViewVeterans.Columns.Add("VeteranID", "Номер");
                dataGridViewVeterans.Columns.Add("FullName", "ФИО");
                dataGridViewVeterans.Columns.Add("BirthDate", "Дата рождения");
                dataGridViewVeterans.Columns.Add("DeathDate", "Дата смерти");
                dataGridViewVeterans.Columns.Add("MilitaryRank", "Воинское звание");
                dataGridViewVeterans.Columns.Add("UnitID", "ID воинской части");
                dataGridViewVeterans.Columns.Add("IsNew", String.Empty);
                dataGridViewMedals.Columns.Add("MedalID", "Номер");
                dataGridViewMedals.Columns.Add("MedalName", "Наименование");
                dataGridViewMedals.Columns.Add("Description", "Описание");
                dataGridViewMedals.Columns.Add("IsNew", String.Empty);
                dataGridViewVeteranMedals.Columns.Add("VeteranMedalID", "Номер");
                dataGridViewVeteranMedals.Columns.Add("VeteranID", "ID ветерана");
                dataGridViewVeteranMedals.Columns.Add("MedalID", "ID медали");
                dataGridViewVeteranMedals.Columns.Add("AwardDate", "Дата награждения");
                dataGridViewVeteranMedals.Columns.Add("IsNew", String.Empty);
                dataGridViewMilitaryEquipment.Columns.Add("MilitaryEquipmentID", "Номер");
                dataGridViewMilitaryEquipment.Columns.Add("EquipmentName", "Наименование");
                dataGridViewMilitaryEquipment.Columns.Add("EquipmentType", "Тип");
                dataGridViewMilitaryEquipment.Columns.Add("Description", "Описание");
                dataGridViewMilitaryEquipment.Columns.Add("IsNew", String.Empty);
                dataGridViewMilitaryRoutes.Columns.Add("MilitaryRouteID", "Номер");
                dataGridViewMilitaryRoutes.Columns.Add("RouteName", "Наименование");
                dataGridViewMilitaryRoutes.Columns.Add("StartLocation", "Начальная точка");
                dataGridViewMilitaryRoutes.Columns.Add("EndLocation", "Конечная точка");
                dataGridViewMilitaryRoutes.Columns.Add("Description", "Описание");
                dataGridViewMilitaryRoutes.Columns.Add("IsNew", String.Empty);
                dataGridViewEventEquipment.Columns.Add("EventEquipmentID", "Номер");
                dataGridViewEventEquipment.Columns.Add("EventID", "ID события");
                dataGridViewEventEquipment.Columns.Add("EquipmentID", "ID техники");
                dataGridViewEventEquipment.Columns.Add("IsNew", String.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ClearFields() вызывается при очистке полей
        /// </summary>
        private void ClearFields()
        {
            try
            {
                textBoxMilitaryUnitID.Text = "";
                textBoxUnitName.Text = "";
                textBoxDescriptionMilitaryUnits.Text = "";
                textBoxWarEventID.Text = "";
                textBoxEventName.Text = "";
                textBoxEventLocation.Text = "";
                textBoxDescriptionWarEvents.Text = "";
                textBoxVeteranID.Text = "";
                textBoxFullName.Text = "";
                textBoxMilitaryRank.Text = "";
                textBoxUnitID.Text = "";
                textBoxMedalID.Text = "";
                textBoxMedalName.Text = "";
                textBoxDescriptionMedals.Text = "";
                textBoxVeteranMedalID.Text = "";
                textBoxVeteranIDVeteranMedals.Text = "";
                textBoxMedalIDVeteranMedals.Text = "";
                textBoxMilitaryEquipmentID.Text = "";
                textBoxEquipmentName.Text = "";
                textBoxEquipmentType.Text = "";
                textBoxDescriptionMilitaryEquipment.Text = "";
                textBoxMilitaryRouteID.Text = "";
                textBoxRouteName.Text = "";
                textBoxStartLocation.Text = "";
                textBoxEndLocation.Text = "";
                textBoxDescriptionMilitaryRoutes.Text = "";
                textBoxEventEquipmentID.Text = "";
                textBoxEventIDEventEquipment.Text = "";
                textBoxEquipmentIDEventEquipment.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ReadSingleRow() вызывается при чтении каждой строки
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="iDataRecord"></param>
        private static void ReadSingleRow(DataGridView dataGridView, SqlDataReader iDataRecord)
        {
            try
            {
                switch (dataGridView.Name)
                {
                    case "dataGridViewMilitaryUnits":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.IsDBNull(2) ? string.Empty : iDataRecord.GetString(2), RowState.Modified);
                        break;

                    case "dataGridViewWarEvents":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetDateTime(2).ToString("yyyy-MM-dd"), iDataRecord.IsDBNull(3) ? string.Empty : iDataRecord.GetString(3), iDataRecord.IsDBNull(4) ? string.Empty : iDataRecord.GetString(4), RowState.Modified);
                        break;

                    case "dataGridViewVeterans":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetDateTime(2).ToString("yyyy-MM-dd"), iDataRecord.IsDBNull(3) ? string.Empty : iDataRecord.GetDateTime(3).ToString("yyyy-MM-dd"), iDataRecord.IsDBNull(4) ? string.Empty : iDataRecord.GetString(4), iDataRecord.IsDBNull(5) ? string.Empty : iDataRecord.GetInt32(5).ToString(), RowState.Modified);
                        break;

                    case "dataGridViewMedals":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.IsDBNull(2) ? string.Empty : iDataRecord.GetString(2), RowState.Modified);
                        break;

                    case "dataGridViewVeteranMedals":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetInt32(1), iDataRecord.GetInt32(2), iDataRecord.GetDateTime(3).ToString("yyyy-MM-dd"), RowState.Modified);
                        break;

                    case "dataGridViewMilitaryEquipment":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.IsDBNull(2) ? string.Empty : iDataRecord.GetString(2), iDataRecord.IsDBNull(3) ? string.Empty : iDataRecord.GetString(3), RowState.Modified);
                        break;

                    case "dataGridViewMilitaryRoutes":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.IsDBNull(2) ? string.Empty : iDataRecord.GetString(2), iDataRecord.IsDBNull(3) ? string.Empty : iDataRecord.GetString(3), iDataRecord.IsDBNull(4) ? string.Empty : iDataRecord.GetString(4), RowState.Modified);
                        break;

                    case "dataGridViewEventEquipment":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetInt32(1), iDataRecord.GetInt32(2), RowState.Modified);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// RefreshDataGrid() вызывается при обновлении базы данных
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="tableName"></param>
        private void RefreshDataGrid(DataGridView dataGridView, string tableName)
        {
            try
            {
                dataGridView.Rows.Clear();
                string queryString = $"select * from {tableName}";
                SqlCommand sqlCommand = new(queryString, dataBase.GetConnection());
                dataBase.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ReadSingleRow(dataGridView, sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// InitializeNotifyIcon() вызывается при инициализации иконки в трее
        /// </summary>
        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
        }

        /// <summary>
        /// InitializeTimer() вызывается при инициализации таймера
        /// </summary>
        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer
            {
                Interval = 3600000
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// Timer_Tick() вызывается при завершении тайиера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            ShowBalloonTip();
        }

        /// <summary>
        /// ShowBalloonTip() вызывается при показе уведомления
        /// </summary>
        private void ShowBalloonTip()
        {
            notifyIcon.BalloonTipTitle = "Военный музей";
            notifyIcon.BalloonTipText = $"Все права защищены.";
            notifyIcon.ShowBalloonTip(3000);
        }

        /// <summary>
        /// Form1_Load() вызывается при загрузке сцены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CreateColumns();
                RefreshDataGrid(dataGridViewMilitaryUnits, "MilitaryUnits");
                RefreshDataGrid(dataGridViewWarEvents, "WarEvents");
                RefreshDataGrid(dataGridViewVeterans, "Veterans");
                RefreshDataGrid(dataGridViewMedals, "Medals");
                RefreshDataGrid(dataGridViewVeteranMedals, "VeteranMedals");
                RefreshDataGrid(dataGridViewMilitaryEquipment, "MilitaryEquipment");
                RefreshDataGrid(dataGridViewMilitaryRoutes, "MilitaryRoutes");
                RefreshDataGrid(dataGridViewEventEquipment, "EventEquipment");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridView_CellClick() вызывается при нажатии на ячейку
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="selectedRow"></param>
        private void DataGridView_CellClick(DataGridView dataGridView, int selectedRow)
        {
            try
            {
                DataGridViewRow dataGridViewRow = dataGridView.Rows[selectedRow];
                switch (dataGridView.Name)
                {
                    case "dataGridViewMilitaryUnits":
                        textBoxMilitaryUnitID.Text = dataGridViewRow.Cells[0].Value?.ToString();
                        textBoxUnitName.Text = dataGridViewRow.Cells[1].Value?.ToString();
                        textBoxDescriptionMilitaryUnits.Text = dataGridViewRow.Cells[2].Value?.ToString();
                        break;

                    case "dataGridViewWarEvents":
                        textBoxWarEventID.Text = dataGridViewRow.Cells[0].Value?.ToString();
                        textBoxEventName.Text = dataGridViewRow.Cells[1].Value?.ToString();
                        dateTimePickerEventDate.Text = dataGridViewRow.Cells[2].Value?.ToString();
                        textBoxEventLocation.Text = dataGridViewRow.Cells[3].Value?.ToString();
                        textBoxDescriptionWarEvents.Text = dataGridViewRow.Cells[4].Value?.ToString();
                        break;

                    case "dataGridViewVeterans":
                        textBoxVeteranID.Text = dataGridViewRow.Cells[0].Value?.ToString();
                        textBoxFullName.Text = dataGridViewRow.Cells[1].Value?.ToString();
                        dateTimePickerBirthDate.Text = dataGridViewRow.Cells[2].Value?.ToString();
                        dateTimePickerDeathDate.Text = dataGridViewRow.Cells[3].Value?.ToString();
                        textBoxMilitaryRank.Text = dataGridViewRow.Cells[4].Value?.ToString();
                        var unitId = dataGridViewRow.Cells[5].Value?.ToString();
                        if (!string.IsNullOrEmpty(unitId))
                        {
                            string unitQuery = $"SELECT UnitName FROM MilitaryUnits WHERE MilitaryUnitID = {unitId}";
                            SqlCommand unitCommand = new(unitQuery, dataBase.GetConnection());
                            dataBase.OpenConnection();
                            object unitResult = unitCommand.ExecuteScalar();
                            textBoxUnitID.Text = unitResult?.ToString();
                        }
                        break;

                    case "dataGridViewMedals":
                        textBoxMedalID.Text = dataGridViewRow.Cells[0].Value?.ToString();
                        textBoxMedalName.Text = dataGridViewRow.Cells[1].Value?.ToString();
                        textBoxDescriptionMedals.Text = dataGridViewRow.Cells[2].Value?.ToString();
                        break;

                    case "dataGridViewVeteranMedals":
                        textBoxVeteranMedalID.Text = dataGridViewRow.Cells[0].Value?.ToString();
                        var veteranId = dataGridViewRow.Cells[1].Value?.ToString();
                        if (!string.IsNullOrEmpty(veteranId))
                        {
                            string veteranQuery = $"SELECT FullName FROM Veterans WHERE VeteranID = {veteranId}";
                            SqlCommand veteranCommand = new(veteranQuery, dataBase.GetConnection());
                            dataBase.OpenConnection();
                            object veteranResult = veteranCommand.ExecuteScalar();
                            textBoxVeteranIDVeteranMedals.Text = veteranResult?.ToString();
                        }
                        var medalId = dataGridViewRow.Cells[2].Value?.ToString();
                        if (!string.IsNullOrEmpty(medalId))
                        {
                            string medalQuery = $"SELECT MedalName FROM Medals WHERE MedalID = {medalId}";
                            SqlCommand medalCommand = new(medalQuery, dataBase.GetConnection());
                            dataBase.OpenConnection();
                            object medalResult = medalCommand.ExecuteScalar();
                            textBoxMedalIDVeteranMedals.Text = medalResult?.ToString();
                        }

                        dateTimePickerAwardDate.Text = dataGridViewRow.Cells[3].Value?.ToString();
                        break;

                    case "dataGridViewMilitaryEquipment":
                        textBoxMilitaryEquipmentID.Text = dataGridViewRow.Cells[0].Value?.ToString();
                        textBoxEquipmentName.Text = dataGridViewRow.Cells[1].Value?.ToString();
                        textBoxEquipmentType.Text = dataGridViewRow.Cells[2].Value?.ToString();
                        textBoxDescriptionMilitaryEquipment.Text = dataGridViewRow.Cells[3].Value?.ToString();
                        break;

                    case "dataGridViewMilitaryRoutes":
                        textBoxMilitaryRouteID.Text = dataGridViewRow.Cells[0].Value?.ToString();
                        textBoxRouteName.Text = dataGridViewRow.Cells[1].Value?.ToString();
                        textBoxStartLocation.Text = dataGridViewRow.Cells[2].Value?.ToString();
                        textBoxEndLocation.Text = dataGridViewRow.Cells[3].Value?.ToString();
                        textBoxDescriptionMilitaryRoutes.Text = dataGridViewRow.Cells[4].Value?.ToString();
                        break;

                    case "dataGridViewEventEquipment":
                        textBoxEventEquipmentID.Text = dataGridViewRow.Cells[0].Value?.ToString();
                        var eventId = dataGridViewRow.Cells[1].Value?.ToString();
                        if (!string.IsNullOrEmpty(eventId))
                        {
                            string eventQuery = $"SELECT EventName FROM WarEvents WHERE WarEventID = {eventId}";
                            SqlCommand eventCommand = new(eventQuery, dataBase.GetConnection());
                            dataBase.OpenConnection();
                            object eventResult = eventCommand.ExecuteScalar();
                            textBoxEventIDEventEquipment.Text = eventResult?.ToString();
                        }
                        var equipmentId = dataGridViewRow.Cells[2].Value?.ToString();
                        if (!string.IsNullOrEmpty(equipmentId))
                        {
                            string equipmentQuery = $"SELECT EquipmentName FROM MilitaryEquipment WHERE MilitaryEquipmentID = {equipmentId}";
                            SqlCommand equipmentCommand = new(equipmentQuery, dataBase.GetConnection());
                            dataBase.OpenConnection();
                            object equipmentResult = equipmentCommand.ExecuteScalar();
                            textBoxEquipmentIDEventEquipment.Text = equipmentResult?.ToString();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Search() вызывается при вводе текста в строку
        /// </summary>
        /// <param name="dataGridView"></param>
        private void Search(DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                switch (dataGridView.Name)
                {
                    case "dataGridViewMilitaryUnits":
                        string searchStringMilitaryUnits = $"select * from MilitaryUnits where concat(MilitaryUnitID, UnitName, Description) like '%" + textBoxSearchMilitaryUnits.Text + "%'";
                        SqlCommand sqlCommandMilitaryUnits = new(searchStringMilitaryUnits, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderMilitaryUnits = sqlCommandMilitaryUnits.ExecuteReader();
                        while (sqlDataReaderMilitaryUnits.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderMilitaryUnits);
                        }
                        sqlDataReaderMilitaryUnits.Close();
                        break;

                    case "dataGridViewWarEvents":
                        string searchStringWarEvents = $"select * from WarEvents where concat(WarEventID, EventName, EventDate, EventLocation, Description) like '%" + textBoxSearchWarEvents.Text + "%'";
                        SqlCommand sqlCommandWarEvents = new(searchStringWarEvents, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderWarEvents = sqlCommandWarEvents.ExecuteReader();
                        while (sqlDataReaderWarEvents.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderWarEvents);
                        }
                        sqlDataReaderWarEvents.Close();
                        break;

                    case "dataGridViewVeterans":
                        string searchStringVeterans = $"select * from Veterans where concat(VeteranID, FullName, BirthDate, DeathDate, MilitaryRank, UnitID) like '%" + textBoxSearchVeterans.Text + "%'";
                        SqlCommand sqlCommandVeterans = new(searchStringVeterans, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderVeterans = sqlCommandVeterans.ExecuteReader();
                        while (sqlDataReaderVeterans.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderVeterans);
                        }
                        sqlDataReaderVeterans.Close();
                        break;

                    case "dataGridViewMedals":
                        string searchStringMedals = $"select * from Medals where concat(MedalID, MedalName, Description) like '%" + textBoxSearchMedals.Text + "%'";
                        SqlCommand sqlCommandMedals = new(searchStringMedals, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderMedals = sqlCommandMedals.ExecuteReader();
                        while (sqlDataReaderMedals.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderMedals);
                        }
                        sqlDataReaderMedals.Close();
                        break;

                    case "dataGridViewVeteranMedals":
                        string searchStringVeteranMedals = $"select * from VeteranMedals where concat(VeteranMedalID, VeteranID, MedalID, AwardDate) like '%" + textBoxSearchVeteranMedals.Text + "%'";
                        SqlCommand sqlCommandVeteranMedals = new(searchStringVeteranMedals, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderVeteranMedals = sqlCommandVeteranMedals.ExecuteReader();
                        while (sqlDataReaderVeteranMedals.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderVeteranMedals);
                        }
                        sqlDataReaderVeteranMedals.Close();
                        break;

                    case "dataGridViewMilitaryEquipment":
                        string searchStringMilitaryEquipment = $"select * from MilitaryEquipment where concat(MilitaryEquipmentID, EquipmentName, EquipmentType, Description) like '%" + textBoxSearchMilitaryEquipment.Text + "%'";
                        SqlCommand sqlCommandMilitaryEquipment = new(searchStringMilitaryEquipment, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderMilitaryEquipment = sqlCommandMilitaryEquipment.ExecuteReader();
                        while (sqlDataReaderMilitaryEquipment.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderMilitaryEquipment);
                        }
                        sqlDataReaderMilitaryEquipment.Close();
                        break;

                    case "dataGridViewMilitaryRoutes":
                        string searchStringMilitaryRoutes = $"select * from MilitaryRoutes where concat(MilitaryRouteID, RouteName, StartLocation, EndLocation, Description) like '%" + textBoxSearchMilitaryRoutes.Text + "%'";
                        SqlCommand sqlCommandMilitaryRoutes = new(searchStringMilitaryRoutes, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderMilitaryRoutes = sqlCommandMilitaryRoutes.ExecuteReader();
                        while (sqlDataReaderMilitaryRoutes.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderMilitaryRoutes);
                        }
                        sqlDataReaderMilitaryRoutes.Close();
                        break;

                    case "dataGridViewEventEquipment":
                        string searchStringEventEquipment = $"select * from EventEquipment where concat(EventEquipmentID, EventID, EquipmentID) like '%" + textBoxSearchEventEquipment.Text + "%'";
                        SqlCommand sqlCommandEventEquipment = new(searchStringEventEquipment, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderEventEquipment = sqlCommandEventEquipment.ExecuteReader();
                        while (sqlDataReaderEventEquipment.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderEventEquipment);
                        }
                        sqlDataReaderEventEquipment.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DeleteRow() вызывается при удалении строки
        /// </summary>
        /// <param name="dataGridView"></param>
        private static void DeleteRow(DataGridView dataGridView)
        {
            try
            {
                int index = dataGridView.CurrentCell.RowIndex;
                dataGridView.Rows[index].Visible = false;
                switch (dataGridView.Name)
                {
                    case "dataGridViewMilitaryUnits":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                        break;

                    case "dataGridViewWarEvents":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                        break;

                    case "dataGridViewVeterans":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[6].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[6].Value = RowState.Deleted;
                        break;

                    case "dataGridViewMedals":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                        break;

                    case "dataGridViewVeteranMedals":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                        break;

                    case "dataGridViewMilitaryEquipment":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                        break;

                    case "dataGridViewMilitaryRoutes":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                        break;

                    case "dataGridViewEventEquipment":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// UpdateBase() вызывается при обновлении базы данных
        /// </summary>
        /// <param name="dataGridView"></param>
        private void UpdateBase(DataGridView dataGridView)
        {
            try
            {
                dataBase.OpenConnection();
                for (int index = 0; index < dataGridView.Rows.Count; index++)
                {
                    switch (dataGridView.Name)
                    {
                        case "dataGridViewMilitaryUnits":
                            var rowStateUnits = (RowState)dataGridView.Rows[index].Cells[3].Value;
                            if (rowStateUnits == RowState.Existed) continue;

                            if (rowStateUnits == RowState.Deleted)
                            {
                                var unitID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from MilitaryUnits where MilitaryUnitID = '{unitID}'";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateUnits == RowState.Modified)
                            {
                                var unitID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var unitName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var description = dataGridView.Rows[index].Cells[2].Value?.ToString();
                                var changeQuery = $"update MilitaryUnits set UnitName = '{unitName}', Description = '{description}' where MilitaryUnitID = '{unitID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateUnits == RowState.New)
                            {
                                var unitName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var description = dataGridView.Rows[index].Cells[2].Value?.ToString();
                                var newQuery = $"insert into MilitaryUnits (UnitName, Description) values ('{unitName}', '{description}')";
                                var sqlCommand = new SqlCommand(newQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewWarEvents":
                            var rowStateEvents = (RowState)dataGridView.Rows[index].Cells[5].Value;
                            if (rowStateEvents == RowState.Existed) continue;

                            if (rowStateEvents == RowState.Deleted)
                            {
                                var eventID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from WarEvents where WarEventID = '{eventID}'";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateEvents == RowState.Modified)
                            {
                                var eventID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var eventName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var eventDate = Convert.ToDateTime(dataGridView.Rows[index].Cells[2].Value).ToString("yyyy-MM-dd");
                                var location = dataGridView.Rows[index].Cells[3].Value?.ToString();
                                var description = dataGridView.Rows[index].Cells[4].Value?.ToString();
                                var changeQuery = $"update WarEvents set EventName = '{eventName}', EventDate = '{eventDate}', EventLocation = '{location}', Description = '{description}' where WarEventID = '{eventID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateEvents == RowState.New)
                            {
                                var eventName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var eventDate = Convert.ToDateTime(dataGridView.Rows[index].Cells[2].Value).ToString("yyyy-MM-dd");
                                var location = dataGridView.Rows[index].Cells[3].Value?.ToString();
                                var description = dataGridView.Rows[index].Cells[4].Value?.ToString();
                                var newQuery = $"insert into WarEvents (EventName, EventDate, EventLocation, Description) values ('{eventName}', '{eventDate}', '{location}', '{description}')";
                                var sqlCommand = new SqlCommand(newQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewVeterans":
                            var rowStateVeterans = (RowState)dataGridView.Rows[index].Cells[6].Value;
                            if (rowStateVeterans == RowState.Existed) continue;

                            if (rowStateVeterans == RowState.Deleted)
                            {
                                var veteranID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from Veterans where VeteranID = '{veteranID}'";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateVeterans == RowState.Modified)
                            {
                                var veteranID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var birthDate = Convert.ToDateTime(dataGridView.Rows[index].Cells[2].Value).ToString("yyyy-MM-dd");
                                var deathDate = dataGridView.Rows[index].Cells[3].Value != null ? Convert.ToDateTime(dataGridView.Rows[index].Cells[3].Value).ToString("yyyy-MM-dd") : "NULL";
                                var rank = dataGridView.Rows[index].Cells[4].Value?.ToString();
                                var unitID = dataGridView.Rows[index].Cells[5].Value?.ToString();
                                var changeQuery = $"update Veterans set FullName = '{fullName}', BirthDate = '{birthDate}', DeathDate = {deathDate}, MilitaryRank = '{rank}', UnitID = {unitID ?? "NULL"} where VeteranID = '{veteranID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateVeterans == RowState.New)
                            {
                                var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var birthDate = Convert.ToDateTime(dataGridView.Rows[index].Cells[2].Value).ToString("yyyy-MM-dd");
                                var deathDate = dataGridView.Rows[index].Cells[3].Value != null ? $"'{Convert.ToDateTime(dataGridView.Rows[index].Cells[3].Value):yyyy-MM-dd}'" : "NULL";
                                var rank = dataGridView.Rows[index].Cells[4].Value?.ToString();
                                var unitID = dataGridView.Rows[index].Cells[5].Value?.ToString();
                                var newQuery = $"insert into Veterans (FullName, BirthDate, DeathDate, MilitaryRank, UnitID) values ('{fullName}', '{birthDate}', {deathDate}, '{rank}', {unitID ?? "NULL"})";
                                var sqlCommand = new SqlCommand(newQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewMedals":
                            var rowStateMedals = (RowState)dataGridView.Rows[index].Cells[3].Value;
                            if (rowStateMedals == RowState.Existed) continue;

                            if (rowStateMedals == RowState.Deleted)
                            {
                                var medalID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from Medals where MedalID = '{medalID}'";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateMedals == RowState.Modified)
                            {
                                var medalID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var medalName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var description = dataGridView.Rows[index].Cells[2].Value?.ToString();
                                var changeQuery = $"update Medals set MedalName = '{medalName}', Description = '{description}' where MedalID = '{medalID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateMedals == RowState.New)
                            {
                                var medalName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var description = dataGridView.Rows[index].Cells[2].Value?.ToString();
                                var newQuery = $"insert into Medals (MedalName, Description) values ('{medalName}', '{description}')";
                                var sqlCommand = new SqlCommand(newQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewVeteranMedals":
                            var rowStateVeteranMedals = (RowState)dataGridView.Rows[index].Cells[4].Value;
                            if (rowStateVeteranMedals == RowState.Existed) continue;

                            if (rowStateVeteranMedals == RowState.Deleted)
                            {
                                var veteranMedalID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from VeteranMedals where VeteranMedalID = '{veteranMedalID}'";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateVeteranMedals == RowState.Modified)
                            {
                                var veteranMedalID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var veteranID = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var medalID = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var awardDate = Convert.ToDateTime(dataGridView.Rows[index].Cells[3].Value).ToString("yyyy-MM-dd");
                                var changeQuery = $"update VeteranMedals set VeteranID = '{veteranID}', MedalID = '{medalID}', AwardDate = '{awardDate}' where VeteranMedalID = '{veteranMedalID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateVeteranMedals == RowState.New)
                            {
                                var veteranID = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var medalID = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var awardDate = Convert.ToDateTime(dataGridView.Rows[index].Cells[3].Value).ToString("yyyy-MM-dd");
                                var newQuery = $"insert into VeteranMedals (VeteranID, MedalID, AwardDate) values ('{veteranID}', '{medalID}', '{awardDate}')";
                                var sqlCommand = new SqlCommand(newQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewMilitaryEquipment":
                            var rowStateEquipment = (RowState)dataGridView.Rows[index].Cells[4].Value;
                            if (rowStateEquipment == RowState.Existed) continue;

                            if (rowStateEquipment == RowState.Deleted)
                            {
                                var equipmentID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from MilitaryEquipment where MilitaryEquipmentID = '{equipmentID}'";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateEquipment == RowState.Modified)
                            {
                                var equipmentID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var equipmentName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var equipmentType = dataGridView.Rows[index].Cells[2].Value?.ToString();
                                var description = dataGridView.Rows[index].Cells[3].Value?.ToString();
                                var changeQuery = $"update MilitaryEquipment set EquipmentName = '{equipmentName}', EquipmentType = '{equipmentType}', Description = '{description}' where MilitaryEquipmentID = '{equipmentID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateEquipment == RowState.New)
                            {
                                var equipmentName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var equipmentType = dataGridView.Rows[index].Cells[2].Value?.ToString();
                                var description = dataGridView.Rows[index].Cells[3].Value?.ToString();
                                var newQuery = $"insert into MilitaryEquipment (EquipmentName, EquipmentType, Description) values ('{equipmentName}', '{equipmentType}', '{description}')";
                                var sqlCommand = new SqlCommand(newQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewMilitaryRoutes":
                            var rowStateRoutes = (RowState)dataGridView.Rows[index].Cells[5].Value;
                            if (rowStateRoutes == RowState.Existed) continue;

                            if (rowStateRoutes == RowState.Deleted)
                            {
                                var routeID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from MilitaryRoutes where MilitaryRouteID = '{routeID}'";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateRoutes == RowState.Modified)
                            {
                                var routeID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var routeName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var startLocation = dataGridView.Rows[index].Cells[2].Value?.ToString();
                                var endLocation = dataGridView.Rows[index].Cells[3].Value?.ToString();
                                var description = dataGridView.Rows[index].Cells[4].Value?.ToString();
                                var changeQuery = $"update MilitaryRoutes set RouteName = '{routeName}', StartLocation = '{startLocation}', EndLocation = '{endLocation}', Description = '{description}' where MilitaryRouteID = '{routeID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateRoutes == RowState.New)
                            {
                                var routeName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var startLocation = dataGridView.Rows[index].Cells[2].Value?.ToString();
                                var endLocation = dataGridView.Rows[index].Cells[3].Value?.ToString();
                                var description = dataGridView.Rows[index].Cells[4].Value?.ToString();
                                var newQuery = $"insert into MilitaryRoutes (RouteName, StartLocation, EndLocation, Description) values ('{routeName}', '{startLocation}', '{endLocation}', '{description}')";
                                var sqlCommand = new SqlCommand(newQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewEventEquipment":
                            var rowStateEventEquipment = (RowState)dataGridView.Rows[index].Cells[3].Value;
                            if (rowStateEventEquipment == RowState.Existed) continue;

                            if (rowStateEventEquipment == RowState.Deleted)
                            {
                                var eventEquipmentID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from EventEquipment where EventEquipmentID = '{eventEquipmentID}'";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateEventEquipment == RowState.Modified)
                            {
                                var eventEquipmentID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var eventID = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var equipmentID = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var changeQuery = $"update EventEquipment set EventID = '{eventID}', EquipmentID = '{equipmentID}' where EventEquipmentID = '{eventEquipmentID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateEventEquipment == RowState.New)
                            {
                                var eventID = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var equipmentID = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var newQuery = $"insert into EventEquipment (EventID, EquipmentID) values ('{eventID}', '{equipmentID}')";
                                var sqlCommand = new SqlCommand(newQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;
                    }
                }
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

        /// <summary>
        /// Change() вызывается при изменении таблиц в базе данных
        /// </summary>
        /// <param name="dataGridView"></param>
        private void Change(DataGridView dataGridView)
        {
            try
            {
                var selectedRowIndex = dataGridView.CurrentCell.RowIndex;
                switch (dataGridView.Name)
                {
                    case "dataGridViewMilitaryUnits":
                        var militaryUnitID = textBoxMilitaryUnitID.Text;
                        var unitName = textBoxUnitName.Text;
                        var description = textBoxDescriptionMilitaryUnits.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(militaryUnitID, unitName, description);
                        dataGridView.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
                        break;

                    case "dataGridViewWarEvents":
                        var warEventID = textBoxWarEventID.Text;
                        var eventName = textBoxEventName.Text;
                        var eventDate = dateTimePickerEventDate.Value;
                        var eventLocation = textBoxEventLocation.Text;
                        var eventDescription = textBoxDescriptionWarEvents.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(warEventID, eventName, eventDate, eventLocation, eventDescription);
                        dataGridView.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                        break;

                    case "dataGridViewVeterans":
                        var veteranID = textBoxVeteranID.Text;
                        var fullName = textBoxFullName.Text;
                        var birthDate = dateTimePickerBirthDate.Value;
                        var deathDate = dateTimePickerDeathDate.Value;
                        var militaryRank = textBoxMilitaryRank.Text;
                        var unitNameVeterans = textBoxUnitID.Text;
                        string unitQuery = $"SELECT MilitaryUnitID FROM MilitaryUnits WHERE UnitName = '{unitNameVeterans}'";
                        SqlCommand unitCommand = new(unitQuery, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object unitResult = unitCommand.ExecuteScalar();
                        var unitID = unitResult?.ToString() ?? "0";
                        dataBase.CloseConnection();

                        dataGridView.Rows[selectedRowIndex].SetValues(veteranID, fullName, birthDate, deathDate, militaryRank, unitID);
                        dataGridView.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
                        break;

                    case "dataGridViewMedals":
                        var medalID = textBoxMedalID.Text;
                        var medalName = textBoxMedalName.Text;
                        var medalDescription = textBoxDescriptionMedals.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(medalID, medalName, medalDescription);
                        dataGridView.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
                        break;

                    case "dataGridViewVeteranMedals":
                        var veteranMedalID = textBoxVeteranMedalID.Text;
                        var veteranName = textBoxVeteranIDVeteranMedals.Text;
                        string veteranQuery = $"SELECT VeteranID FROM Veterans WHERE FullName = '{veteranName}'";
                        SqlCommand veteranCommand = new(veteranQuery, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object veteranResult = veteranCommand.ExecuteScalar();
                        var veteranIDForMedal = veteranResult?.ToString() ?? "0";
                        dataBase.CloseConnection();
                        var medalNameVeteranMedals = textBoxMedalIDVeteranMedals.Text;
                        string medalQuery = $"SELECT MedalID FROM Medals WHERE MedalName = '{medalNameVeteranMedals}'";
                        SqlCommand medalCommand = new(medalQuery, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object medalResult = medalCommand.ExecuteScalar();
                        var medalIDForVeteran = medalResult?.ToString() ?? "0";
                        dataBase.CloseConnection();

                        var awardDate = dateTimePickerAwardDate.Value;
                        dataGridView.Rows[selectedRowIndex].SetValues(veteranMedalID, veteranIDForMedal, medalIDForVeteran, awardDate);
                        dataGridView.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
                        break;

                    case "dataGridViewMilitaryEquipment":
                        var equipmentID = textBoxMilitaryEquipmentID.Text;
                        var equipmentName = textBoxEquipmentName.Text;
                        var equipmentType = textBoxEquipmentType.Text;
                        var equipmentDescription = textBoxDescriptionMilitaryEquipment.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(equipmentID, equipmentName, equipmentType, equipmentDescription);
                        dataGridView.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
                        break;

                    case "dataGridViewMilitaryRoutes":
                        var routeID = textBoxMilitaryRouteID.Text;
                        var routeName = textBoxRouteName.Text;
                        var startLocation = textBoxStartLocation.Text;
                        var endLocation = textBoxEndLocation.Text;
                        var routeDescription = textBoxDescriptionMilitaryRoutes.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(routeID, routeName, startLocation, endLocation, routeDescription);
                        dataGridView.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                        break;

                    case "dataGridViewEventEquipment":
                        var eventEquipmentID = textBoxEventEquipmentID.Text;
                        var eventNameEventEquipment = textBoxEventIDEventEquipment.Text;
                        string eventQuery = $"SELECT WarEventID FROM WarEvents WHERE EventName = '{eventNameEventEquipment}'";
                        SqlCommand eventCommand = new(eventQuery, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object eventResult = eventCommand.ExecuteScalar();
                        var eventID = eventResult?.ToString() ?? "0";
                        dataBase.CloseConnection();
                        var equipmentNameEventEquipment = textBoxEquipmentIDEventEquipment.Text;
                        string equipmentQuery = $"SELECT MilitaryEquipmentID FROM MilitaryEquipment WHERE EquipmentName = '{equipmentNameEventEquipment}'";
                        SqlCommand equipmentCommand = new(equipmentQuery, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object equipmentResult = equipmentCommand.ExecuteScalar();
                        var equipmentIDForEvent = equipmentResult?.ToString() ?? "0";
                        dataBase.CloseConnection();

                        dataGridView.Rows[selectedRowIndex].SetValues(eventEquipmentID, eventID, equipmentIDForEvent);
                        dataGridView.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ExportToWord() вызывается при экспорте в Word
        /// </summary>
        /// <param name="dataGridView"></param>
        private void ExportToWord(DataGridView dataGridView)
        {
            try
            {
                var wordApp = new Microsoft.Office.Interop.Word.Application
                {
                    Visible = true
                };
                Document doc = wordApp.Documents.Add();
                Paragraph title = doc.Paragraphs.Add();
                switch (dataGridView.Name)
                {
                    case "dataGridViewMilitaryUnits":
                        title.Range.Text = "Данные военных единиц";
                        break;

                    case "dataGridViewWarEvents":
                        title.Range.Text = "Данные событий войны";
                        break;

                    case "dataGridViewVeterans":
                        title.Range.Text = "Данные ветеранов";
                        break;

                    case "dataGridViewMedals":
                        title.Range.Text = "Данные медалей и наград";
                        break;

                    case "dataGridViewVeteranMedals":
                        title.Range.Text = "Данные о награждении ветеранов";
                        break;

                    case "dataGridViewMilitaryEquipment":
                        title.Range.Text = "Данные военной техники";
                        break;

                    case "dataGridViewMilitaryRoutes":
                        title.Range.Text = "Данные военных маршрутов";
                        break;

                    case "dataGridViewEventEquipment":
                        title.Range.Text = "Данные техники в событиях";
                        break;
                }
                title.Range.Font.Bold = 1;
                title.Range.Font.Size = 14;
                title.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                title.Range.InsertParagraphAfter();
                Table table = doc.Tables.Add(title.Range, dataGridView.RowCount + 1, dataGridView.ColumnCount - 1);
                for (int col = 0; col < dataGridView.ColumnCount - 1; col++)
                {
                    table.Cell(1, col + 1).Range.Text = dataGridView.Columns[col].HeaderText;
                }
                for (int row = 0; row < dataGridView.RowCount; row++)
                {
                    for (int col = 0; col < dataGridView.ColumnCount - 1; col++)
                    {
                        table.Cell(row + 2, col + 1).Range.Text = dataGridView[col, row].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ExportToExcel() вызывается при экспорте в Excel
        /// </summary>
        /// <param name="dataGridView"></param>
        private void ExportToExcel(DataGridView dataGridView)
        {
            try
            {
                Excel.Application excelApp = new()
                {
                    Visible = true
                };
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
                string title = "";
                switch (dataGridView.Name)
                {
                    case "dataGridViewMilitaryUnits":
                        title = "Данные военных единиц";
                        break;

                    case "dataGridViewWarEvents":
                        title = "Данные событий войны";
                        break;

                    case "dataGridViewVeterans":
                        title = "Данные ветеранов";
                        break;

                    case "dataGridViewMedals":
                        title = "Данные медалей и наград";
                        break;

                    case "dataGridViewVeteranMedals":
                        title = "Данные о награждении ветеранов";
                        break;

                    case "dataGridViewMilitaryEquipment":
                        title = "Данные военной техники";
                        break;

                    case "dataGridViewMilitaryRoutes":
                        title = "Данные военных маршрутов";
                        break;

                    case "dataGridViewEventEquipment":
                        title = "Данные техники в событиях";
                        break;
                }
                Excel.Range titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dataGridView.ColumnCount - 1]];
                titleRange.Merge();
                titleRange.Value = title;
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 14;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                for (int col = 0; col < dataGridView.ColumnCount; col++)
                {
                    worksheet.Cells[2, col + 1] = dataGridView.Columns[col].HeaderText;
                }
                for (int row = 0; row < dataGridView.RowCount; row++)
                {
                    for (int col = 0; col < dataGridView.ColumnCount - 1; col++)
                    {
                        worksheet.Cells[row + 3, col + 1] = dataGridView[col, row].Value.ToString();
                        Excel.Range dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[dataGridView.RowCount + 2, dataGridView.ColumnCount]];
                        dataRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        dataRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    }
                }
                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ExportToTXT() вызывается при экспорте в .txt
        /// </summary>
        /// <param name="dataGridView"></param>
        private static void ExportToTXT(DataGridView dataGridView)
        {
            string text = "";
            switch (dataGridView.Name)
            {
                case "dataGridViewMilitaryUnits":
                    text = "Данные военных единиц";
                    break;

                case "dataGridViewWarEvents":
                    text = "Данные событий войны";
                    break;

                case "dataGridViewVeterans":
                    text = "Данные ветеранов";
                    break;

                case "dataGridViewMedals":
                    text = "Данные медалей и наград";
                    break;

                case "dataGridViewVeteranMedals":
                    text = "Данные о награждении ветеранов";
                    break;

                case "dataGridViewMilitaryEquipment":
                    text = "Данные военной техники";
                    break;

                case "dataGridViewMilitaryRoutes":
                    text = "Данные военных маршрутов";
                    break;

                case "dataGridViewEventEquipment":
                    text = "Данные техники в событиях";
                    break;
            }
            for (int col = 0; col < dataGridView.ColumnCount; col++)
            {
                text += dataGridView.Columns[col].HeaderText + "\t";
            }
            text += "\n";
            for (int row = 0; row < dataGridView.RowCount; row++)
            {
                for (int col = 0; col < dataGridView.ColumnCount - 1; col++)
                {
                    text += dataGridView[col, row].Value?.ToString() + "\t";
                }
                text += "\n";
            }
            string filePath = "данные.txt";
            File.WriteAllText(filePath, text);
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        private void Reports(string report)
        {
            dataBase.OpenConnection();
            var wordApp = new Application { Visible = true };
            Document doc = wordApp.Documents.Add();
            Paragraph title = doc.Paragraphs.Add();
            string query = "";
            switch (report)
            {
                case "ReportVeterans":
                    title.Range.Text = "Список ветеранов с их наградами";
                    query = @"SELECT v.FullName, v.MilitaryRank, m.MedalName, vm.AwardDate
                            FROM Veterans v
                            JOIN VeteranMedals vm ON v.VeteranID = vm.VeteranID
                            JOIN Medals m ON vm.MedalID = m.MedalID;"
                    ;
                    break;

                case "Medals":
                    title.Range.Text = "Список всех событий войны и задействованной техники";
                    query = @"SELECT we.EventName, we.EventDate, me.EquipmentName
                            FROM WarEvents we
                            JOIN EventEquipment ee ON we.WarEventID = ee.EventID
                            JOIN MilitaryEquipment me ON ee.EquipmentID = me.MilitaryEquipmentID;"
                    ;
                    break;

                case "MilitaryRoutes":
                    title.Range.Text = "Список военных маршрутов и их локаций";
                    query = @"SELECT RouteName, StartLocation, EndLocation, Description
                            FROM MilitaryRoutes;"
                    ;
                    break;
            }
            SqlCommand command = new(query, dataBase.GetConnection());
            SqlDataAdapter adapter = new(command);
            System.Data.DataTable dataTable = new();
            adapter.Fill(dataTable);
            dataBase.CloseConnection();
            title.Range.Font.Bold = 1;
            title.Range.Font.Size = 14;
            title.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            title.Range.InsertParagraphAfter();
            Table table = doc.Tables.Add(title.Range, dataTable.Rows.Count + 1, dataTable.Columns.Count);
            table.Borders.Enable = 1;
            for (int col = 0; col < dataTable.Columns.Count; col++)
            {
                table.Cell(1, col + 1).Range.Text = dataTable.Columns[col].ColumnName;
            }
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    table.Cell(row + 2, col + 1).Range.Text = dataTable.Rows[row][col].ToString();
                }
            }
        }

        /// <summary>
        /// ButtonReportVeterans_Click() вызывается при нажатии на кнопку отчета на вкладке "Ветераны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReportVeterans_Click(object sender, EventArgs e)
        {
            Reports("ReportVeterans");
        }

        /// <summary>
        /// ButtonReportMedals_Click() вызывается при нажатии на кнопку отчета на вкладке "Медали и награды"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReportMedals_Click(object sender, EventArgs e)
        {
            Reports("Medals");
        }

        /// <summary>
        /// ButtonReportMilitaryRoutes_Click() вызывается при нажатии на кнопку отчета на вкладке "Военные маршруты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReportMilitaryRoutes_Click(object sender, EventArgs e)
        {
            Reports("MilitaryRoutes");
        }

        /// <summary>
        /// ButtonRefresh_Click() вызывается при нажатии на кнопку обновления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshDataGrid(dataGridViewMilitaryUnits, "MilitaryUnits");
                RefreshDataGrid(dataGridViewWarEvents, "WarEvents");
                RefreshDataGrid(dataGridViewVeterans, "Veterans");
                RefreshDataGrid(dataGridViewMedals, "Medals");
                RefreshDataGrid(dataGridViewVeteranMedals, "VeteranMedals");
                RefreshDataGrid(dataGridViewMilitaryEquipment, "MilitaryEquipment");
                RefreshDataGrid(dataGridViewMilitaryRoutes, "MilitaryRoutes");
                RefreshDataGrid(dataGridViewEventEquipment, "EventEquipment");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonClear_Click() вызывается при нажатии на кнопку очистки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewMilitaryUnit_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Военные единицы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewMilitaryUnit_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormMilitaryUnits addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewWarEvent_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "События войны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewWarEvent_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormWarEvents addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewVeteran_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Ветераны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewVeteran_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormVeterans addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewMedal_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Медали и награды"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewMedal_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormMedals addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewVeteranMedal_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Награды ветеранов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewVeteranMedal_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormVeteranMedals addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewMilitaryEquipment_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Военная техника"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewMilitaryEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormMilitaryEquipment addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewMilitaryRoute_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Военные маршруты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewMilitaryRoute_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormMilitaryRoutes addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewEventEquipment_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "События техники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewEventEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormEventEquipment addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteMilitaryUnit_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Военные единицы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteMilitaryUnit_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewMilitaryUnits);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteWarEvent_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "События войны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteWarEvent_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewWarEvents);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteVeteran_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Ветераны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteVeteran_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewVeterans);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteMedal_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Медали и награды"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteMedal_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewMedals);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteVeteranMedal_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Награды ветеранов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteVeteranMedal_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewVeteranMedals);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteMilitaryEquipment_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Военная техника"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteMilitaryEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewMilitaryEquipment);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteMilitaryRoute_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Военные маршруты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteMilitaryRoute_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewMilitaryRoutes);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteEventEquipment_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "События техники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteEventEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewEventEquipment);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeMilitaryUnit_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Военные единицы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeMilitaryUnit_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewMilitaryUnits);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeWarEvent_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "События войны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeWarEvent_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewWarEvents);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeVeteran_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Ветераны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeVeteran_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewVeterans);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeMedal_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Медали и награды"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeMedal_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewMedals);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeVeteranMedal_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Награды ветеранов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeVeteranMedal_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewVeteranMedals);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeMilitaryEquipment_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Военная техника"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeMilitaryEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewMilitaryEquipment);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeMilitaryRoute_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Военные маршруты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeMilitaryRoute_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewMilitaryRoutes);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeEventEquipment_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "События техники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeEventEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewEventEquipment);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveMilitaryUnit_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Военные единицы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveMilitaryUnit_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin)
                {
                    UpdateBase(dataGridViewMilitaryUnits);
                }
                else
                {
                    MessageBox.Show("У вас недостаточно прав!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveWarEvent_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "События войны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveWarEvent_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin)
                {
                    UpdateBase(dataGridViewWarEvents);
                }
                else
                {
                    MessageBox.Show("У вас недостаточно прав!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveVeteran_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Ветераны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveVeteran_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewVeterans);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveMedal_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Медали и награды"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveMedal_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin)
                {
                    UpdateBase(dataGridViewMedals);
                }
                else
                {
                    MessageBox.Show("У вас недостаточно прав!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveVeteranMedal_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Награды ветеранов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveVeteranMedal_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewVeteranMedals);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveMilitaryEquipment_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Военная техника"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveMilitaryEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin)
                {
                    UpdateBase(dataGridViewMilitaryEquipment);
                }
                else
                {
                    MessageBox.Show("У вас недостаточно прав!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveMilitaryRoute_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Военные маршруты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveMilitaryRoute_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin)
                {
                    UpdateBase(dataGridViewMilitaryRoutes);
                }
                else
                {
                    MessageBox.Show("У вас недостаточно прав!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveEventEquipment_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "События техники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveEventEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewEventEquipment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordMilitaryUnit_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Военные единицы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordMilitaryUnit_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewMilitaryUnits);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordWarEvent_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "События войны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordWarEvent_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewWarEvents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordVeteran_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Ветераны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordVeteran_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewVeterans);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordMedal_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Медали и награды"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordMedal_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewMedals);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordVeteranMedal_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Награды ветеранов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordVeteranMedal_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewVeteranMedals);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordMilitaryEquipment_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Военная техника"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordMilitaryEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewMilitaryEquipment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordMilitaryRoute_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Военные маршруты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordMilitaryRoute_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewMilitaryRoutes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordEventEquipment_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "События техники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordEventEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewEventEquipment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelMilitaryUnit_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Военные единицы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelMilitaryUnit_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewMilitaryUnits);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelWarEvent_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "События войны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelWarEvent_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewWarEvents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelVeteran_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Ветераны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelVeteran_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewVeterans);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelMedal_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Медали и награды"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelMedal_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewMedals);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelVeteranMedal_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Награды ветеранов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelVeteranMedal_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewVeteranMedals);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelMilitaryEquipment_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Военная техника"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelMilitaryEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewMilitaryEquipment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelMilitaryRoute_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Военные маршруты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelMilitaryRoute_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewMilitaryRoutes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelEventEquipment_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "События техники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelEventEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewEventEquipment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTMilitaryUnit_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Военные единицы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTMilitaryUnit_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewMilitaryUnits);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTWarEvent_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "События войны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTWarEvent_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewWarEvents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTVeteran_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Ветераны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTVeteran_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewVeterans);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTMedal_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Медали и награды"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTMedal_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewMedals);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTVeteranMedal_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Награды ветеранов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTVeteranMedal_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewVeteranMedals);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTMilitaryEquipment_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Военная техника"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTMilitaryEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewMilitaryEquipment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTMilitaryRoute_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Военные маршруты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTMilitaryRoute_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewMilitaryRoutes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTEventEquipment_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "События техники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTEventEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewEventEquipment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewMilitaryUnits_CellClick() вызывается при нажатии на ячейку на вкладке "Военные единицы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewMilitaryUnits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewMilitaryUnits, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewWarEvents_CellClick() вызывается при нажатии на ячейку на вкладке "События войны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewWarEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewWarEvents, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewVeterans_CellClick() вызывается при нажатии на ячейку на вкладке "Ветераны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewVeterans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewVeterans, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewMedals_CellClick() вызывается при нажатии на ячейку на вкладке "Медали и награды"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewMedals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewMedals, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewVeteranMedals_CellClick() вызывается при нажатии на ячейку на вкладке "Награды ветеранов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewVeteranMedals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewVeteranMedals, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewMilitaryEquipment_CellClick() вызывается при нажатии на ячейку на вкладке "Военная техника"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewMilitaryEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewMilitaryEquipment, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewMilitaryRoutes_CellClick() вызывается при нажатии на ячейку на вкладке "Военные маршруты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewMilitaryRoutes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewMilitaryRoutes, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewEventEquipment_CellClick() вызывается при нажатии на ячейку на вкладке "События техники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewEventEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewEventEquipment, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchMilitaryUnits_TextChanged() вызывается при изменении текста на вкладке "Военные единицы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchMilitaryUnits_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewMilitaryUnits);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchWarEvents_TextChanged() вызывается при изменении текста на вкладке "События войны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchWarEvents_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewWarEvents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchVeterans_TextChanged() вызывается при изменении текста на вкладке "Ветераны"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchVeterans_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewVeterans);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchMedals_TextChanged() вызывается при изменении текста на вкладке "Медали и награды"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchMedals_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewMedals);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchVeteranMedals_TextChanged() вызывается при изменении текста на вкладке "Награды ветеранов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchVeteranMedals_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewVeteranMedals);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchMilitaryEquipment_TextChanged() вызывается при изменении текста на вкладке "Военная техника"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchMilitaryEquipment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewMilitaryEquipment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchMilitaryRoutes_TextChanged() вызывается при изменении текста на вкладке "Военные маршруты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchMilitaryRoutes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewMilitaryRoutes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchEventEquipment_TextChanged() вызывается при изменении текста на вкладке "События техники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchEventEquipment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewEventEquipment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}