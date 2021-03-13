using Newtonsoft.Json;
using StudentRegistrationAPI.Domain.Services;
using StudentRegistrationAPI.Filters;
using StudentRegistrationAPI.Helpers;
using StudentRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace StudentRegistrationAPI.Controllers
{
    [RoutePrefix("API/Academicyear")]
    public class AcademicyearController : ApiController
    {
        string hardcodeIV = Helper.HardCodeIVForAES();
        private HttpResponseMessage responseMessage;

        [SessionFilter]
        [DecryptionFilter]
        [HttpPost]
        [Route("GetAcademicyearList")]
        public async Task<HttpResponseMessage> GetAcademicyearList(ApiRequestModel request)
        {
            ApiResponseModel response = new ApiResponseModel();
            AcademicYearModel academicYearModel = new AcademicYearModel();
            AcademicYearListResponseModel responseModel = new AcademicYearListResponseModel();

            AcademicyearService yearService = new AcademicyearService();

            academicYearModel = JsonConvert.DeserializeObject<AcademicYearModel>(request.JsonStringRequest);
            responseModel = yearService.GetAllAcademicYearByMajorId(Int32.Parse(academicYearModel.MajorId));

            var responseData = JsonConvert.SerializeObject(responseModel);
            response.JsonStringResponse = RijndaelCrypt.EncryptAES(responseData, request.DynamicKey, hardcodeIV);
            response.RespCode = responseModel.RespCode;
            response.RespDescription = responseModel.RespDescription;

            responseMessage = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(response))
            };

            return await Task.FromResult(responseMessage);
        }
    }
}