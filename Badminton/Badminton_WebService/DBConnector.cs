﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Badminton_WebService
{
    public class DBConnector
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        private void Initialize()
        {
            server = "localhost";
            database = "semester_4_badminton";
            uid = "root";
            password = "";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool IsInitialized()
        {
            if (server == null || database == null || uid == null || password == null || connection == null)
            {
                return false;
            }
            return true;
        }

        //open connection to database
        public bool OpenConnection()
        {
            if (!IsInitialized())
            {
                Initialize();
            }

            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        //Cannot connect to server.  Contact administrator
                        break;

                    case 1045:
                        //Invalid username/password, please try again
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
    }
}