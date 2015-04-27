using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows;

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
        public int AssignMemberToTeam(int memberId, int teamId)
        {
            DBConnector dbConnector = new DBConnector();

            if (dbConnector.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = dbConnector.connection.CreateCommand();

                    cmd.CommandText = "UPDATE members SET FK_teamId = @teamId WHERE memberId = @memberId";

                    if (teamId == 0)
                    {
                        cmd.Parameters.Add("@teamId", MySqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@teamId", MySqlDbType.Int32).Value = teamId;
                    }

                    cmd.Parameters.Add("@memberId", MySqlDbType.Int32).Value = memberId;

                    cmd.ExecuteNonQuery();

                    dbConnector.CloseConnection();

                    return 1;
                }
                catch (Exception e)
                {
                    return 2;
                }
            }
            else
            {
                return 3;
            }
        }

        [WebMethod]
        public int AddMember(string firstName, string surName, string password, string cpr, string address, string zipCode, string phone, string mail)
        {
            DBConnector dbConnector = new DBConnector();
            if (dbConnector.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = dbConnector.connection.CreateCommand();

                    try
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM members WHERE cpr = @cpr";
                        cmd.Parameters.Add("@cpr", MySqlDbType.VarChar).Value = cpr;

                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            return 4;
                        }
                    }
                    catch (Exception e)
                    {
                        return 2;
                    }

                    cmd.CommandText =
                        "INSERT INTO members (firstName, surName, password, cpr, address, zipCode, phone, mail) VALUES (@firstName, @surName, @password, @cpr, @address, @zipCode, @phone, @mail)";
                    cmd.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = firstName;
                    cmd.Parameters.Add("@surName", MySqlDbType.VarChar).Value = surName;
                    cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                    cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
                    cmd.Parameters.Add("@zipCode", MySqlDbType.VarChar).Value = zipCode;
                    cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                    cmd.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //Close connection
                    dbConnector.CloseConnection();

                    return 1;
                }
                catch (Exception e)
                {
                    return 2;
                }
            }
            else
            {
                return 3;
            }
        }

        [WebMethod]
        public int AddTeam(string name)
        {
            DBConnector dbConnector = new DBConnector();

            if (dbConnector.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = dbConnector.connection.CreateCommand();

                    cmd.CommandText = "INSERT INTO teams (name) VALUES (@name)";

                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

                    cmd.ExecuteNonQuery();

                    dbConnector.CloseConnection();

                    return 1;
                }
                catch (Exception e)
                {
                    return 2;
                }
            }
            else
            {
                return 3;
            }
        }

        [WebMethod]
        public int SetMemberAsInactive(string email, string password)
        {
            DBConnector dbConnector = new DBConnector();
            if (dbConnector.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = dbConnector.connection.CreateCommand();
                    /*cmd.CommandText =
                        "UPDATE members SET isActive = 0 WHERE P_ID = @memberId";
                    cmd.Parameters.Add("@memberId", MySqlDbType.Int32).Value = memberId;*/

                    cmd.CommandText = "UPDATE members SET isActive = 0 WHERE mail = @email AND password = @password";

                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //Close connection
                    dbConnector.CloseConnection();

                    return 1;
                }
                catch (Exception e)
                {
                    return 2;
                }
            }
            else
            {
                return 2;
            }
        }

        [WebMethod]
        public int GetMemberActivity(string email, string password)
        {
            DBConnector dbConnector = new DBConnector();

            if (dbConnector.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = dbConnector.connection.CreateCommand();

                    cmd.CommandText = "SELECT FK_teamId FROM members WHERE mail = @email AND password = @password";

                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

                    string activity = cmd.ExecuteScalar().ToString();

                    if (string.IsNullOrEmpty(activity))
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                catch (Exception e)
                {
                    return 2;
                }
            }
            else
            {
                return 2;
            }
        }

        [WebMethod]
        public int GetAdminRights(string email, string password)
        {
            DBConnector dbConnector = new DBConnector();

            if (dbConnector.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = dbConnector.connection.CreateCommand();

                    cmd.CommandText = "SELECT isAdmin FROM members WHERE mail = @email AND password = @password";

                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

                    int isAdmin = Convert.ToInt32(cmd.ExecuteScalar());

                    return isAdmin;
                }
                catch (Exception e)
                {
                    return 2;
                }
            }
            else
            {
                return 2;
            }
        }

        [WebMethod]
        public int LoginMember(string email, string password)
        {
            DBConnector dbConnector = new DBConnector();

            if (dbConnector.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = dbConnector.connection.CreateCommand();

                    cmd.CommandText = "SELECT password FROM members WHERE mail = @email";

                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

                    String correctPassword = cmd.ExecuteScalar().ToString();

                    if (password.Equals(correctPassword))
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                catch (Exception e)
                {
                    return 3;
                }
            }
            else
            {
                return 3;
            }
        }

        [WebMethod]
        public int HaveAdmin(string email, string password)
        {
            DBConnector dbConnector = new DBConnector();

            if (dbConnector.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = dbConnector.connection.CreateCommand();

                    cmd.CommandText = "SELECT isAdmin FROM members WHERE mail = @email AND password = @password";

                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

                    int admin = Convert.ToInt32(cmd.ExecuteScalar());

                    return admin;
                }
                catch (Exception e)
                {
                    return 2;
                }
            }
            else
            {
                return 2;
            }
        }

        [WebMethod]
        public List<String> GetMemberList()
        {
            DBConnector dbConnector = new DBConnector();

            if (dbConnector.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = dbConnector.connection.CreateCommand();

                    cmd.CommandText = "SELECT FK_teamId, memberId, firstName, surName FROM members";

                    MySqlDataReader results = cmd.ExecuteReader();

                    List<String> members = new List<string>();

                    while (results.Read())
                    {
                        string teamId;
                        int colIndex = results.GetOrdinal("FK_teamId");

                        if (results.IsDBNull(colIndex))
                        {
                            teamId = "0";
                        }
                        else
                        {
                            teamId = results.GetString(colIndex);
                        }


                        string memberId = results.GetString("memberId");
                        string firstName = results.GetString("firstName");
                        string surName = results.GetString("surName");

                        string fullName = firstName + " " + surName;

                        members.Add(teamId + "," + memberId + "," + fullName);
                    }

                    return members;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public List<String> GetTeamList()
        {
            DBConnector dbConnector = new DBConnector();

            if (dbConnector.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = dbConnector.connection.CreateCommand();

                    cmd.CommandText = "SELECT * FROM teams";

                    MySqlDataReader results = cmd.ExecuteReader();

                    List<String> teams = new List<string>();

                    while (results.Read())
                    {
                        string teamID = results.GetString("teamID");
                        string name = results.GetString("name");

                        teams.Add(teamID + "," + name);
                    }

                    return teams;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}