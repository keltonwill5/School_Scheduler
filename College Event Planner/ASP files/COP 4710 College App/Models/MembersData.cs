﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace COP_4710_College_App.Models
{
    public class MembersData
    {
        public static void addMember(string firstVar, string lastVar, string pictureVar, string emailVar, string passwordVar, string schoolNameVar, string userTypeVar)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "INSERT INTO members VALUES (null, @firstName, @lastName, @picture, @createDate, @email, @password, (SELECT Id FROM school WHERE school.name=@schoolNameId), (SELECT Id FROM user_type WHERE user_type.type=@userTypeId))";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@firstName", firstVar);
                cmd.Parameters.AddWithValue("@lastName", lastVar);
                cmd.Parameters.AddWithValue("@picture", pictureVar);
                cmd.Parameters.AddWithValue("@createDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@email", emailVar);
                cmd.Parameters.AddWithValue("@password", passwordVar);
                cmd.Parameters.AddWithValue("@schoolNameId", schoolNameVar);
                cmd.Parameters.AddWithValue("@userTypeId", userTypeVar);
                cmd.ExecuteNonQuery();
            }


            dbCon.Close();
        }

        public static void modifyMember(int memberId, string firstVar, string lastVar, string pictureVar, string emailVar, string passwordVar, string schoolNameVar, string userTypeVar)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "UPDATE members SET firstName=@firstName, lastName=@lastName, picture=@picture, email=@email, password=@password, schoolNameId=(SELECT Id FROM school WHERE school.name=@schoolNameId), userTypeId=(SELECT Id FROM user_type WHERE user_type.type=@userTypeId) WHERE id = @id";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@Id", memberId);
                cmd.Parameters.AddWithValue("@firstName", firstVar);
                cmd.Parameters.AddWithValue("@lastName", lastVar);
                cmd.Parameters.AddWithValue("@picture", pictureVar);
                cmd.Parameters.AddWithValue("@email", emailVar);
                cmd.Parameters.AddWithValue("@password", passwordVar);
                cmd.Parameters.AddWithValue("@schoolNameId", schoolNameVar);
                cmd.Parameters.AddWithValue("@userTypeId", userTypeVar);
                cmd.ExecuteNonQuery();
            }

            dbCon.Close();
        }

        public static void deleteMember(int memberID)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "DELETE FROM members WHERE ID = @Id";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@Id", memberID);
                cmd.ExecuteNonQuery();

            }

            dbCon.Close();
        }

        public static List<MembersViewModel> viewMembers()
        {
            List<MembersViewModel> members = new List<MembersViewModel>();
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM members JOIN school ON members.schoolNameId = school.id JOIN user_type ON members.userTypeId = user_type.id";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MembersViewModel member = new MembersViewModel();
                    member.id = reader.GetInt32(reader.GetOrdinal("Id"));
                    member.firstName = reader.GetString(reader.GetOrdinal("firstName"));
                    member.lastName = reader.GetString(reader.GetOrdinal("lastName"));
                    member.picture = reader.GetString(reader.GetOrdinal("picture"));
                    member.createDate = reader.GetDateTime(reader.GetOrdinal("createDate"));
                    member.email = reader.GetString(reader.GetOrdinal("email"));
                    member.password = reader.GetString(reader.GetOrdinal("password"));
                    member.schoolNameId = reader.GetInt32(reader.GetOrdinal("schoolNameId"));
                    member.userTypeId = reader.GetInt32(reader.GetOrdinal("userTypeId"));
                    members.Add(member);
                }
            }

            dbCon.Close();
            return members;
        }


        public static Boolean loginMember(string emailVar, string passwordVar)
        {
            Boolean canLogin = false;
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "SELECT Id FROM members WHERE members.email = @email AND members.password = @password";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                cmd.Parameters.AddWithValue("@email", emailVar);
                cmd.Parameters.AddWithValue("@password", passwordVar);
                var reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    canLogin = true;
                }
            }
            return canLogin;

        }


        public static Boolean checkExist(string emailVar)
        {
            Boolean exists = false;
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "SELECT Id FROM members WHERE members.email = @email";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                cmd.Parameters.AddWithValue("@email", emailVar);
                var reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    exists = true;
                }
            }
            return exists;


        }

        public static MembersViewModel getMember(string emailVar)
        {
            MembersViewModel member = new MembersViewModel();
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "SELECT members.*, school.id as schoolName, user_type.id as type FROM members JOIN school ON members.schoolNameId = school.id JOIN user_type ON members.userTypeId = user_type.id WHERE members.email = @email";

                var cmd = new MySqlCommand(query, dbCon.Connection);
                cmd.Parameters.AddWithValue("@email", emailVar);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    member.id = reader.GetInt32(reader.GetOrdinal("Id"));
                    member.firstName = reader.GetString(reader.GetOrdinal("firstName"));
                    member.lastName = reader.GetString(reader.GetOrdinal("lastName"));
                    member.picture = reader.GetString(reader.GetOrdinal("picture"));
                    member.createDate = reader.GetDateTime(reader.GetOrdinal("createDate"));
                    member.email = reader.GetString(reader.GetOrdinal("email"));
                    member.password = reader.GetString(reader.GetOrdinal("password"));
                    member.schoolNameId = reader.GetInt32(reader.GetOrdinal("schoolName"));
                    member.userTypeId = reader.GetInt32(reader.GetOrdinal("type"));
                }
            }
            dbCon.Close();
            return member;

        }



        public static string getTitle(int ID)
        {
            switch (ID)
            {
                case 0:
                    return "Student";
                case 1:
                    return "Admin";
                case 2:
                    return "SuperAdmin";
                case 3:
                    return "Dark Lord and Master";
            }
            return "";

        }
    }
}