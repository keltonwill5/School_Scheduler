using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace COP_4710_College_App.Models
{
    public class RsoData
    {
        public static void addRSO(string nameVar, string schoolNameVar, string typeVar, string contactNameVar, string phoneVar, string emailVar, string descVar, int memberVar)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "INSERT INTO rso VALUES (null, @name, (SELECT Id FROM school WHERE school.name=@schoolNameId), (SELECT Id FROM rso_type WHERE rso_type.type=@typeId), @contactName, @contactPhone, @contactEmail, @description, (SELECT Id FROM members WHERE members.Id = @memberId))";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@name", nameVar);
                cmd.Parameters.AddWithValue("@schoolNameId", schoolNameVar);
                cmd.Parameters.AddWithValue("@typeId", typeVar);
                cmd.Parameters.AddWithValue("@contactName", contactNameVar);
                cmd.Parameters.AddWithValue("@contactPhone", phoneVar);
                cmd.Parameters.AddWithValue("@contactEmail", emailVar);
                cmd.Parameters.AddWithValue("@description", descVar);
                cmd.Parameters.AddWithValue("@memberId", memberVar);
                cmd.ExecuteNonQuery();
            }

            dbCon.Close();
        }

        public static void modifyRSO(int rsoID, string nameVar, string schoolNameVar, string typeVar, string contactNameVar, string phoneVar, string emailVar, string descVar, int memberVar)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "UPDATE rso SET name=@name, schoolNameId=(SELECT Id FROM school WHERE school.name=@schoolNameId), typeId=(SELECT Id FROM rso_type WHERE rso_type.type=@typeId), contactName=@contactName, contactPhone=@phone, contactEmail=@email, description=@description, memberId=(SELECT Id FROM members WHERE members.Id = @memberId) WHERE id = @id";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@Id", rsoID);
                cmd.Parameters.AddWithValue("@name", nameVar);
                cmd.Parameters.AddWithValue("@schoolNameId", schoolNameVar);
                cmd.Parameters.AddWithValue("@typeId", typeVar);
                cmd.Parameters.AddWithValue("@contactName", contactNameVar);
                cmd.Parameters.AddWithValue("@contactPhone", phoneVar);
                cmd.Parameters.AddWithValue("@contactEmail", emailVar);
                cmd.Parameters.AddWithValue("@description", descVar);
                cmd.Parameters.AddWithValue("@memberId", memberVar);
                cmd.ExecuteNonQuery();
            }

            dbCon.Close();
        }


        public static void deleteRSO(int rsoID)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "DELETE FROM rso WHERE ID = @Id";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@Id", rsoID);
                cmd.ExecuteNonQuery();
            }

            dbCon.Close();
        }

        public static List<RsoViewModel> viewRSO()
        {
            List<RsoViewModel> rsos = new List<RsoViewModel>();
            RsoViewModel rso = new RsoViewModel();
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM rso JOIN school ON rso.schoolNameId = school.id JOIN rso_type ON rso.typeId = rso_type.id JOIN members ON rso.memberId = members.Id";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rso.id = reader.GetInt32(reader.GetOrdinal("Id"));
                    rso.name = reader.GetString(reader.GetOrdinal("name"));
                    rso.schoolNameId = reader.GetInt32(reader.GetOrdinal("schoolNameId"));
                    rso.typeId = reader.GetInt32(reader.GetOrdinal("typeId"));
                    rso.contactName = reader.GetString(reader.GetOrdinal("contactName"));
                    rso.contactPhone = reader.GetString(reader.GetOrdinal("contactPhone"));
                    rso.contactEmail = reader.GetString(reader.GetOrdinal("contactEmail"));
                    rso.description = reader.GetString(reader.GetOrdinal("description"));
                    rso.memberId = reader.GetInt32(reader.GetOrdinal("memberId"));
                    rsos.Add(rso);
                }
            }

            dbCon.Close();
            return rsos;
        }
    }
}