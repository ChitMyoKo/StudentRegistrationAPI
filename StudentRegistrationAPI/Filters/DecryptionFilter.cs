using StudentRegistrationAPI.Domain.Services;
using StudentRegistrationAPI.Helpers;
using StudentRegistrationAPI.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentRegistrationAPI.Filters
{
    public class DecryptionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                string hardcodekey = Helper.HardCodeKeyForAES();
                string hardcodeIV = Helper.HardCodeIVForAES();
                string dynamickey = string.Empty;

                UserService userService = new UserService();

                string key = filterContext.ActionParameters.Keys.OfType<string>().FirstOrDefault();

                if (!string.IsNullOrEmpty(key))
                {
                    TestModel testModel = filterContext.ActionParameters[key] as TestModel;
                    //testModel.UserId = RijndaelCrypt.DecryptAES(testModel.UserId, hardcodekey, hardcodeIV);

                    //dynamickey = userService.GetDynamicKeyByUserId(testModel.UserId);
                    //testModel.JsonStringRequest = RijndaelCrypt.DecryptAES(testModel.JsonStringRequest, dynamickey, hardcodeIV);

                    testModel.JsonStringRequest = "modified json is here";
                    filterContext.ActionParameters.Remove(key);
                    filterContext.ActionParameters.Add(key, testModel);
                }

                base.OnActionExecuting(filterContext);
            }
            catch(Exception e)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "DecryptionError", controller = "Base" }));
            }
            
        }
    }
}