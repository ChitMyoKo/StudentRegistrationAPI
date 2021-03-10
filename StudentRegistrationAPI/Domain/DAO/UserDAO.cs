using System;
using System.Data.SqlClient;

namespace StudentRegistrationAPI.Domain.DAO
{
    public class UserDAO : BaseDAO
    {
        public UserDAO() : base() { }

        public UserDAO(string connectionString) : base(connectionString) { }

        public void UpdateIsLoginStatusByUserId(string UserId, string flag)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "update TBL_USER set ISLOGIN_FLAG=@flag where UserID=@UserID;";
                    cmd.Parameters.AddWithValue("@UserID", UserId);
                    cmd.Parameters.AddWithValue("@flag", flag);
                    
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public string GetDynamicKeyByUserId(string userId)
        {
            string key = string.Empty;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM [TBL_USER] WHERE USERID = @UserID;";
                cmd.Parameters.AddWithValue("@UserID", userId);

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        key = GetValue<string>(rd["DYNAMICKEY"]);
                    }

                    rd.Close();
                }
                con.Close();
            }
            return key.Trim();
        }
    }
}