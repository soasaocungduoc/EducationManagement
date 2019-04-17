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
            //<-- SchoolInformation controller -->
            config.Routes.MapHttpRoute(
                name: "GetSchoolInformationApi",
                routeTemplate: "api/schoolinformation",
                defaults: new { controller = "SchoolInformation", action = "GetSchoolInformation", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<-- Teacher controller -->
            config.Routes.MapHttpRoute(
                name: "GetTeachersApi",
                routeTemplate: "api/teacher",
                defaults: new { controller = "Teacher", action = "GetTeachers", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<-- Slide controller -->
            config.Routes.MapHttpRoute(
                name: "GetSlidesApi",
                routeTemplate: "api/slide",
                defaults: new { controller = "SLide", action = "GetSlides", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "GetSlideByIdApi",
                routeTemplate: "api/slide",
                defaults: new { controller = "SLide", action = "GetSlideById", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

        }
    }
}
