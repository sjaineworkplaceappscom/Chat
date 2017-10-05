using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ewApps.CommonRuntime.Common;

namespace ewApps.Chat.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            EwAppSessionManager.LocalSession = false;
            EwAppSessionManager.GetSessionId += GetRequesterSessionId;
        }

        /// <summary>
        /// This method return the current session id.
        /// </summary>
        /// <returns>Current session id.</returns>
        public string GetRequesterSessionId() {
          if (HttpContext.Current.Request.Headers.AllKeys.Contains(Constants.EwpAccessTokenKey))
            return HttpContext.Current.Request.Headers.GetValues(Constants.EwpAccessTokenKey).FirstOrDefault();
          else
            return string.Empty;
        }
    }
}
