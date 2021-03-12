using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Models
{
    public class AcademicYearListResponseModel : BaseResponseModel
    {
        public List<AcademicYearModel> YearList { get; set; }
    }
}