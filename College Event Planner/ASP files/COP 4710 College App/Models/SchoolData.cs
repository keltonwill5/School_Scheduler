using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace COP_4710_College_App.Models
{
    public class SchoolData
    {
        public static void addSchool(string nameVar, string addressVar, string phoneVar, string emailVar)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "INSERT INTO School VALUES (null, @name, @createDate, @address, @phone, @email)";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@name", nameVar);
                cmd.Parameters.AddWithValue("@createDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@address", addressVar);
                cmd.Parameters.AddWithValue("@phone", phoneVar);
                cmd.Parameters.AddWithValue("@email", emailVar);
                cmd.ExecuteNonQuery();
            }
        }

        public static void modifySchool(int schoolID, string nameVar, string addressVar, string phoneVar, string emailVar)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "UPDATE school SET address= @address, phone=@phone, email=@email, name=@name WHERE id = @id";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@Id", schoolID);
                cmd.Parameters.AddWithValue("@name", nameVar);
                cmd.Parameters.AddWithValue("@address", addressVar);
                cmd.Parameters.AddWithValue("@phone", phoneVar);
                cmd.Parameters.AddWithValue("@email", emailVar);
                cmd.ExecuteNonQuery();
            }
        }

        public static void deleteSchool(int schoolID)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "DELETE FROM school WHERE ID = @Id";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@Id", schoolID);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<SchoolViewModel> viewSchools()
        {
            List<SchoolViewModel> schools = new List<SchoolViewModel>();
            SchoolViewModel skool = new SchoolViewModel();
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM School";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    skool.id = reader.GetInt32(reader.GetOrdinal("ID"));
                    skool.name = reader.GetString(reader.GetOrdinal("name"));
                    skool.address = reader.GetString(reader.GetOrdinal("address"));
                    skool.phone = reader.GetString(reader.GetOrdinal("phone"));
                    skool.email = reader.GetString(reader.GetOrdinal("email"));
                    skool.createDate = reader.GetDateTime(reader.GetOrdinal("createDate"));
                    schools.Add(skool);
                }
            }

            return schools;
        }
    }
}