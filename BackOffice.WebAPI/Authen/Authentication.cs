using Backup.ClassLibrary.Entity;
using System;
using System.Linq;

namespace BackOffice.WebAPI.Authen
{
    public class Authentication 
    {
        private const int ExpireTimeToken = 60; //Minute
        private static string _Token = null;
        private static BO_Employee _User = null;

        public string username { get; set; }
        public string email { get; set; }
        public long exp { get; set; }

        public static string Token { get { return Authentication._Token; } }

        public static BO_Employee User
        {
            get { return Authentication._User; }
        }

        public static string SetAuthenticated(BO_Employee custObj, int time = Authentication.ExpireTimeToken)
        {
            if (custObj == null)
            {
                Authentication._User = null;
                Authentication._Token = null;
                return null;
            }

            Authentication._Token = Securities.JWTEncode(new Authentication { username = custObj.emp_username, exp = GetNow.AddMinutes(time).ToBinary() });
            Authentication._User = custObj;

            return Authentication._Token;
        }

        public static string SetAuthenticated(string username, int time = Authentication.ExpireTimeToken)
        {
            if (string.IsNullOrEmpty(username))
            {
                Authentication._User = null;
                Authentication._Token = null;
                return null;
            }

            Authentication._Token = Securities.JWTEncode(new Authentication { username = username, exp = GetNow.AddMinutes(time).ToBinary() });

            return Authentication._Token;
        }

        // Check time of Token if time to the end
        public static bool HasToken(Authentication auth)
        {
            if (auth != null)
                return new DateTime(auth.exp) >= Authentication.GetNow;
            return false;
        }

        // Set Time Zone
        public static DateTime GetNow
        {
            get
            {
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                return TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            }
        }
    }
}