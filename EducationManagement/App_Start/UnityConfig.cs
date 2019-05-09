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
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<INewsService, NewsService>();
            container.RegisterType<ISchoolInformationService, SchoolInformationService>();
            container.RegisterType<ISlideService, SlideService>();
            container.RegisterType<ITeacherService, TeacherService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<ISchoolYearService, SchoolYearService>();
            container.RegisterType<ISemesterService, SemesterService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IScheduleSubjectService, ScheduleSubjectService>();
            container.RegisterType<IClassService, ClassService>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IGradeService, GradeService>();
            container.RegisterType<ISubjectService, SubjectService>();
            container.RegisterType<ITeamService, TeamService>();
            container.RegisterType<ISubjectMarkService, SubjectMarkService>();
            container.RegisterType<ITypeMarkService, TypeMarkService>();
            container.RegisterType<INotificationService, NotificationService>();
            container.RegisterType<IParentService, ParentService>();
            container.RegisterType<IRequestService, RequestService>();



            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}