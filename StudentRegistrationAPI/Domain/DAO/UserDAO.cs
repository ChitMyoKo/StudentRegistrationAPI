using StudentRegistrationAPI.Models;
using StudentRegistrationAPI.Resources;
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
    
        public bool CheckUsernameExist(string userName)
        {
            bool result = false;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM [TBL_USER] WHERE USERNAME = @UserName;";
                cmd.Parameters.AddWithValue("@UserName", userName);

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        result = true;
                    }

                    rd.Close();
                }
                con.Close();
            }
            return result;

        }

        public int CreateUserAccount(AccountCreateRequestModel requestModel)
        {
            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.CreateUserAccount;
                cmd.Parameters.AddWithValue("@USERID", requestModel.UserId);
                cmd.Parameters.AddWithValue("@USERNAME", requestModel.UserName);
                cmd.Parameters.AddWithValue("@FULLNAME", requestModel.FullName);
                cmd.Parameters.AddWithValue("@EMAIL", requestModel.Email);
                cmd.Parameters.AddWithValue("@PASSWORD", requestModel.Password);
                cmd.Parameters.AddWithValue("@ISLOGIN", "0");
                cmd.Parameters.AddWithValue("@ISDELETE", "0");
                cmd.Parameters.AddWithValue("@CREATEDDATE", DateTime.Now);

                int affectedRowCount = cmd.ExecuteNonQuery();
                con.Close();
                return affectedRowCount;
            }
        }

        public bool CheckEmailExist(string email)
        {
            bool result = false;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM [TBL_USER] WHERE EMAIL = @Email;";
                cmd.Parameters.AddWithValue("@Email", email);

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        result = true;
                    }

                    rd.Close();
                }
                con.Close();
            }
            return result;

        }
    }
}