using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Models
{
    public class SessionModel
    {
        public string UserId { get; set; }
        public string SessionId { get; set; }
        public DateTime SessionExpDate { get; set; }
    }
}