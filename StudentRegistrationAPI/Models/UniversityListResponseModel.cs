using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Models
{
    public class UniversityListResponseModel : BaseResponseModel
    {
        public List<UniversityModel> UniversityList { get; set; }
    }
}