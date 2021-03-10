using StudentRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Domain.DAO
{
    public class LoginDAO : BaseDAO
    {
        public LoginDAO() : base() { }

        public LoginDAO(string connectionString) : base(connectionString) { }

        public DateTime getSessionById(string sessionId)
        {
            DateTime dateTime = DateTime.Now;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Select * from TBL_LOGIN Where SESSIONID = @SessionID";
                cmd.Parameters.AddWithValue("@SessionID", sessionId);

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        dateTime = GetValue<DateTime>(rd["SessionExpirDate"]);
                    }

                    rd.Close();
                }
                con.Close();
            }
            return dateTime;

        }

        public void UpdateSessionExpiredDateByUserId(SessionModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "update [dbo].[TBL_LOGIN] set SessionExpirDate=@SessionExpirDate where UserID=@Useid and sessionid=@sessionid;";
                    cmd.Parameters.AddWithValue("@Useid", model.UserId);
                    cmd.Parameters.AddWithValue("@sessionid", model.SessionId);
                    cmd.Parameters.AddWithValue("@SessionExpirDate", model.SessionExpDate);

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateLogoutDateByUserid(string userId, string sessionId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "Update TBL_LOGIN set LogoutDate=@LogoutDate Where UserID=@Useid and sessionid=@sessionid;";
                    cmd.Parameters.AddWithValue("@Useid", userId);
                    cmd.Parameters.AddWithValue("@sessionid", sessionId);
                    cmd.Parameters.AddWithValue("@LogoutDate", DateTime.Now);

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}