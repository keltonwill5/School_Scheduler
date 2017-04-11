using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Odbc;

namespace COP_4710_College_App.Models
{
    public class TestModel
    {
        public int ID;
        public string name;
    }

    public class callData
    { 
        public IEnumerable<TestModel> DataPull()
        { 
            using (OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
            {
                connection.Open();
                using (OdbcCommand command = new OdbcCommand("SELECT * FROM test", connection))
                using (OdbcDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        yield return new TestModel
                        {
                            ID = dr.GetInt32(dr.GetOrdinal("ID")),
                            name = dr.GetString(dr.GetOrdinal("name")),
                        };
                    }
                    dr.Close();
                }
                connection.Close();
            }
        }
    }
}