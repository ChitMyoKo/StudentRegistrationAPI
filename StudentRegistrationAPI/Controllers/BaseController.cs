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