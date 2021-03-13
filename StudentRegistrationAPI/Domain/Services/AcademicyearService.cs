using StudentRegistrationAPI.Domain.DAO;
using StudentRegistrationAPI.Models;
using StudentRegistrationAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Domain.Services
{
    public class AcademicyearService
    {
        public AcademicYearListResponseModel GetAllAcademicYearByMajorId(int majorId)
        {
            AcademicYearListResponseModel responseModel = new AcademicYearListResponseModel() { RespCode = ResponseCode.C000, RespDescription = Message.M000 };
            AcademicYearDAO yearDAO = new AcademicYearDAO();
            List<AcademicYearModel> yearList = new List<AcademicYearModel>();

            yearList = yearDAO.GetAllAcademicYearByMajorId(majorId);
            responseModel.YearList = yearList;

            return responseModel;
        }
    }
}