﻿using System.Configuration;
using MySql.Data.MySqlClient;

namespace COP_4710_College_App.Models
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = "collegeeventplanner";
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (string.IsNullOrEmpty(databaseName))
                return false;

            string connstring = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            connection = new MySqlConnection(connstring);
            connection.Open();

            return true;
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}