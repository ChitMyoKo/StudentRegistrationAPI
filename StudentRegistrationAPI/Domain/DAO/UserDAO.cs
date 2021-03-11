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
    
        public User GetUserByUsernameOrEmail(string userName, string email)
        {
            User user = null;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from TBL_USER where (USERNAME = @Username OR EMAIL = @Email) and ISDELETE = 0;";
                cmd.Parameters.AddWithValue("@Username", GetNull(userName));
                cmd.Parameters.AddWithValue("@Email", GetNull(email));

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        user = new User();
                        user.UserId = GetValue<string>(rd["USERID"]);
                        user.UserName = GetValue<string>(rd["USERNAME"]);
                        user.FullName = GetValue<string>(rd["FULLNAME"]);
                        user.Email = GetValue<string>(rd["EMAIL"]);
                        user.Password = GetValue<string>(rd["PASSWORD"]);
                    }

                    rd.Close();
                }
                con.Close();
            }
            return user;
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

        public int UpdateDynamicKeyAndLoginstatus(string userId, string dynamicKey, string status)
        {
            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.User_UpdateKeyAndStatus;
                cmd.Parameters.AddWithValue("@DYNAMICKEY", dynamicKey);
                cmd.Parameters.AddWithValue("@ISLOGIN", status);
                cmd.Parameters.AddWithValue("@USERID", userId);

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