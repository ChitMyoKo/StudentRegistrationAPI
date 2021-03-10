using StudentRegistrationAPI.Filters;
using StudentRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationAPI.Controllers
{
    public class TestController : Controller
    {
        [SessionFilter]
        [DecryptionFilter]
        [HttpPost]
        [Route("Test")]
        public async Task<HttpResponseMessage> Test(TestModel test)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent("Success")
            };

            return await Task.FromResult(response);
        }
    }
}