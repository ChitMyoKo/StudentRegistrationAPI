using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Models
{
    public class LoginModel
    {
        public string UserId { get; set; }
        public string SessionId { get; set; }
        public string DynamicKey { get; set; }
        public DateTime SessionExpireDate { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime Logoutdate { get; set; }
    }
}