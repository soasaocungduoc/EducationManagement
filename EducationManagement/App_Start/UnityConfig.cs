using EducationManagement.Services.Abstractions;
using EducationManagement.Services.Implementations;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace EducationManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IProfileService, ProfileService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}