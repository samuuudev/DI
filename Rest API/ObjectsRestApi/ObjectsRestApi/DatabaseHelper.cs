using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace WPF_PowerBI_App
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper(string server, string database, string user, string password)
        {
            connectionString = $"Server={server};Database={database};User ID={user};Password={password};";
        }

        public DataTable GetData(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}
