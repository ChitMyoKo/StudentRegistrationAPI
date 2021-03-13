using StudentRegistrationAPI.Models;
using StudentRegistrationAPI.Resources;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Domain.DAO
{
    public class UniversityDAO : BaseDAO
    {
        public UniversityDAO() : base() { }

        public UniversityDAO(string connectionString) : base(connectionString) { }

        public string GetUniversityNameById(string Id)
        {
            string universityName = string.Empty;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.SelectUniversityById;
                cmd.Parameters.AddWithValue("@ID", Id);

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        universityName = GetValue<string>(rd["NAME"]);
                    }

                    rd.Close();
                }
                con.Close();
            }
            return universityName;
        }

        public List<UniversityModel> GetAllUniversity()
        {
            List<UniversityModel> uniList = new List<UniversityModel>();
            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.SelectAllUniversity;

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        UniversityModel university = new UniversityModel();
                        university.Id = GetValue<int>(rd["ID"]).ToString();
                        university.Name = GetValue<string>(rd["NAME"]);

                        uniList.Add(university);
                    }

                    rd.Close();
                }
                con.Close();
            }
            return uniList;
        }
    }
}