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
                string query = "INSERT INTO rso VALUES (null, @name, (SELECT Id FROM school WHERE school.name=@schoolNameId), (SELECT Id FROM rso_type WHERE rso_type.type=@typeId), @contactName, @contactPhone, @contactEmail, @description, @memberId)";
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
                string query = "UPDATE rso SET name=@name, schoolNameId=(SELECT Id FROM school WHERE school.name=@schoolNameId), typeId=(SELECT Id FROM rso_type WHERE rso_type.type=@typeId), contactName=@contactName, contactPhone=@contactPhone, contactEmail=@contactEmail, description=@description, memberId=@memberId WHERE id = @id";
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

        public static void joinRSO(int rsoID, int userID)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "INSERT INTO rso_members VALUES (null, @rso_id, @user_id)";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@rso_id", rsoID);
                cmd.Parameters.AddWithValue("@user_id", userID);
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
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "SELECT rso.*, school.name as schoolName, rso_type.type as type, (SELECT COUNT(Id) FROM rso_members WHERE rso_members.rso_id = rso.id) as count FROM rso JOIN school ON rso.schoolNameId = school.id JOIN rso_type ON rso.typeId = rso_type.id";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RsoViewModel rso = new RsoViewModel();
                    rso.id = reader.GetInt32(reader.GetOrdinal("Id"));
                    rso.name = reader.GetString(reader.GetOrdinal("name"));
                    rso.schoolNameId = reader.GetInt32(reader.GetOrdinal("schoolNameId"));
                    rso.typeId = reader.GetInt32(reader.GetOrdinal("typeId"));
                    rso.contactName = reader.GetString(reader.GetOrdinal("contactName"));
                    rso.contactPhone = reader.GetString(reader.GetOrdinal("contactPhone"));
                    rso.contactEmail = reader.GetString(reader.GetOrdinal("contactEmail"));
                    rso.description = reader.GetString(reader.GetOrdinal("description"));
                    rso.memberId = reader.GetInt32(reader.GetOrdinal("memberId"));
                    rso.schoolName = reader.GetString(reader.GetOrdinal("schoolName"));
                    rso.type = reader.GetString(reader.GetOrdinal("type"));
                    rso.count = reader.GetInt32(reader.GetOrdinal("count"));
                    rsos.Add(rso);
                }
            }

            dbCon.Close();
            return rsos;
        }

        public static List<RsoViewModel> rsoTypes()
        {
            List<RsoViewModel> rsos = new List<RsoViewModel>();
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM rso_type";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RsoViewModel rso = new RsoViewModel();
                    rso.id = reader.GetInt32(reader.GetOrdinal("Id"));
                    rso.type = reader.GetString(reader.GetOrdinal("type"));
                    rsos.Add(rso);
                }
            }

            dbCon.Close();
            return rsos;
        }
    }
}