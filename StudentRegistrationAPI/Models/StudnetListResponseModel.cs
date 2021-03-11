using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Models
{
    public class StudentListResponseModel : BaseResponseModel
    {
        public List<StudentDTO> studentList { get; set; }
    }
}