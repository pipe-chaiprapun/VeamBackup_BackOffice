namespace BackOffice.WebAPI.Authen
{
    using Backup.ClassLibrary.Concrete;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Linq;

    public class JWTAuthorizeAttribute : AuthorizeAttribute
    {
        string[] roles = null;
        public JWTAuthorizeAttribute(params string[] role)
        {
            this.roles = role;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string token = HttpContext.Current.Request.Headers["Authorization"];
            if (token != null)
            {
                try
                {
                    Authentication decodeToken = Securities.JWTDecode<Authentication>(token);                    
                    if (Authentication.HasToken(decodeToken))
                    {
                        var usernames = new BackOfficeDB().BO_Employee.FirstOrDefault(c => c.emp_username.Equals(decodeToken.username));

                        for (int i = 0; i <= 4; i++)
                        {
                            var role_permission = this.roles[i];
                            
                            if (usernames != null & usernames.emp_permission.Equals(role_permission))
                            {
                                Authentication.SetAuthenticated(usernames);
                                return;
                            }
                        }
                    }
                    else
                    {
                        Authentication.SetAuthenticated(username: null);
                    }
                }
                catch
                { }
            }
            base.OnAuthorization(actionContext);
        }
    }
}