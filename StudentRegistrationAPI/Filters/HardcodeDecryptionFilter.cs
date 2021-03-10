using StudentRegistrationAPI.Domain.Services;
using StudentRegistrationAPI.Helpers;
using StudentRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentRegistrationAPI.Filters
{
    public class HardcodeDecryptionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                string hardcodekey = Helper.HardCodeKeyForAES();
                string hardcodeIV = Helper.HardCodeIVForAES();

                UserService userService = new UserService();

                string key = filterContext.ActionParameters.Keys.OfType<string>().FirstOrDefault();

                if (!string.IsNullOrEmpty(key))
                {
                    ApiRequestModel reqModel = filterContext.ActionParameters[key] as ApiRequestModel;
                    
                    reqModel.JsonStringRequest = RijndaelCrypt.DecryptAES(reqModel.JsonStringRequest, hardcodekey, hardcodeIV);

                    filterContext.ActionParameters.Remove(key);
                    filterContext.ActionParameters.Add(key, reqModel);
                }

                base.OnActionExecuting(filterContext);
            }
            catch (Exception e)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "DecryptionError", controller = "Base" }));
            }
        }
    }
}