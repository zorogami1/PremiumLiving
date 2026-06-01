using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace PremiumLivingManagementSystem
{
    public class DatabaseHelper
    {
        // CHANGE THIS TO YOUR MYSQL SETUP
        private static string server = "localhost";
        private static string database = "PremiumLivingDB";
        private static string uid = "root";
        private static string password = "";

        public static string ConnectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static DataTable ExecuteQuery(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static int ExecuteNonQuery(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return cmd.ExecuteScalar();
            }
        }

        public static string HashPassword(string password)
        {
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public static int CurrentUserID { get; set; }
        public static string CurrentUserRole { get; set; }
        public static string CurrentUserName { get; set; }
    }
}