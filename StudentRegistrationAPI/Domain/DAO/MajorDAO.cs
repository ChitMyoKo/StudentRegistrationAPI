using StudentRegistrationAPI.Resources;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Domain.DAO
{
    public class MajorDAO : BaseDAO
    {
        public MajorDAO() : base() { }

        public MajorDAO(string connectionString) : base(connectionString) { }

        public string GetMajorNameById(string Id)
        {
            string majorName = string.Empty;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.SelectMajorById;
                cmd.Parameters.AddWithValue("@ID", Id);

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        majorName = GetValue<string>(rd["NAME"]);
                    }

                    rd.Close();
                }
                con.Close();
            }
            return majorName;
        }
    }
}