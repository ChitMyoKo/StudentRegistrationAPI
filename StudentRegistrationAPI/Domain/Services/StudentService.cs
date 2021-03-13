using StudentRegistrationAPI.Domain.DAO;
using StudentRegistrationAPI.Models;
using StudentRegistrationAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Domain.Services
{
    public class StudentService
    {
        public CreateStudentResponseModel AddStudent(CreateStudentRequestModel requestModel, string userId)
        {
            CreateStudentResponseModel responseModel = new CreateStudentResponseModel() { RespCode = ResponseCode.C000, RespDescription = Message.M000 };

            StudentDAO studentDAO = new StudentDAO();

            try
            {
                bool doesNRCExist = studentDAO.CheckNRCExist(requestModel.NRC);
                if (doesNRCExist)
                {
                    responseModel.RespCode = ResponseCode.C005;
                    responseModel.RespDescription = Message.M005;
                    return responseModel;
                }

                bool doesStudneNoExist = studentDAO.CheckStudentNoExist(requestModel.StudentNo);
                if (doesStudneNoExist)
                {
                    responseModel.RespCode = ResponseCode.C006;
                    responseModel.RespDescription = Message.M006;
                    return responseModel;
                }

                requestModel.CreatedUserId = userId;
                int effectedRows = studentDAO.Insert(requestModel);

                if (effectedRows <= 0)
                {
                    responseModel.RespCode = ResponseCode.C014;
                    responseModel.RespDescription = Message.M014;
                    return responseModel;
                }

                return responseModel;
            }
            catch(Exception e)
            {
                responseModel.RespCode = ResponseCode.C014;
                responseModel.RespDescription = Message.M014;
                return responseModel;
            }
        }
        
        public StudentListResponseModel GetAllStudents()
        {
            StudentListResponseModel responseModel = new StudentListResponseModel() { RespCode = ResponseCode.C000, RespDescription = Message.M000 };

            StudentDAO studentDAO = new StudentDAO();
            UniversityDAO universityDAO = new UniversityDAO();
            MajorDAO majorDAO = new MajorDAO();
            AcademicYearDAO academicYearDAO = new AcademicYearDAO();
            List<StudentDTO> studentList = new List<StudentDTO>();
            
            studentList = studentDAO.GetAllStudentList();

            if(studentList.Count > 0)
            {
                foreach(StudentDTO student in studentList)
                {
                    student.UniversityName = universityDAO.GetUniversityNameById(student.UniversityId);
                    student.MajorName = majorDAO.GetMajorNameById(student.MajorId);
                    student.AcademicyearName = academicYearDAO.GetAcademicYearNameById(student.AcademicyearId);
                }
            }

            responseModel.studentList = studentList;

            return responseModel;
        }
        
        public StudentDeleteResponseModel DeleteStudent(StudentDeleteRequestModel requestModel, string userId)
        {
            StudentDeleteResponseModel responseModel = new StudentDeleteResponseModel() { RespCode = ResponseCode.C000, RespDescription = Message.M000 };

            StudentDAO studentDAO = new StudentDAO();

            try
            {
                int effectedRow = studentDAO.DeleteStudent(requestModel.Id, userId);

                if(effectedRow == 0)
                {
                    responseModel.RespCode = ResponseCode.C014;
                    responseModel.RespDescription = Message.M014;
                    return responseModel;
                }

                return responseModel;
            }
            catch(Exception e)
            {
                responseModel.RespCode = ResponseCode.C014;
                responseModel.RespDescription = Message.M014;
                return responseModel;
            }

            
        }
        
        public CreateStudentResponseModel UpdateStudent(StudentUpdateRequestModel requestModel, string userId)
        {
            CreateStudentResponseModel responseModel = new CreateStudentResponseModel() { RespCode = ResponseCode.C000, RespDescription = Message.M000 };

            StudentDAO studentDAO = new StudentDAO();

            bool doesNRCExist = studentDAO.CheckNRCExistForUpdate(requestModel.NRC, requestModel.Id);
            if(doesNRCExist)
            {
                responseModel.RespCode = ResponseCode.C005;
                responseModel.RespDescription = Message.M005;
                return responseModel;
            }

            bool doesStudenNoExist = studentDAO.CheckStudentNoExistForUpdate(requestModel.StudentNo, requestModel.Id);
            if (doesStudenNoExist)
            {
                responseModel.RespCode = ResponseCode.C006;
                responseModel.RespDescription = Message.M006;
                return responseModel;
            }

            int effectedRow = studentDAO.UpdateStudent(requestModel, userId);
            if(effectedRow == 0)
            {
                responseModel.RespCode = ResponseCode.C014;
                responseModel.RespDescription = Message.M014;
                return responseModel;
            }

            return responseModel;
        }

        public StudentDTO GetStudentById(int Id)
        {
            StudentDTO responseModel = new StudentDTO() { RespCode = ResponseCode.C000, RespDescription = Message.M000 };

            StudentDAO studentDAO = new StudentDAO();
            UniversityDAO universityDAO = new UniversityDAO();
            MajorDAO majorDAO = new MajorDAO();
            AcademicYearDAO academicYearDAO = new AcademicYearDAO();
            StudentDTO student = null;

            student = studentDAO.GetStudentById(Id);

            if (student!=null)
            {
                student.UniversityName = universityDAO.GetUniversityNameById(student.UniversityId);
                student.MajorName = majorDAO.GetMajorNameById(student.MajorId);
                student.AcademicyearName = academicYearDAO.GetAcademicYearNameById(student.AcademicyearId);
                student.RespCode = ResponseCode.C000;
                student.RespDescription = Message.M000;
            }
            responseModel = student;

            return responseModel;
        }
    }
}