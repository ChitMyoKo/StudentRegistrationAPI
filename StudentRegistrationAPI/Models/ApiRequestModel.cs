using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Models
{
    public class ApiRequestModel
    {
        public string JsonStringRequest { get; set; }
        public string SessionID { get; set; }
        public string UserId { get; set; }
        public string DynamicKey { get; set; }
    }
}