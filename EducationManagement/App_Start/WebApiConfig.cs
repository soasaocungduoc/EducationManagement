﻿using System.Net.Http;
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

            //<-- News controller -->
            config.Routes.MapHttpRoute(
                name: "GetNewsApi",
                routeTemplate: "api/news",
                defaults: new { controller = "News", action = "GetNews", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "GetNewsByIdApi",
                routeTemplate: "api/news",
                defaults: new { controller = "News", action = "GetNewsById", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "AddNewsApi",
                routeTemplate: "api/news",
                defaults: new { controller = "News", action = "AddNews", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );


            config.Routes.MapHttpRoute(
                name: "UpdateNewsApi",
                routeTemplate: "api/news",
                defaults: new { controller = "News", action = "UpdateNews", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );

            config.Routes.MapHttpRoute(
                name: "DeleteNewsApi",
                routeTemplate: "api/news",
                defaults: new { controller = "News", action = "DeleteNews", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
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
                defaults: new { controller = "Slide", action = "GetSlides", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "GetSlideByIdApi",
                routeTemplate: "api/slide",
                defaults: new { controller = "Slide", action = "GetSlideById", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "AddSlideApi",
                routeTemplate: "api/slide",
                defaults: new { controller = "Slide", action = "AddSlide", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                name: "UpdateSlideApi",
                routeTemplate: "api/slide",
                defaults: new { controller = "Slide", action = "UpdateSlide", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );

            config.Routes.MapHttpRoute(
                name: "DeleteSlideApi",
                routeTemplate: "api/slide",
                defaults: new { controller = "Slide", action = "DeleteSlide", id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
            );
        }
    }
}
