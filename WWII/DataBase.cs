using System.Data.SqlClient;

namespace WWII
{
    public class DataBase
    {
        private readonly SqlConnection sqlConnection = new(@"Data Source=DESKTOP-5NBKFAI\SQLEXPRESS;Initial Catalog=WWII;Integrated Security=True");

        /// <summary>
        /// OpenConnection() вызывается при открытии соединения с базой данных
        /// </summary>
        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        /// <summary>
        /// CloseConnection() вызывается при закрытии соединения с базой данных
        /// </summary>
        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// GetConnection() вызывается при получении соединения с базой данных
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}