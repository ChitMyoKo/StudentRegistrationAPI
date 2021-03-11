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
    public class HardcodeDecryptionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                string hardcodekey = Helper.HardCodeKeyForAES();
                string hardcodeIV = Helper.HardCodeIVForAES();

                UserService userService = new UserService();

                string key = actionContext.ActionArguments.Keys.OfType<string>().FirstOrDefault();

                if (!string.IsNullOrEmpty(key))
                {
                    ApiRequestModel reqModel = actionContext.ActionArguments[key] as ApiRequestModel;

                    reqModel.JsonStringRequest = RijndaelCrypt.DecryptAES(reqModel.JsonStringRequest, hardcodekey, hardcodeIV);

                    if(null == reqModel.JsonStringRequest)
                    {
                        BaseController baseController = new BaseController();
                        actionContext.Response = baseController.ConvertToHttpResponseMessage(ResponseCode.C014, Message.M014);
                    }

                    actionContext.ActionArguments.Remove(key);
                    actionContext.ActionArguments.Add(key, reqModel);
                }

                base.OnActionExecuting(actionContext);
            }
            catch (Exception e)
            {
                BaseController baseController = new BaseController();
                actionContext.Response = baseController.ConvertToHttpResponseMessage(ResponseCode.C014, Message.M014);
            } 
        }
    }
}