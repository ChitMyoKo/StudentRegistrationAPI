using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Models
{
    public class ApiResponseModel
    {
        public string JsonStringResponse { get; set; }
        public string RespCode { get; set; }
        public string RespDescription { get; set; }
    }
}