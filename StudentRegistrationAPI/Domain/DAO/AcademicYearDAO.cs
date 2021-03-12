﻿using StudentRegistrationAPI.Models;
using StudentRegistrationAPI.Resources;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Domain.DAO
{
    public class AcademicYearDAO : BaseDAO
    {
        public AcademicYearDAO() : base() { }

        public AcademicYearDAO(string connectionString) : base(connectionString) { }
        
        public string GetAcademicYearNameById(string Id)
        {
            string yearName = string.Empty;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.SelectAcademicYearById;
                cmd.Parameters.AddWithValue("@ID", Id);

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        yearName = GetValue<string>(rd["NAME"]);
                    }

                    rd.Close();
                }
                con.Close();
            }
            return yearName;
        }

        public List<AcademicYearModel> GetAllAcademicYear()
        {
            List<AcademicYearModel> yearList = new List<AcademicYearModel>();
            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.SelectAllAcademicyear;

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        AcademicYearModel yearModel = new AcademicYearModel();
                        yearModel.Id = GetValue<string>(rd["ID"]);
                        yearModel.Name = GetValue<string>(rd["NAME"]);
                        yearModel.MajorId = GetValue<string>(rd["MAJORID"]);

                        yearList.Add(yearModel);
                    }

                    rd.Close();
                }
                con.Close();
            }
            return yearList;
        }
    }
}