using StudentRegistrationAPI.Domain.DAO;
using StudentRegistrationAPI.Models;
using StudentRegistrationAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Domain.Services
{
    public class UniversityService
    {
        public UniversityListResponseModel GetAllUniversity()
        {
            UniversityListResponseModel responseModel = new UniversityListResponseModel() { RespCode = ResponseCode.C000, RespDescription = Message.M000 };
            UniversityDAO universityDAO = new UniversityDAO();
            List<UniversityModel> universityList = new List<UniversityModel>();

            universityList = universityDAO.GetAllUniversity();
            responseModel.UniversityList = universityList;

            return responseModel;
        }
    }
}