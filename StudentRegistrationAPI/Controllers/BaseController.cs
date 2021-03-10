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
            var response = new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized
            };

            return await Task.FromResult(response);
        }
    }
}