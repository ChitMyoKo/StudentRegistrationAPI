using StudentRegistrationAPI.Models;
using StudentRegistrationAPI.Resources;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Domain.DAO
{
    public class StudentDAO : BaseDAO
    {
        public StudentDAO() : base() { }

        public StudentDAO(string connectionString) : base(connectionString) { }

        public bool CheckStudentNoExist(string studentNo)
        {
            bool result = false;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.SelectStudnetByStudentNo;
                cmd.Parameters.AddWithValue("@StudentNo", studentNo);

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

        public bool CheckNRCExist(string nrc)
        {
            bool result = false;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.SelectStudnetByNRC;
                cmd.Parameters.AddWithValue("@NRC", nrc);

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

        public int Insert(CreateStudentRequestModel requestModel)
        {
            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.InsertStudent;
                cmd.Parameters.AddWithValue("@STUDENTNO", requestModel.StudentNo);
                cmd.Parameters.AddWithValue("@NAME", requestModel.Name);
                cmd.Parameters.AddWithValue("@FATHERNAME", requestModel.FatherName);
                cmd.Parameters.AddWithValue("@NRC", requestModel.NRC);
                cmd.Parameters.AddWithValue("@ADDRESS", requestModel.Address);
                cmd.Parameters.AddWithValue("@PHONE", requestModel.Phone);
                cmd.Parameters.AddWithValue("@EMAIL", GetNull(requestModel.Email));
                cmd.Parameters.AddWithValue("@GENDER", requestModel.Gender);
                cmd.Parameters.AddWithValue("@DOB", requestModel.DateOfBirth);
                cmd.Parameters.AddWithValue("@UNIVERSITYID", requestModel.UniversityId);
                cmd.Parameters.AddWithValue("@MAJORID", requestModel.MajorId);
                cmd.Parameters.AddWithValue("@ACADEMICYEARID", requestModel.AcademicyearId);
                cmd.Parameters.AddWithValue("@ISDELETE", "0");
                cmd.Parameters.AddWithValue("@CREATEDDATE", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@CREATEDUSERID", requestModel.CreatedUserId);

                int affectedRowCount = cmd.ExecuteNonQuery();
                con.Close();
                return affectedRowCount;
            }
        }
        
        public List<StudentDTO> GetAllStudentList()
        {
            List<StudentDTO> studenList = new List<StudentDTO>();
            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.SelectAllStudent;

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        StudentDTO student = new StudentDTO();
                        student.Id = GetValue<int>(rd["ID"]).ToString();
                        student.StudentNo = GetValue<string>(rd["STUDENTNO"]);
                        student.Name = GetValue<string>(rd["NAME"]);
                        student.FatherName = GetValue<string>(rd["FATHERNAME"]);
                        student.NRC = GetValue<string>(rd["NRC"]);
                        student.Address = GetValue<string>(rd["ADDRESS"]);
                        student.Phone = GetValue<string>(rd["PHONE"]);
                        student.Email = GetValue<string>(rd["EMAIL"]);
                        student.Gender = GetValue<string>(rd["GENDER"]);
                        student.DateOfBirth = GetValue<string>(rd["DOB"]);
                        student.UniversityId = GetValue<int>(rd["UNIVERSITYID"]).ToString();
                        student.MajorId = GetValue<int>(rd["MAJORID"]).ToString();
                        student.AcademicyearId = GetValue<int>(rd["ACADEMICYEARID"]).ToString();

                        studenList.Add(student);
                    }

                    rd.Close();
                }
                con.Close();
            }
            return studenList;
        }
        
        public int DeleteStudent(string id, string userId)
        {
            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.DeleteStudent;
                cmd.Parameters.AddWithValue("@UPDATEDUSERID", userId);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@UPDATEDDATE", DateTime.Now.ToString());

                int affectedRowCount = cmd.ExecuteNonQuery();
                con.Close();
                return affectedRowCount;
            }
        }

        public bool CheckStudentNoExistForUpdate(string studentNo, string Id)
        {
            bool result = false;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.SelectStudnetByStudentNoForUpdate;
                cmd.Parameters.AddWithValue("@StudentNo", studentNo);
                cmd.Parameters.AddWithValue("@ID", Id);

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

        public bool CheckNRCExistForUpdate(string nrc, string Id)
        {
            bool result = false;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.SelectStudnetByNRCForUpdate;
                cmd.Parameters.AddWithValue("@NRC", nrc);
                cmd.Parameters.AddWithValue("@ID", Id);

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

        public int UpdateStudent(StudentUpdateRequestModel requestModel, string userId)
        {
            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.UpdateUser;
                cmd.Parameters.AddWithValue("@ID", requestModel.Id);
                cmd.Parameters.AddWithValue("@STUDENTNO", requestModel.StudentNo);
                cmd.Parameters.AddWithValue("@NAME", requestModel.Name);
                cmd.Parameters.AddWithValue("@FATHERNAME", requestModel.FatherName);
                cmd.Parameters.AddWithValue("@NRC", requestModel.NRC);
                cmd.Parameters.AddWithValue("@ADDRESS", requestModel.Address);
                cmd.Parameters.AddWithValue("@PHONE", requestModel.Phone);
                cmd.Parameters.AddWithValue("@EMAIL", GetNull(requestModel.Email));
                cmd.Parameters.AddWithValue("@GENDER", requestModel.Gender);
                cmd.Parameters.AddWithValue("@DOB", requestModel.DateOfBirth);
                cmd.Parameters.AddWithValue("@UNIVERSITYID", requestModel.UniversityId);
                cmd.Parameters.AddWithValue("@MAJORID", requestModel.MajorId);
                cmd.Parameters.AddWithValue("@ACADEMICYEARID", requestModel.AcademicyearId);
                cmd.Parameters.AddWithValue("@ISDELETE", "0");
                cmd.Parameters.AddWithValue("@UPDATEDDATE", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@UPDATEDUSERID", userId);

                int affectedRowCount = cmd.ExecuteNonQuery();
                con.Close();
                return affectedRowCount;
            }
        }

        public StudentDTO GetStudentById(int Id)
        {
            StudentDTO student = null;

            using (SqlConnection con = this.OpenConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = SqlResources.SelectStudentById;
                cmd.Parameters.AddWithValue("@Id", Id);

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        student = new StudentDTO();
                        student.Id = GetValue<int>(rd["ID"]).ToString();
                        student.StudentNo = GetValue<string>(rd["STUDENTNO"]);
                        student.Name = GetValue<string>(rd["NAME"]);
                        student.FatherName = GetValue<string>(rd["FATHERNAME"]);
                        student.NRC = GetValue<string>(rd["NRC"]);
                        student.Address = GetValue<string>(rd["ADDRESS"]);
                        student.Phone = GetValue<string>(rd["PHONE"]);
                        student.Email = GetValue<string>(rd["EMAIL"]);
                        student.Gender = GetValue<string>(rd["GENDER"]);
                        student.DateOfBirth = GetValue<string>(rd["DOB"]);
                        student.UniversityId = GetValue<int>(rd["UNIVERSITYID"]).ToString();
                        student.MajorId = GetValue<int>(rd["MAJORID"]).ToString();
                        student.AcademicyearId = GetValue<int>(rd["ACADEMICYEARID"]).ToString();

                    }

                    rd.Close();
                }
                con.Close();
            }
            return student;
        }
    }
}