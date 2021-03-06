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
    [RoutePrefix("API/University")]
    public class UniversityController : ApiController
    {
        string hardcodeIV = Helper.HardCodeIVForAES();
        private HttpResponseMessage responseMessage;
        
        [SessionFilter]
        [DecryptionFilter]
        [HttpPost]
        [Route("GetUniversityList")]
        public async Task<HttpResponseMessage> GetUniversityList(ApiRequestModel request)
        {
            ApiResponseModel response = new ApiResponseModel();
            UniversityListResponseModel responseModel = new UniversityListResponseModel();

            UniversityService universityService = new UniversityService();
            responseModel = universityService.GetAllUniversity();

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