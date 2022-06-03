using CarSalesAPI.App_Start;
using System.Web.Http;

namespace CarSalesAPI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
