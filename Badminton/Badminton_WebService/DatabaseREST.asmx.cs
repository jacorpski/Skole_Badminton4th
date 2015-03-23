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
        public string AddMember(string firstName, string surName, string cpr, string address, string zipCode, string phone, string mail)
        {
            DBConnector dbConnector = new DBConnector();
            if (dbConnector.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = dbConnector.connection.CreateCommand();
                    cmd.CommandText =
                        "INSERT INTO members (firstName, surName, cpr, address, zipCode, phone, mail) VALUES (@firstName, @surName, @cpr, @address, @zipCode, @phone, @mail)";
                    cmd.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = firstName;
                    cmd.Parameters.Add("@surName", MySqlDbType.VarChar).Value = surName;
                    cmd.Parameters.Add("@cpr", MySqlDbType.VarChar).Value = cpr;
                    cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
                    cmd.Parameters.Add("@zipCode", MySqlDbType.VarChar).Value = zipCode;
                    cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                    cmd.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //Close connection
                    dbConnector.CloseConnection();

                    return "New member inserted.";
                }
                catch (Exception e)
                {
                    return "Could not insert new member.";
                }
            }
            else
            {
                return "Could not connect to the Database.";
            }
        }

        [WebMethod]
        public string SetMemberAsInactive(int memberId)
        {
            DBConnector dbConnector = new DBConnector();
            if (dbConnector.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = dbConnector.connection.CreateCommand();
                    cmd.CommandText =
                        "UPDATE members SET isActive = 0 WHERE P_ID = @memberId";
                    cmd.Parameters.Add("@memberId", MySqlDbType.Int32).Value = memberId;

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //Close connection
                    dbConnector.CloseConnection();

                    return "Member updated.";
                }
                catch (Exception e)
                {
                    return "Could not update member.";
                }
            }
            else
            {
                return "Could not connect to the Database.";
            }
        }


    }
}