using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;

namespace Badminton_WebService
{
    /// <summary>
    /// Summary description for WebServiceTest
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DatabaseREST : System.Web.Services.WebService
    {
        [WebMethod]
        public void AddMember(string firstName, string surName, int cpr, string address, int zipCode, string phone, string mail)
        {
            DBConnector dbConnector = new DBConnector();
            dbConnector.OpenConnection();

            MySqlCommand cmd = dbConnector.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO members (firstName, surName, cpr, address, postnr, phone, mail) VALUES (@firstName, @surName, @cpr, @address, @zipCode, @phone, @mail)";
            cmd.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = firstName;
            cmd.Parameters.Add("@surName", MySqlDbType.VarChar).Value = surName;
            cmd.Parameters.Add("@cpr", MySqlDbType.Int32).Value = cpr;
            cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@zipCode", MySqlDbType.Int32).Value = zipCode;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;

            //Execute command
            cmd.ExecuteNonQuery();

            dbConnector.CloseConnection();
        }


    }
}