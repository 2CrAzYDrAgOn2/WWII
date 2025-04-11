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
                //textBoxMilitaryUnitID.Text = "";
                //textBoxUnitName.Text = "";
                //comboBoxClientTypeID.Text = "Физическое лицо";
                //textBoxEmailClients.Text = "";
                //maskedTextBoxPhoneClients.Text = "";
                //textBoxAddress.Text = "";
                //textBoxINN.Text = "";
                //textBoxWarEventID.Text = "";
                //textBoxEventName.Text = "";
                //maskedTextBoxPhoneEmployees.Text = "";
                //textBoxEventLocation.Text = "";
                //comboBoxGenderID.Text = "Мужской";
                //comboBoxPostID.Text = "Менеджер по продажам";
                //textBoxOrderID.Text = "";
                //textBoxClientIDOrders.Text = "";
                //textBoxEmployeeIDOrders.Text = "";
                //textBoxTotalAmount.Text = "";
                //comboBoxStatusID.Text = "В обработке";
                //textBoxProductID.Text = "";
                //textBoxName.Text = "";
                //textBoxDescription.Text = "";
                //textBoxPrice.Text = "";
                //textBoxOrderDetailID.Text = "";
                //textBoxOrderIDOrderDetails.Text = "";
                //textBoxProductIDOrderDetails.Text = "";
                //textBoxPriceOrderDetails.Text = "";
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
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetString(2), RowState.Modified);
                        break;

                    case "dataGridViewWarEvents":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetDateTime(2).ToString("yyyy-MM-dd"), iDataRecord.GetString(3), iDataRecord.GetString(4), RowState.Modified);
                        break;

                        //case "dataGridViewOrders":
                        //    dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetInt32(1), iDataRecord.GetInt32(2), iDataRecord.GetDateTime(3).ToString("yyyy-MM-dd"), iDataRecord.GetDouble(4), iDataRecord.GetInt32(5), RowState.Modified);
                        //    break;

                        //case "dataGridViewProducts":
                        //    dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetString(2), iDataRecord.GetDouble(3), RowState.Modified);
                        //    break;

                        //case "dataGridViewOrderDetails":
                        //    dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetInt32(1), iDataRecord.GetInt32(2), iDataRecord.GetDouble(3), RowState.Modified);
                        //    break;
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
                //RefreshDataGrid(dataGridViewOrders, "Orders");
                //RefreshDataGrid(dataGridViewProducts, "Products");
                //RefreshDataGrid(dataGridViewOrderDetails, "OrderDetails");
                //RefreshDataGrid(dataGridViewOrderDetails, "OrderDetails");
                //RefreshDataGrid(dataGridViewOrderDetails, "OrderDetails");
                //RefreshDataGrid(dataGridViewOrderDetails, "OrderDetails");
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
                    //case "dataGridViewClients":
                    //    textBoxMilitaryUnitID.Text = dataGridViewRow.Cells[0].Value.ToString();
                    //    textBoxUnitName.Text = dataGridViewRow.Cells[1].Value.ToString();
                    //    var clientTypeID = dataGridViewRow.Cells[2].Value.ToString();
                    //    string query = $"SELECT ClientType FROM ClientTypes WHERE ClientTypeID = {clientTypeID}";
                    //    SqlCommand command = new(query, dataBase.GetConnection());
                    //    dataBase.OpenConnection();
                    //    object result = command.ExecuteScalar();
                    //    comboBoxClientTypeID.Text = result.ToString();
                    //    textBoxEmailClients.Text = dataGridViewRow.Cells[3].Value.ToString();
                    //    maskedTextBoxPhoneClients.Text = dataGridViewRow.Cells[4].Value.ToString();
                    //    textBoxAddress.Text = dataGridViewRow.Cells[5].Value.ToString();
                    //    textBoxINN.Text = dataGridViewRow.Cells[6].Value.ToString();
                    //    dateTimePickerRegistrationDate.Text = dataGridViewRow.Cells[7].Value?.ToString();
                    //    break;

                    //case "dataGridViewEmployees":
                    //    textBoxWarEventID.Text = dataGridViewRow.Cells[0].Value.ToString();
                    //    textBoxEventName.Text = dataGridViewRow.Cells[1].Value.ToString();
                    //    maskedTextBoxPhoneEmployees.Text = dataGridViewRow.Cells[2].Value.ToString();
                    //    textBoxEventLocation.Text = dataGridViewRow.Cells[3].Value.ToString();
                    //    var genderID = dataGridViewRow.Cells[4].Value.ToString();
                    //    string queryGender = $"SELECT Gender FROM Genders WHERE GenderID = {genderID}";
                    //    SqlCommand commandGender = new(queryGender, dataBase.GetConnection());
                    //    dataBase.OpenConnection();
                    //    object resultGender = commandGender.ExecuteScalar();
                    //    comboBoxGenderID.Text = resultGender.ToString();
                    //    var postID = dataGridViewRow.Cells[5].Value.ToString();
                    //    string queryPost = $"SELECT Post FROM Posts WHERE PostID = {postID}";
                    //    SqlCommand commandPost = new(queryPost, dataBase.GetConnection());
                    //    dataBase.OpenConnection();
                    //    object resultPost = commandPost.ExecuteScalar();
                    //    comboBoxPostID.Text = resultPost.ToString();
                    //    break;
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
                    //case "dataGridViewClients":
                    //    string searchStringClient = $"select * from Clients where concat (ClientID, FullName, ClientTypeID, Email, Phone, Address, INN, RegistrationDate) like '%" + textBoxSearchMilitaryUnits.Text + "%'";
                    //    SqlCommand sqlCommandClient = new(searchStringClient, dataBase.GetConnection());
                    //    dataBase.OpenConnection();
                    //    SqlDataReader sqlDataReaderClient = sqlCommandClient.ExecuteReader();
                    //    while (sqlDataReaderClient.Read())
                    //    {
                    //        ReadSingleRow(dataGridView, sqlDataReaderClient);
                    //    }
                    //    sqlDataReaderClient.Close();
                    //    break;

                    //case "dataGridViewEmployees":
                    //    string searchStringEmployees = $"select * from Employees where concat (EmployeeID, FullName, Phone, Email, GenderID, PostID) like '%" + textBoxSearchWarEvents.Text + "%'";
                    //    SqlCommand sqlCommandEmployees = new(searchStringEmployees, dataBase.GetConnection());
                    //    dataBase.OpenConnection();
                    //    SqlDataReader sqlDataReaderEmployees = sqlCommandEmployees.ExecuteReader();
                    //    while (sqlDataReaderEmployees.Read())
                    //    {
                    //        ReadSingleRow(dataGridView, sqlDataReaderEmployees);
                    //    }
                    //    sqlDataReaderEmployees.Close();
                    //    break;
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
                    case "dataGridViewClients":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                        break;

                    case "dataGridViewEmployees":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
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
                        //case "dataGridViewClients":
                        //    var rowStateClients = (RowState)dataGridView.Rows[index].Cells[8].Value;
                        //    if (rowStateClients == RowState.Existed)
                        //    {
                        //        continue;
                        //    }
                        //    if (rowStateClients == RowState.Deleted)
                        //    {
                        //        var clientID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                        //        var deleteQuery = $"delete from Clients where ClientID = '{clientID}'";
                        //        var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                        //        sqlCommand.ExecuteNonQuery();
                        //    }
                        //    if (rowStateClients == RowState.Modified)
                        //    {
                        //        var clientID = dataGridView.Rows[index].Cells[0].Value.ToString();
                        //        var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                        //        var clientTypeID = dataGridView.Rows[index].Cells[2].Value.ToString();
                        //        var email = dataGridView.Rows[index].Cells[3].Value.ToString();
                        //        var phone = dataGridView.Rows[index].Cells[4].Value.ToString();
                        //        var address = dataGridView.Rows[index].Cells[5].Value.ToString();
                        //        var iNN = dataGridView.Rows[index].Cells[6].Value.ToString();
                        //        var registrationDate = dataGridView.Rows[index].Cells[7].Value.ToString();
                        //        var changeQuery = $"update Clients set FullName = '{fullName}', ClientTypeID = '{clientTypeID}', Email = '{email}', Phone = '{phone}', Address = '{address}', INN = '{iNN}', RegistrationDate = '{registrationDate}' where ClientID = '{clientID}'";
                        //        var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                        //        sqlCommand.ExecuteNonQuery();
                        //    }
                        //    if (rowStateClients == RowState.New)
                        //    {
                        //        var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                        //        var clientTypeID = dataGridView.Rows[index].Cells[2].Value.ToString();
                        //        var email = dataGridView.Rows[index].Cells[3].Value.ToString();
                        //        var phone = dataGridView.Rows[index].Cells[4].Value.ToString();
                        //        var address = dataGridView.Rows[index].Cells[5].Value.ToString();
                        //        var iNN = dataGridView.Rows[index].Cells[6].Value.ToString();
                        //        var newQuery = $"insert into Clients (FullName, ClientTypeID, Email, Phone, Address, INN) values ('{fullName}', '{clientTypeID}', '{email}', '{phone}', '{address}', '{iNN}')";
                        //        var sqlCommand = new SqlCommand(newQuery, dataBase.GetConnection());
                        //        sqlCommand.ExecuteNonQuery();
                        //    }
                        //    break;

                        //case "dataGridViewEmployees":
                        //    var rowStateEmployees = (RowState)dataGridView.Rows[index].Cells[6].Value;
                        //    if (rowStateEmployees == RowState.Existed)
                        //    {
                        //        continue;
                        //    }
                        //    if (rowStateEmployees == RowState.Deleted)
                        //    {
                        //        var employeeID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                        //        var deleteQuery = $"delete from Employees where EmployeeID = '{employeeID}'";
                        //        var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                        //        sqlCommand.ExecuteNonQuery();
                        //    }
                        //    if (rowStateEmployees == RowState.Modified)
                        //    {
                        //        var employeeID = dataGridView.Rows[index].Cells[0].Value.ToString();
                        //        var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                        //        var phone = dataGridView.Rows[index].Cells[2].Value.ToString();
                        //        var email = dataGridView.Rows[index].Cells[3].Value.ToString();
                        //        var genderID = dataGridView.Rows[index].Cells[4].Value.ToString();
                        //        var postID = dataGridView.Rows[index].Cells[5].Value.ToString();
                        //        var changeQuery = $"update Employees set FullName = '{fullName}', Phone = '{phone}', Email = '{email}', GenderID = '{genderID}', PostID = '{postID}' where EmployeeID = '{employeeID}'";
                        //        var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                        //        sqlCommand.ExecuteNonQuery();
                        //    }
                        //    if (rowStateEmployees == RowState.New)
                        //    {
                        //        var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                        //        var phone = dataGridView.Rows[index].Cells[2].Value.ToString();
                        //        var email = dataGridView.Rows[index].Cells[3].Value.ToString();
                        //        var genderID = dataGridView.Rows[index].Cells[4].Value.ToString();
                        //        var postID = dataGridView.Rows[index].Cells[5].Value.ToString();
                        //        var newQuery = $"insert into Employees (FullName, Phone, Email, GenderID, PostID) values ('{fullName}', '{phone}', '{email}', '{genderID}', '{postID}')";
                        //        var sqlCommand = new SqlCommand(newQuery, dataBase.GetConnection());
                        //        sqlCommand.ExecuteNonQuery();
                        //    }
                        //    break;
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
                //var selectedRowIndex = dataGridView.CurrentCell.RowIndex;
                switch (dataGridView.Name)
                {
                    //case "dataGridViewClients":
                    //    var clientID = textBoxMilitaryUnitID.Text;
                    //    var fullName = textBoxUnitName.Text;
                    //    var clientType = comboBoxClientTypeID.Text;
                    //    string query = $"SELECT ClientTypeID FROM ClientTypes WHERE ClientType = '{clientType}'";
                    //    SqlCommand command = new(query, dataBase.GetConnection());
                    //    dataBase.OpenConnection();
                    //    object result = command.ExecuteScalar();
                    //    var clientTypeID = result.ToString();
                    //    var email = textBoxEmailClients.Text;
                    //    var phone = maskedTextBoxPhoneClients.Text;
                    //    var address = textBoxAddress.Text;
                    //    var iNN = textBoxINN.Text;
                    //    var registrationDate = dateTimePickerRegistrationDate.Value;
                    //    dataGridView.Rows[selectedRowIndex].SetValues(clientID, fullName, clientTypeID, email, phone, address, iNN, registrationDate);
                    //    dataGridView.Rows[selectedRowIndex].Cells[8].Value = RowState.Modified;
                    //    break;

                    //case "dataGridViewEmployees":
                    //    var employeeID = textBoxWarEventID.Text;
                    //    var fullNameEmployees = textBoxEventName.Text;
                    //    var phoneEmployees = maskedTextBoxPhoneEmployees.Text;
                    //    var emailEmployees = textBoxEventLocation.Text;
                    //    var gender = comboBoxGenderID.Text;
                    //    string queryGender = $"SELECT GenderID FROM Genders WHERE Gender = '{gender}'";
                    //    SqlCommand commandGender = new(queryGender, dataBase.GetConnection());
                    //    dataBase.OpenConnection();
                    //    object resultGender = commandGender.ExecuteScalar();
                    //    var genderID = resultGender.ToString();
                    //    var post = comboBoxPostID.Text;
                    //    string queryPost = $"SELECT PostID FROM Posts WHERE Post = '{post}'";
                    //    SqlCommand commandPost = new(queryPost, dataBase.GetConnection());
                    //    dataBase.OpenConnection();
                    //    object resultPost = commandPost.ExecuteScalar();
                    //    var postID = resultPost.ToString();
                    //    dataGridView.Rows[selectedRowIndex].SetValues(employeeID, fullNameEmployees, phoneEmployees, emailEmployees, genderID, postID);
                    //    dataGridView.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
                    //    break;
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
                        title = "Данные событий войн";
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
                    text += "Данные военных единиц\n\n";
                    break;

                case "dataGridViewWarEvents":
                    text += "Данные событий войн\n\n";
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
            //dataBase.OpenConnection();
            //var wordApp = new Application { Visible = true };
            //Document doc = wordApp.Documents.Add();
            //Paragraph title = doc.Paragraphs.Add();
            //string query = "";
            //switch (report)
            //{
            //    case "ReportOrders":
            //        title.Range.Text = "Отчет по заказам клиентов";
            //        query = @"SELECT
            //                    o.OrderID AS 'Номер заказа',
            //                    c.FullName AS 'Клиент',
            //                    e.FullName AS 'Менеджер',
            //                    s.Status AS 'Статус',
            //                    o.OrderDate AS 'Дата заказа',
            //                    o.TotalAmount AS 'Сумма заказа'
            //                FROM Orders o
            //                JOIN Clients c ON o.ClientID = c.ClientID
            //                JOIN Employees e ON o.EmployeeID = e.EmployeeID
            //                JOIN Statuses s ON o.StatusID = s.StatusID
            //                ORDER BY o.OrderDate DESC;"
            //        ;
            //        break;

            //    case "MonthlyReportOrders":
            //        title.Range.Text = "Отчет по продажам за месяц";
            //        query = @"SELECT
            //                    YEAR(OrderDate) AS 'Год',
            //                    MONTH(OrderDate) AS 'Месяц',
            //                    COUNT(OrderID) AS 'Количество заказов',
            //                    SUM(TotalAmount) AS 'Общая сумма продаж'
            //                FROM Orders
            //                GROUP BY YEAR(OrderDate), MONTH(OrderDate)
            //                ORDER BY YEAR(OrderDate) DESC, MONTH(OrderDate) DESC;"
            //        ;
            //        break;

            //    case "ReportProducts":
            //        title.Range.Text = "Отчет по популярным товарам";
            //        query = @"SELECT
            //                    p.Name AS 'Товар',
            //                    COUNT(od.OrderDetailID) AS 'Количество продаж',
            //                    SUM(od.Price) AS 'Общая сумма'
            //                FROM OrderDetails od
            //                JOIN Products p ON od.ProductID = p.ProductID
            //                GROUP BY p.Name
            //                ORDER BY COUNT(od.OrderDetailID) DESC, SUM(od.Price) DESC;"
            //        ;
            //        break;
            //}
            //SqlCommand command = new(query, dataBase.GetConnection());
            //SqlDataAdapter adapter = new(command);
            //System.Data.DataTable dataTable = new();
            //adapter.Fill(dataTable);
            //dataBase.CloseConnection();
            //title.Range.Font.Bold = 1;
            //title.Range.Font.Size = 14;
            //title.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            //title.Range.InsertParagraphAfter();
            //Table table = doc.Tables.Add(title.Range, dataTable.Rows.Count + 1, dataTable.Columns.Count);
            //table.Borders.Enable = 1;
            //for (int col = 0; col < dataTable.Columns.Count; col++)
            //{
            //    table.Cell(1, col + 1).Range.Text = dataTable.Columns[col].ColumnName;
            //}
            //for (int row = 0; row < dataTable.Rows.Count; row++)
            //{
            //    for (int col = 0; col < dataTable.Columns.Count; col++)
            //    {
            //        table.Cell(row + 2, col + 1).Range.Text = dataTable.Rows[row][col].ToString();
            //    }
            //}
        }

        /// <summary>
        /// ButtonReportOrders_Click() вызывается при нажатии на кнопку отчета на вкладке "Заказы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReportOrders_Click(object sender, EventArgs e)
        {
            Reports("ReportOrders");
        }

        /// <summary>
        /// ButtonReportProducts_Click() вызывается при нажатии на кнопку отчета на вкладке "Продукты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReportProducts_Click(object sender, EventArgs e)
        {
            Reports("ReportProducts");
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
                RefreshDataGrid(dataGridViewMilitaryUnits, "Clients");
                RefreshDataGrid(dataGridViewWarEvents, "Employees");
                RefreshDataGrid(dataGridViewVeterans, "Orders");
                RefreshDataGrid(dataGridViewProducts, "Products");
                RefreshDataGrid(dataGridViewOrderDetails, "OrderDetails");
                RefreshDataGrid(dataGridViewOrderDetails, "OrderDetails");
                RefreshDataGrid(dataGridViewOrderDetails, "OrderDetails");
                RefreshDataGrid(dataGridViewOrderDetails, "OrderDetails");
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
        /// ButtonNewClient_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewClient_Click(object sender, EventArgs e)
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
        /// ButtonNewEmployee_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Сотрудники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewEmployee_Click(object sender, EventArgs e)
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
        /// ButtonNewOrder_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Заказы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewOrder_Click(object sender, EventArgs e)
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
        /// ButtonNewProduct_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Продукты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewProduct_Click(object sender, EventArgs e)
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
        /// ButtonNewOrderDetails_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Детали заказов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewOrderDetails_Click(object sender, EventArgs e)
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
        /// ButtonDeleteClient_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteClient_Click(object sender, EventArgs e)
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
        /// ButtonDeleteEmployee_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Сотрудники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteEmployee_Click(object sender, EventArgs e)
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
        /// ButtonDeleteOrder_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Заказы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteOrder_Click(object sender, EventArgs e)
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
        /// ButtonDeleteProduct_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Продукты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewProducts);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteOrderDetails_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Детали заказов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteOrderDetails_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewOrderDetails);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeClient_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeClient_Click(object sender, EventArgs e)
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
        /// ButtonChangeEmployee_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Сотрудники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeEmployee_Click(object sender, EventArgs e)
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
        /// ButtonChangeOrder_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Заказы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeOrder_Click(object sender, EventArgs e)
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
        /// ButtonChangeProduct_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Продукты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewProducts);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeOrderDetails_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Детали заказов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeOrderDetails_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewOrderDetails);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveClient_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveClient_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewMilitaryUnits);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveEmployee_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Сотрудники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveEmployee_Click(object sender, EventArgs e)
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
        /// ButtonSaveOrder_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Заказы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveOrder_Click(object sender, EventArgs e)
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
        /// ButtonSaveProduct_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Продукты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin)
                {
                    UpdateBase(dataGridViewProducts);
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
        /// ButtonSaveOrderDetails_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Детали заказов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveOrderDetails_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewOrderDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordClient_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordClient_Click(object sender, EventArgs e)
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
        /// ButtonWordEmployee_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Сотрудники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordEmployee_Click(object sender, EventArgs e)
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
        /// ButtonWordOrder_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Заказы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordOrder_Click(object sender, EventArgs e)
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
        /// ButtonWordProduct_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Продукты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordProduct_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordOrderDetails_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Детали заказов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordOrderDetails_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewOrderDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelClient_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelClient_Click(object sender, EventArgs e)
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
        /// ButtonExcelEmployee_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Сотрудники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelEmployee_Click(object sender, EventArgs e)
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
        /// ButtonExcelOrder_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Заказы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelOrder_Click(object sender, EventArgs e)
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
        /// ButtonExcelProduct_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Продукты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelProduct_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelOrderDetails_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Детали заказов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelOrderDetails_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewOrderDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTClient_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTClient_Click(object sender, EventArgs e)
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
        /// ButtonTXTEmployee_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Сотрудники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTEmployee_Click(object sender, EventArgs e)
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
        /// ButtonTXTOrder_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Заказы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTOrder_Click(object sender, EventArgs e)
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
        /// ButtonTXTProduct_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Продукты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTProduct_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTOrderDetails_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Детали заказов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTOrderDetails_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewOrderDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewClients_CellClick() вызывается при нажатии на ячейку на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewClients_CellClick(object sender, DataGridViewCellEventArgs e)
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
        /// DataGridViewEmployees_CellClick() вызывается при нажатии на ячейку на вкладке "Сотрудники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
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
        /// DataGridViewOrders_CellClick() вызывается при нажатии на ячейку на вкладке "Заказы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewOrders_CellClick(object sender, DataGridViewCellEventArgs e)
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
        /// DataGridViewProducts_CellClick() вызывается при нажатии на ячейку на вкладке "Продукты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewProducts, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewOrderDetails_CellClick() вызывается при нажатии на ячейку на вкладке "Детали заказов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewOrderDetails, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchClients_TextChanged() вызывается при изменении текста на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchClients_TextChanged(object sender, EventArgs e)
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
        /// TextBoxSearchEmployees_TextChanged() вызывается при изменении текста на вкладке "Сотрудники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchEmployees_TextChanged(object sender, EventArgs e)
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
        /// TextBoxSearchOrders_TextChanged() вызывается при изменении текста на вкладке "Заказы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchOrders_TextChanged(object sender, EventArgs e)
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
        /// TextBoxSearchProducts_TextChanged() вызывается при изменении текста на вкладке "Продукты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchProducts_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchOrderDetails_TextChanged() вызывается при изменении текста на вкладке "Детали заказов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchOrderDetails_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewOrderDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}