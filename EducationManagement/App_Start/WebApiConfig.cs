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

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
                
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //<-- SchoolInformation controller -->
            config.Routes.MapHttpRoute(
                "GetSchoolInformationApi",
                "api/schoolinformation",
                new { controller = "SchoolInformation", action = "GetSchoolInformation" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<-- News controller -->
            config.Routes.MapHttpRoute(
                "GetNewsApi",
                "api/news",
                new { controller = "News", action = "GetNews"},
                constraints : new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetNewsByIdApi",
                "api/news/{newsId}",
                new { controller = "News", action = "GetNewsById", newsId = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "AddNewsApi",
                "api/news",
                new { controller = "News", action = "AddNews" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                "UpdateNewsApi",
                "api/news/{newsId}",
                new { controller = "News", action = "UpdateNews", newsId = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );

            config.Routes.MapHttpRoute(
                "DeleteNewsApi",
                "api/news/{newsId}",
                new { controller = "News", action = "DeleteNews", newsId = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
            );

            //<-- Teacher controller -->
            config.Routes.MapHttpRoute(
                "GetTeachersApi",
                "api/teacher",
                new { controller = "Teacher", action = "GetTeachers"},
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<-- Slide controller -->

            config.Routes.MapHttpRoute(
                "GetSlideApi",
                "api/slide",
                new { controller = "Slide", action = "GetSlide" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetSlideByIdApi",
                "api/slide/{id}",
                new { controller = "Slide", action = "GetSlideById", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "AddSlideApi",
                "api/slide",
                new { controller = "Slide", action = "AddSlide" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                "UpdateSlideApi",
                "api/slide/{id}",
                new { controller = "Slide", action = "UpdateSlide", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );

            config.Routes.MapHttpRoute(
                "DeleteSlideApi",
                "api/slide/{id}",
                new { controller = "Slide", action = "DeleteSlide", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
            );
        }
    }
}
