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
        public void AddUser(int medlemsId, string fornavn, string efternavn, string fodselsdato, string addresse, int postnr, string tlf, string email)
        {
            DBConnector dbConnector = new DBConnector();
            dbConnector.OpenConnection();

            MySqlCommand cmd = dbConnector.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO medlemmer (medlemsId, fornavn, efternavn, fodselsdato, addresse, postnr, tlf, email) VALUES (@medlemsId, @fornavn, @efternavn, @fodselsdato, @addresse, @postnr, @tlf, @email)";
            cmd.Parameters.Add("@medlemsId", MySqlDbType.Int32).Value = medlemsId;
            cmd.Parameters.Add("@fornavn", MySqlDbType.VarChar).Value = fornavn;
            cmd.Parameters.Add("@efternavn", MySqlDbType.VarChar).Value = efternavn;
            cmd.Parameters.Add("@fodselsdato", MySqlDbType.VarChar).Value = fodselsdato;
            cmd.Parameters.Add("@addresse", MySqlDbType.VarChar).Value = addresse;
            cmd.Parameters.Add("@postnr", MySqlDbType.Int32).Value = postnr;
            cmd.Parameters.Add("@tlf", MySqlDbType.VarChar).Value = tlf;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

            //Execute command
            cmd.ExecuteNonQuery();

            dbConnector.CloseConnection();
        }


    }
}
