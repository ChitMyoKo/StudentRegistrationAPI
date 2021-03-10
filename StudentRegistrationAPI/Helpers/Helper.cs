using StudentRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static CheckNullResponse CheckNullWithObject(object requestModel, List<string> optioList)
        {
            var response = new CheckNullResponse();
            PropertyInfo[] infos = requestModel.GetType().GetProperties();

            foreach (PropertyInfo info in infos)
            {
                var skrip = false;
                foreach (var optStr in optioList)
                {
                    if (optStr == info.Name) skrip = true;
                }
                if (!skrip)
                {
                    if (info.GetValue(requestModel, null) != null)
                    {

                        if (string.IsNullOrEmpty(info.GetValue(requestModel, null).ToString()))
                        {
                            response.IsNotNull = false;
                            response.RespDescription = info.Name;
                            return response;
                        }
                    }
                    else
                    {
                        response.IsNotNull = false;
                        response.RespDescription = info.Name;
                        return response;
                    }
                }
            }
            response.IsNotNull = true;
            return response;
        }
    }
}