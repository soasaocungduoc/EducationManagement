using EducationManagement.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EducationManagement.Fillters
{
    /// <summary>
    /// Kiểm tra request trước khi đưa đến action của controller.
    /// Author       :   TramHTD - 14/04/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   EducationManagement
    /// Copyright    :   Team SaoCungDuoc
    /// Version      :   1.0.0
    /// </remarks>
    public class AdminAuthorization : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Ghi đè phương thức dùng để lọc request.
        /// Author       :   TramHTD - 14/04/2018 - create
        /// </summary>
        /// <param name="actionContext">
        /// Data của 1 request.
        /// </param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Not allowed.");
            }
            else
            {
                string token = actionContext.Request.GetAuthorizationHeader();
                var tokenInformation = JwtAuthenticationExtensions.ExtractTokenInformation(token);
                if (tokenInformation == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Not allowed.");
                }
                else
                {
                    var route = actionContext.RequestContext.RouteData;
                    string controller = (string)route.Values["controller"];
                    string action = (string)route.Values["action"];
                    if (!AccountVerification.CheckAuthentication(token, controller, action))
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.NotAcceptable, "Not accept.");
                    }
                }
            }
        }
    }
}