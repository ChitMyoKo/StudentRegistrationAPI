using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Models
{
    public class MajorListResponseModel : BaseResponseModel
    {
        public List<MajorModel> MajorList { get; set; }
    }
}