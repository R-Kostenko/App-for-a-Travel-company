using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency_temp.Classes
{
    // Class for establishing a connection to the MS SQL Server Management Database.
    class DataBaseConnection
    {
        private static DataBaseConnection instance; // Implementation of the "Singletone" pattern

        // SqlConnection object to establish a connection with the database.
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=/*Name of your local server*/;Initial Catalog=DataTrevApp;Integrated Security=True");
        // Alternative connection strings for different server configurations.
        // For local server: SqlConnection sqlConnection = new SqlConnection(@"Data Source=***.***.*.***,1433;Initial Catalog=DataTrevApp;Integrated Security=True");
        // For remote server: SqlConnection sqlConnection = new SqlConnection(@"Data Source=***.***.***.***,1433;Initial Catalog=DataTrevApp;Integrated Security=True");

        // Method to open the database connection.

        private DataBaseConnection() { }

        public static DataBaseConnection GetInstance()  // Implementation of the "Singletone" pattern
        {
            if (instance == null)
            {
                instance = new DataBaseConnection();
            }
            return instance;
        }

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        // Method to close the database connection.
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        // Method to get the SqlConnection object for external use.
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
