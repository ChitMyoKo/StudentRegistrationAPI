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
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string hardcodekey = Helper.HardCodeKeyForAES();
            string hardcodeIV = Helper.HardCodeIVForAES();

            UserService userService = new UserService();

            string paraKey = filterContext.ActionParameters.Keys.OfType<string>().FirstOrDefault();
            if (!string.IsNullOrEmpty(paraKey))
            {
                ApiRequestModel reqModel = filterContext.ActionParameters[paraKey] as ApiRequestModel;
                reqModel.SessionID = RijndaelCrypt.DecryptAES(reqModel.SessionID, hardcodekey, hardcodeIV);

                bool isSessionAlive = userService.CheckSessionAlive(reqModel.SessionID, reqModel.UserId);

                if (!isSessionAlive)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "SessionExpired", controller = "Base" }));
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}