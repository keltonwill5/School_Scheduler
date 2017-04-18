using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace COP_4710_College_App.Models
{
    public class EventsData
    {

        public static void joinEvent(int eventID, int userID)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "INSERT INTO event_users (event_id, user_id) SELECT @event_id, @user_id FROM event_users WHERE NOT EXISTS (Select * from event_users where event_id=0 and user_id=1) LIMIT 1";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@event_id", eventID);
                cmd.Parameters.AddWithValue("@user_id", userID);
                cmd.ExecuteNonQuery();
            }

            dbCon.Close();
        }

        public static void addEvent(string nameVar, string descVar, string categoryVar, DateTime timeVar, string locationVar, string phoneVar, string emailVar, int schoolNameVar, string rsoNameVar)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "INSERT INTO events VALUES (null, @name, @createDate, @description, (SELECT Id FROM event_category WHERE event_category.category=@categoryId), @time, @location, @contactPhone, @contactEmail, 2, @schoolNameId, (SELECT Id FROM rso WHERE rso.name=@rsoNameId), @comments, @rating)";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@name", nameVar);
                cmd.Parameters.AddWithValue("@createDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@description", descVar);
                cmd.Parameters.AddWithValue("@categoryId", categoryVar);
                cmd.Parameters.AddWithValue("@time", timeVar);
                cmd.Parameters.AddWithValue("@location", locationVar);
                cmd.Parameters.AddWithValue("@contactPhone", phoneVar);
                cmd.Parameters.AddWithValue("@contactEmail", emailVar);
                cmd.Parameters.AddWithValue("@schoolNameId", schoolNameVar);
                cmd.Parameters.AddWithValue("@rsoNameId", rsoNameVar);
                cmd.Parameters.AddWithValue("@comments", "");
                cmd.Parameters.AddWithValue("@rating", "5");
                cmd.ExecuteNonQuery();
            }

            dbCon.Close();
        }

        public static void modifyEvent(int eventId, string nameVar, string descVar, string categoryVar, int timeVar, int dateVar, string locationVar, string phoneVar, string emailVar, string privacyVar, string schoolNameVar, string rsoNameVar, string commentsVar, string ratingVar)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "UPDATE rso SET name=@name, description=@description, categoryId=(SELECT Id FROM event_category WHERE event_category.category=@categoryId), time=@time, date=@date, location=@location, contactPhone=@contactPhone, contactEmail=@contactEmail, privacyId=(SELECT Id FROM user_type WHERE user_type.type=@privacyId), schoolNameId=(SELECT Id FROM school WHERE school.name=@schoolNameId), rsoNameId=(SELECT Id FROM rso WHERE rso.name=@rsoNameId), comments=@comments, rating=@rating WHERE id = @id";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@Id", eventId);
                cmd.Parameters.AddWithValue("@name", nameVar);
                cmd.Parameters.AddWithValue("@description", descVar);
                cmd.Parameters.AddWithValue("@categoryId", categoryVar);
                cmd.Parameters.AddWithValue("@time", timeVar);
                cmd.Parameters.AddWithValue("@date", dateVar);
                cmd.Parameters.AddWithValue("@location", locationVar);
                cmd.Parameters.AddWithValue("@contactPhone", phoneVar);
                cmd.Parameters.AddWithValue("@contactEmail", emailVar);
                cmd.Parameters.AddWithValue("@privacyId", privacyVar);
                cmd.Parameters.AddWithValue("@schoolNameId", schoolNameVar);
                cmd.Parameters.AddWithValue("@rsoNameId", rsoNameVar);
                cmd.Parameters.AddWithValue("@comments", commentsVar);
                cmd.Parameters.AddWithValue("@rating", ratingVar);
                cmd.ExecuteNonQuery();
            }

            dbCon.Close();
        }

        public static void deleteEvent(int eventID)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "DELETE FROM events WHERE ID = @Id";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Parameters.AddWithValue("@Id", eventID);
                cmd.ExecuteNonQuery();
            }

            dbCon.Close();
        }

        public static List<EventsViewModel> viewEvents()
        {
            List<EventsViewModel> events = new List<EventsViewModel>();
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "SELECT events.*, school.name as schoolName, event_category.category as category, rso.name as rsoName FROM events JOIN school ON events.schoolNameId = school.id JOIN event_category ON events.categoryId = event_category.Id JOIN rso ON events.rsoNameId = rso.Id";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EventsViewModel evnt = new EventsViewModel();
                    evnt.id = reader.GetInt32(reader.GetOrdinal("Id"));
                    evnt.name = reader.GetString(reader.GetOrdinal("name"));
                    evnt.createDate = reader.GetDateTime(reader.GetOrdinal("createDate"));
                    evnt.description = reader.GetString(reader.GetOrdinal("description"));
                    evnt.categoryId = reader.GetInt32(reader.GetOrdinal("categoryId"));
                    evnt.time = reader.GetDateTime(reader.GetOrdinal("time"));
                    evnt.location = reader.GetString(reader.GetOrdinal("location"));
                    evnt.contactPhone = reader.GetString(reader.GetOrdinal("contactPhone"));
                    evnt.contactEmail = reader.GetString(reader.GetOrdinal("contactEmail"));
                    evnt.privacyId = reader.GetInt32(reader.GetOrdinal("privacyId"));
                    evnt.schoolNameId = reader.GetInt32(reader.GetOrdinal("schoolNameId"));
                    evnt.rsoNameId = reader.GetInt32(reader.GetOrdinal("rsoNameId"));
                    evnt.comments = reader.GetString(reader.GetOrdinal("comments"));
                    evnt.rating = reader.GetString(reader.GetOrdinal("rating"));
                    evnt.schoolName = reader.GetString(reader.GetOrdinal("schoolName"));
                    evnt.category = reader.GetString(reader.GetOrdinal("category"));
                    evnt.rsoName = reader.GetString(reader.GetOrdinal("rsoName"));
                    events.Add(evnt);
                }
            }

            dbCon.Close();
            return events;
        }
    }
}