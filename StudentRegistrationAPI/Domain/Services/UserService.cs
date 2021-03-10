using StudentRegistrationAPI.Domain.DAO;
using StudentRegistrationAPI.Models;
using System;

namespace StudentRegistrationAPI.Domain.Services
{
    public class UserService
    {
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
                TimeSpan time = new TimeSpan(0, 0, 180, 0); // inactivity time 
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
            UserService userService = new UserService();

            return userService.GetDynamicKeyByUserId(userId);
        }
    }
}