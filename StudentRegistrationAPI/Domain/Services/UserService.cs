using StudentRegistrationAPI.Domain.DAO;
using StudentRegistrationAPI.Models;
using StudentRegistrationAPI.Resources;
using System;

namespace StudentRegistrationAPI.Domain.Services
{
    public class UserService
    {
        public AccountCreateResponseModel CreateUserAccount(AccountCreateRequestModel requestModel)
        {
            AccountCreateResponseModel responseModel = new AccountCreateResponseModel() { RespCode = ResponseCode.C000, RespDescription = Message.M000 };
            UserDAO userDAO = new UserDAO();

            bool doesUsernameExist = userDAO.CheckUsernameExist(requestModel.UserName);
            if (doesUsernameExist)
            {
                responseModel.RespCode = ResponseCode.C001;
                responseModel.RespDescription = Message.M001;
                return responseModel;
            }

            bool doesEmailExist = userDAO.CheckEmailExist(requestModel.Email);
            if (doesEmailExist)
            {
                responseModel.RespCode = ResponseCode.C002;
                responseModel.RespDescription = Message.M002;
                return responseModel;
            }

            requestModel.UserId = Guid.NewGuid().ToString();
            userDAO.CreateUserAccount(requestModel);

            return responseModel;
        }

        public LoginResposeModel Login(LoginRequestModel requestModel)
        {
            LoginResposeModel resposeModel = new LoginResposeModel() { RespCode = ResponseCode.C000, RespDescription = Message.M000 };
            UserDAO userDAO = new UserDAO();

            User userInfo = userDAO.GetUserByUsernameOrEmail(requestModel.UserName, requestModel.Email);

            if(userInfo == null)
            {
                resposeModel.RespCode = ResponseCode.C003;
                resposeModel.RespDescription = Message.M003;
                return resposeModel;
            }

            if (userInfo.Password != requestModel.Password)
            {
                resposeModel.RespCode = ResponseCode.C004;
                resposeModel.RespDescription = Message.M004;
                return resposeModel;
            }

            string sessionId = Guid.NewGuid().ToString().ToUpper();
            string dynamicKey = Guid.NewGuid().ToString().ToUpper();

            DateTime now = DateTime.Now;
            TimeSpan sessionDuration = new TimeSpan(0, 0, 15, 0); // session duration
            DateTime expireTime = now.Add(sessionDuration);

            LoginModel loginModel = new LoginModel();

            loginModel.UserId = userInfo.UserId;
            loginModel.SessionId = sessionId;
            loginModel.DynamicKey = dynamicKey;

            loginModel.SessionExpireDate = expireTime;
            loginModel.LoginDate = DateTime.Now;

            LoginDAO loginDAO = new LoginDAO();
            loginDAO.Insert(loginModel);

            int result = userDAO.UpdateDynamicKeyAndLoginstatus(userInfo.UserId, dynamicKey, "1");

            if(result <= 0)
            {
                resposeModel.RespCode = ResponseCode.C014;
                resposeModel.RespDescription = Message.M014;
                return resposeModel;
            }

            resposeModel.DynamicKey = dynamicKey;
            resposeModel.SessionId = sessionId;
            resposeModel.UserId = userInfo.UserId;
            resposeModel.FullName = userInfo.FullName;
            resposeModel.UserName = userInfo.UserName;

            return resposeModel;
        }

        public bool CheckSessionAlive(string sessionId, string userId)
        {
            bool result = false;

            UserDAO userDAO = new UserDAO();
            LoginDAO loginDAO = new LoginDAO();

            DateTime expireTime = loginDAO.getSessionById(sessionId);

            DateTime nowdate = DateTime.Now;
            int value = DateTime.Compare(expireTime, nowdate);

            if (value > 0)
            {
                DateTime date = DateTime.Now;
                TimeSpan time = new TimeSpan(0, 0, 15, 0); // inactivity time 
                DateTime combined = date.Add(time);

                //update session expire time in login table
                SessionModel remodel = new SessionModel();
                remodel.UserId = userId;
                remodel.SessionId = sessionId;
                remodel.SessionExpDate = combined;
                loginDAO.UpdateSessionExpiredDateByUserId(remodel);

                result = true;
            }
            else
            {
                loginDAO.UpdateLogoutDateByUserid(userId, sessionId); // update logout date
                userDAO.UpdateIsLoginStatusByUserId(userId, "0"); // update isLogin flag
            }

            return result;
        }
        
        public string GetDynamicKeyByUserId(string userId)
        {
            UserDAO userDAO = new UserDAO();

            return userDAO.GetDynamicKeyByUserId(userId);
        }
    }
}