using Newtonsoft.Json;
using StudentRegistrationAPI.Controllers;
using StudentRegistrationAPI.Domain.Services;
using StudentRegistrationAPI.Helpers;
using StudentRegistrationAPI.Models;
using StudentRegistrationAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace StudentRegistrationAPI.Filters
{
    public class DecryptionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            try
            {
                string hardcodekey = Helper.HardCodeKeyForAES();
                string hardcodeIV = Helper.HardCodeIVForAES();
                string dynamickey = string.Empty;

                UserService userService = new UserService();

                string key = filterContext.ActionArguments.Keys.OfType<string>().FirstOrDefault();

                if (!string.IsNullOrEmpty(key))
                {
                    ApiRequestModel reqModel = filterContext.ActionArguments[key] as ApiRequestModel;
                    
                    dynamickey = userService.GetDynamicKeyByUserId(reqModel.UserId);
                    reqModel.DynamicKey = dynamickey;
                    reqModel.JsonStringRequest = RijndaelCrypt.DecryptAES(reqModel.JsonStringRequest, dynamickey, hardcodeIV);

                    filterContext.ActionArguments.Remove(key);
                    filterContext.ActionArguments.Add(key, reqModel);
                }

                base.OnActionExecuting(filterContext);
            }
            catch(Exception e)
            {
                BaseController baseController = new BaseController();
                filterContext.Response = baseController.ConvertToHttpResponseMessage(ResponseCode.C014, Message.M014);
                //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "DecryptionError", controller = "Base" }));
            }
        }
    }
}