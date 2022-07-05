using Jose;
using System;
using System.Text;

namespace BackOffice.WebAPI.Authen
{
    public class Securities
    {
        private const int ExpireTimeToken = 60; //Minute
        private static UTF8Encoding encodeing = new UTF8Encoding();

        private static string SecurityKey = "BackUp Project";

        public static string JWTEncode(object payload)
        {
            try
            {
                return JWT.Encode(payload, UTF8Encoding.ASCII.GetBytes(SecurityKey), JwsAlgorithm.HS256);
            }
            catch
            {
                return null;
            }
        }

        public static T JWTDecode<T>(string token)
        {
            try
            {
                return JWT.Decode<T>(token, UTF8Encoding.ASCII.GetBytes(SecurityKey), JwsAlgorithm.HS256);
            }
            catch
            {
                return default(T);
            }
        }

        public static string Encode<T>(T data, int time = Securities.ExpireTimeToken)
        {
            JWTData<T> payload = new JWTData<T> { data = data, exp = Authentication.GetNow.AddMinutes(time).ToBinary() };
            return Securities.JWTEncode(payload);
        }

        public static T Decode<T>(string token)
        {
            JWTData<T> payload = Securities.JWTDecode<JWTData<T>>(token);
            if (payload != null)
            {
                if (new DateTime(payload.exp) >= Authentication.GetNow)
                {
                    return payload.data;
                }
            }
            return default(T);
        }

    }

    public class JWTData<T>
    {
        public T data { get; set; }
        public long exp { get; set; }
    }
}