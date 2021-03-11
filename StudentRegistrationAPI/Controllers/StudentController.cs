using Newtonsoft.Json;
using StudentRegistrationAPI.Domain.Services;
using StudentRegistrationAPI.Filters;
using StudentRegistrationAPI.Helpers;
using StudentRegistrationAPI.Models;
using StudentRegistrationAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace StudentRegistrationAPI.Controllers
{
    [RoutePrefix("API/Student")]
    public class StudentController : ApiController
    {
        BaseController baseController;
        string hardcodeKey = Helper.HardCodeKeyForAES();
        string hardcodeIV = Helper.HardCodeIVForAES();
        private HttpResponseMessage responseMessage;

        [SessionFilter]
        [DecryptionFilter]
        [HttpPost]
        [Route("Create")]
        public async Task<HttpResponseMessage> Register(ApiRequestModel request)
        {
            ApiResponseModel response = new ApiResponseModel();
            CreateStudentRequestModel requestModel = new CreateStudentRequestModel();
            CreateStudentResponseModel responseModel = new CreateStudentResponseModel();

            requestModel = JsonConvert.DeserializeObject<CreateStudentRequestModel>(request.JsonStringRequest);

            #region Check Null

            var lstOptStr = new List<string>() { "Email" };

            var checkResponse = Helper.CheckNullWithObject(requestModel, lstOptStr);
            if (!checkResponse.IsNotNull)
            {
                return await Task.FromResult(baseController.ConvertToHttpResponseMessage(ResponseCode.C008, checkResponse.RespDescription + Message.M008));
            }

            #endregion

            StudentService studentService = new StudentService();
            responseModel = studentService.AddStudent(requestModel, request.UserId);

            var responseData = JsonConvert.SerializeObject(responseModel);
            response.JsonStringResponse = RijndaelCrypt.EncryptAES(responseData, hardcodeKey, hardcodeIV);
            response.RespCode = responseModel.RespCode;
            response.RespDescription = responseModel.RespDescription;

            responseMessage = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(response))
            };

            return await Task.FromResult(responseMessage);
        }

        [SessionFilter]
        [DecryptionFilter]
        [HttpPost]
        [Route("GetStudentList")]
        public async Task<HttpResponseMessage> GetStudentList(ApiRequestModel request)
        {
            ApiResponseModel response = new ApiResponseModel();
            StudentListResponseModel responseModel = new StudentListResponseModel();

            StudentService studentService = new StudentService();
            responseModel = studentService.GetAllStudents();

            var responseData = JsonConvert.SerializeObject(responseModel);
            response.JsonStringResponse = RijndaelCrypt.EncryptAES(responseData, hardcodeKey, hardcodeIV);
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