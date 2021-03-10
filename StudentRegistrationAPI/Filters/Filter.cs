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

            string paraKey = filterContext.ActionParameters.Keys.OfType<string>().FirstOrDefault();
            if (!string.IsNullOrEmpty(paraKey))
            {
                TestModel testModel = filterContext.ActionParameters[paraKey] as TestModel;

                UserService userService = new UserService();

                //testModel.SessionID = RijndaelCrypt.DecryptAES(testModel.SessionID, hardcodekey, hardcodeIV);

                //bool isSessionAlive = userService.CheckSessionAlive(testModel.SessionID, testModel.UserId);

                //if (!isSessionAlive)
                //{
                //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "SessionExpired", controller = "Base" }));
                //}
                if(testModel.SessionID != "123")
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "SessionExpired", controller = "Base" }));
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}