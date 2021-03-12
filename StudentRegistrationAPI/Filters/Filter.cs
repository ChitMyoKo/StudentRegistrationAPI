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
using System.Web.Http.Results;
using System.Web.Routing;

namespace StudentRegistrationAPI.Filters
{
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string hardcodekey = Helper.HardCodeKeyForAES();
            string hardcodeIV = Helper.HardCodeIVForAES();

            UserService userService = new UserService();

            string paraKey = actionContext.ActionArguments.Keys.OfType<string>().FirstOrDefault();
            if (!string.IsNullOrEmpty(paraKey))
            {
                ApiRequestModel reqModel = actionContext.ActionArguments[paraKey] as ApiRequestModel;
                reqModel.SessionID = RijndaelCrypt.DecryptAES(reqModel.SessionID, hardcodekey, hardcodeIV);
                reqModel.UserId = RijndaelCrypt.DecryptAES(reqModel.UserId, hardcodekey, hardcodeIV);
                bool isSessionAlive = userService.CheckSessionAlive(reqModel.SessionID, reqModel.UserId);

                if (!isSessionAlive)
                {
                    BaseController baseController = new BaseController();
                    actionContext.Response = baseController.ConvertToHttpResponseMessage(ResponseCode.C098, Message.M098);
                }
            }
            base.OnActionExecuting(actionContext);
        }
    }
}