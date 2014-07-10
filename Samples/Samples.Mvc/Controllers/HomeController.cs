using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Samples.Mvc.Controllers
{
    using System.Configuration;
    using System.Threading.Tasks;
    using VisualStudioIntegreate.Client;
    using VisualStudioIntegreate.Configuration;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var app =
                (ConfigurationManager.GetSection("visualStudioIntegrateApplication") as
                    VisualStudioIntegrateApplicationConfigurationSection).GetApplicationCredentials();

            var redirectUrl = new VisualStudioIntegrateClient(app).Authentication.CreateAuthorizeUri(string.Empty);

            return this.Redirect(redirectUrl.AbsoluteUri);
        }

        public async Task<ActionResult> Callback(string authenticationToken)
        {
            var app =
                (ConfigurationManager.GetSection("visualStudioIntegrateApplication") as
                    VisualStudioIntegrateApplicationConfigurationSection).GetApplicationCredentials();

            using (var context = new VisualStudioIntegrateContext(app))
            {
                var token = await new VisualStudioIntegrateClient(app).Authentication.GetAccessTokenAsync(context,
                    authenticationToken);

                return this.Json(token, JsonRequestBehavior.AllowGet);
            }
        }
    }
}