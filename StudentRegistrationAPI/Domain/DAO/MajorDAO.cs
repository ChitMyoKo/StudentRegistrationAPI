using StudentRegistrationAPI.Models;
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

        public List<MajorModel> GetAllMajorByUniversityId(int universityId)
        {
            List<MajorModel> majorList = new List<MajorModel>();
            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.SelectAllMajorByUniversityId;
                cmd.Parameters.AddWithValue("@UniversityId", universityId);

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        MajorModel major = new MajorModel();
                        major.Id = GetValue<int>(rd["ID"]).ToString();
                        major.Name = GetValue<string>(rd["NAME"]);
                        major.UniversityId = GetValue<int>(rd["UNIVERSITYID"]).ToString();

                        majorList.Add(major);
                    }

                    rd.Close();
                }
                con.Close();
            }
            return majorList;
        }
    }
}