using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Models
{
    public class StudentDeleteRequestModel
    {
        public string Id { get; set; }
    }

    public class StudentDeleteResponseModel : BaseResponseModel
    {
    }
}