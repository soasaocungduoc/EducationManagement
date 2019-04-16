using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using EducationManagement.Commons;

namespace EducationManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new TokenValidationHandler());
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                
                defaults: new { id = RouteParameter.Optional }
            );


            //<-- Teacher controller -->
            config.Routes.MapHttpRoute(
                name: "GetTeachersApi",
                routeTemplate: "api/teacher",
                defaults: new { controller = "Teacher", action = "GetTeachers", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

        }
    }
}
