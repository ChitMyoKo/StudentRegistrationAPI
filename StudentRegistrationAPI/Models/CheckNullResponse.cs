using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Models
{
    public class CheckNullResponse
    {
        public bool IsNotNull { get; set; }
        public string RespDescription { get; set; }
    }
}