using Sitecore.Globalization;
using Sitecore.Marketing.Automation.Client.Filters;
using System.Globalization;
using System.Web.Http;
using Sitecore.Marketing.Automation.Client.Controllers;
using Sitecore.Marketing.Automation.Client;
using Sitecore;

namespace Sitecore.Support.Marketing.Automation.Client.Controllers
{
    /// <summary>
    /// Controller to get the current culture.
    /// </summary>
    [SitecoreAuthorizeFilter(Roles = "sitecore\\Marketing Automation Editors"), RoutePrefix("sitecore/api/ma/currentCulture194832")]
    // 20171122 ALEX: Must use different Class Name as there is an existing CurrentCultureController
    public class CurrentCulture194832Controller : BaseServicesApiController
    {
        /// <summary>
        /// Gets current culture
        /// </summary>
        /// <returns>Name of current culture.</returns>
        [HttpGet, Route]
        public IHttpActionResult Get()
        {
            string arg_29_0;
            if (!Settings.UseContextContentLanguage)
            {
                // 20171122Alex: Replace ContentLanguage with ClientLanguage
                arg_29_0 = Context.User.Profile.ClientLanguage;
            }
            else
            {
                Language expr_1D = Context.ContentLanguage;
                arg_29_0 = ((expr_1D != null) ? expr_1D.Name : null);
            }
            string text = arg_29_0;
            return this.Ok<string>(string.IsNullOrEmpty(text) ? new CultureInfo("en").Name : text);
        }
    }
}