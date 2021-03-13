using StudentRegistrationAPI.Domain.DAO;
using StudentRegistrationAPI.Models;
using StudentRegistrationAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Domain.Services
{
    public class MajorService
    {
        public MajorListResponseModel GetAllMajorByUniversityId(int universityId)
        {
            MajorListResponseModel responseModel = new MajorListResponseModel() { RespCode = ResponseCode.C000, RespDescription = Message.M000 };
            MajorDAO majorDAO = new MajorDAO();
            List<MajorModel> majorList = new List<MajorModel>();

            majorList = majorDAO.GetAllMajorByUniversityId(universityId);
            responseModel.MajorList = majorList;

            return responseModel;
        }
    }
}