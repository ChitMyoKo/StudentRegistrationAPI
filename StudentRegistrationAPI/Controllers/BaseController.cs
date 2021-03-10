using Newtonsoft.Json;
using StudentRegistrationAPI.Models;
using StudentRegistrationAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationAPI.Controllers
{
    public class BaseController : Controller
    {
        private HttpResponseMessage responseMessage;

        public async Task<HttpResponseMessage> SessionExpired()
        {
            var response = new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized
            };

            return await Task.FromResult(response);
        }

        public async Task<HttpResponseMessage> DecryptionError()
        {
            ApiResponseModel response = new ApiResponseModel();
            response.RespCode = ResponseCode.C014;
            response.RespDescription = Message.M014;

            responseMessage = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(response))
            };

            return await Task.FromResult(responseMessage);
        }

        public HttpResponseMessage ConvertToHttpResponseMessage(string RespCode, string RespDescription)
        {
            ApiResponseModel model = new ApiResponseModel();
            model.RespCode = RespCode;
            model.RespDescription = RespDescription;

            HttpResponseMessage response = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(model))
            };

            return response;
        }
    }
}