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
    [RoutePrefix("API/Account")]
    public class AccountController : ApiController
    {
        BaseController baseController;
        string hardcodeKey = Helper.HardCodeKeyForAES();
        string hardcodeIV = Helper.HardCodeIVForAES();
        private HttpResponseMessage responseMessage;

        [HardcodeDecryptionFilter]
        [HttpPost]
        [Route("Register")]
        public async Task<HttpResponseMessage> Register(ApiRequestModel request)
        {
            ApiResponseModel response = new ApiResponseModel();
            AccountCreateRequestModel requestModel = new AccountCreateRequestModel();
            AccountCreateResponseModel responseModel = new AccountCreateResponseModel();

            requestModel = JsonConvert.DeserializeObject<AccountCreateRequestModel>(request.JsonStringRequest);

            #region Check Null

            var lstOptStr = new List<string>() { "UserId" };

            var checkResponse = Helper.CheckNullWithObject(requestModel, lstOptStr);
            if (!checkResponse.IsNotNull)
            {
                return await Task.FromResult(baseController.ConvertToHttpResponseMessage(ResponseCode.C008, checkResponse.RespDescription + Message.M008));
            }

            #endregion

            UserService userService = new UserService();
            responseModel = userService.CreateUserAccount(requestModel);

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

        [HardcodeDecryptionFilter]
        [HttpPost]
        [Route("Login")]
        public async Task<HttpResponseMessage> Login(ApiRequestModel request)
        {
            ApiResponseModel response = new ApiResponseModel();
            LoginRequestModel requestModel = new LoginRequestModel();
            LoginResposeModel responseModel = new LoginResposeModel();

            requestModel = JsonConvert.DeserializeObject<LoginRequestModel>(request.JsonStringRequest);

            #region Check Null

            var lstOptStr = new List<string>() { "UserName", "Email" };

            var checkResponse = Helper.CheckNullWithObject(requestModel, lstOptStr);
            if (!checkResponse.IsNotNull)
            {
                return await Task.FromResult(baseController.ConvertToHttpResponseMessage(ResponseCode.C008, checkResponse.RespDescription + Message.M008));
            }

            #endregion

            UserService userService = new UserService();
            responseModel = userService.Login(requestModel);

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