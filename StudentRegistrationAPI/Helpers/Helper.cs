using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationAPI.Helpers
{
    public class Helper
    {
        public static string HardCodeKeyForAES()
        {
            return "560A18CD-6346-4CF0-A2E8-671F9B6B9EA9";
        }

        public static string HardCodeIVForAES()
        {
            return "CTfKxBSt6tkBv3E5";
        }
    }
}