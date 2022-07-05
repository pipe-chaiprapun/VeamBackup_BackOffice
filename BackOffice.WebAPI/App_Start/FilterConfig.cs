using System.Web;
using System.Web.Mvc;

namespace BackOffice.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        public static bool IsDebugMode
        {
            get
            {
                bool isDebug = false;
                #if DEBUG
                     isDebug = true;
                #endif
                return isDebug;
            }
        }
    }
}
