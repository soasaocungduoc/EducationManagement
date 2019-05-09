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

            config.Routes.MapHttpRoute(
                "AddTeacherApi",
                "api/teacher",
                new { controller = "Teacher", action = "AddTeacher" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                "GetTeacherApi",
                "api/teacher/{teacherId}",
                new { controller = "Teacher", action = "GetTeacher", teacherId = RouteParameter.Optional},
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "UpdateTeacherApi",
                "api/teacher/{teacherId}",
                new { controller = "Teacher", action = "UpdateTeacher", teacherId = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );

            config.Routes.MapHttpRoute(
                "DeleteTeacherApi",
                "api/teacher/{teacherId}",
                new { controller = "Teacher", action = "DeleteTeacher", teacherId = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
            );
            //<-- Slide controller -->

            config.Routes.MapHttpRoute(
                "GetSlideApi",
                "api/slide",
                new { controller = "Slide", action = "GetSlides" },
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

            //<-- SchoolYear controller -->
            config.Routes.MapHttpRoute(
                "GetSchoolYearsApi",
                "api/schoolyear",
                new { controller = "SchoolYear", action = "GetSchoolYears" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<-- Semester controller -->
            config.Routes.MapHttpRoute(
                "GetSemestersByYearIdApi",
                "api/year/{id}/semesters",
                new { controller = "Semester", action = "GetSemestersByYearId", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<-- Student controller -->

            config.Routes.MapHttpRoute(
                "AddStudentsApi",
                "api/student",
                new { controller = "Student", action = "AddStudents"},
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                "GetStudentsByParentIdApi",
                "api/parent/{id}/students",
                new { controller = "Student", action = "GetStudentsByParentId", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetStudentsByClassId",
                "api/class/{id}/students",
                new { controller = "Student", action = "GetStudentsByClassId", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetStudentApi",
                "api/student/{studentId}",
                new { controller = "Student", action = "GetStudent", studentId = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "UpdateStudentApi",
                "api/student/{studentId}",
                new { controller = "Student", action = "UpdateStudent", studentId = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );

            config.Routes.MapHttpRoute(
                "DeleteStudentApi",
                "api/student/{studentId}",
                new { controller = "Student", action = "DeleteStudent", studentId = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
            );

            //<-- ScheduleSubject controller -->
            config.Routes.MapHttpRoute(
                "GetScheduleSubjectsByClassIdApi",
                "api/class/{id}/semester/{semesterId}/schedulers",
                new { controller = "ScheduleSubject", action = "GetScheduleSubjectsByClassId", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetScheduleSubjectsByStudentIdApi",
                "api/student/{id}/semester/{semesterId}/schedulers",
                new { controller = "ScheduleSubject", action = "GetScheduleSubjectsByStudentId", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetTeachingSchedulesByTeacherIdApi",
                "api/teacher/{id}/semester/{semesterId}/schedulers",
                new { controller = "ScheduleSubject", action = "GetTeachingSchedulesByTeacherId", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "AddScheduleSubjectsOfClassApi",
                "api/class/{classId}/semester/{semesterId}/schedulers",
                new { controller = "ScheduleSubject", action = "AddScheduleSubjectOfClass", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            //<-- Class controller -->
            config.Routes.MapHttpRoute(
                "GetClasses",
                "api/class",
                new { controller = "Class", action = "GetClasses" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetClassesByGradeId",
                "api/grade/{id}/class",
                new { controller = "Class", action = "GetClassesByGradeId", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetClassesByHomeroomTeacherIdApi",
                "api/teacher/{id}/class",
                new { controller = "Class", action = "GetClassesByHomeroomTeacherId", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetTeachingClassesByTeacherId",
                "api/teacher/{id}/teaching-class",
                new { controller = "Class", action = "GetTeachingClassesByTeacherId", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<--Account controller-->
            config.Routes.MapHttpRoute(
                "ChangePasswordApi",
                "api/account/{id}/password",
                new { controller = "Account", action = "ChangePassword", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );

            //<--User controller-->
            config.Routes.MapHttpRoute(
                "GetUsersApi",
                "api/user",
                new { controller = "User", action = "GetUsers"},
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "DeleteUserApi",
                "api/user/{id}",
                new { controller = "User", action = "DeleteUser", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
            );

            config.Routes.MapHttpRoute(
                "AddUserApi",
                "api/user",
                new { controller = "User", action = "AddUser" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
               "UpdateAvatarApi",
               "api/user/{userId}/avatar",
               new { controller = "User", action = "UpdateAvatar", userId = RouteParameter.Optional },
               constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
           );

            //<-- Grade controller -->
            config.Routes.MapHttpRoute(
                "GetGradesApi",
                "api/grade",
                new { controller = "Grade", action = "GetGrades" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<-- Subject controller -->
            config.Routes.MapHttpRoute(
                "GetSubjectsApi",
                "api/subject",
                new { controller = "Subject", action = "GetSubjects" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetSubjectBySubjectIdApi",
                "api/subject/{subjectId}",
                new { controller = "Subject", action = "GetSubjectBySubjectId", subjectId = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "AddSubjectApi",
                "api/subject",
                new { controller = "Subject", action = "AddSubject" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            //<-- Team controller -->
            config.Routes.MapHttpRoute(
                "GetTeamsApi",
                "api/team",
                new { controller = "Team", action = "GetTeams" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<-- SubjectMark controller -->
            config.Routes.MapHttpRoute(
                "GetSubjectMarksOfStudentApi",
                "api/student/{userId}/semester/{semesterId}/marks",
                new { controller = "SubjectMark", action = "GetSubjectMarksOfStudent", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "AddSubjectMarksforStudentsApi",
                "api/subjectmark",
                new { controller = "SubjectMark", action = "AddSubjectMarksforStudents"},
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                "GetMarkInClassApi",
                "api/teacher/{userId}/teaching-class/{classId}/semester/{semesterId}",
                new { controller = "SubjectMark", action = "GetMarkInClass", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<-- TypeMark controller -->
            config.Routes.MapHttpRoute(
                "GetTypeMarksApi",
                "api/type-mark",
                new { controller = "TypeMark", action = "GetTypeMarks" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<-- Notification controller -->
            config.Routes.MapHttpRoute(
                "AddNotificationApi",
                "api/notification",
                new { controller = "Notification", action = "AddNotification" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                "GetNotificationApi",
                "api/notification/receiver/{receiverId}",
                new { controller = "Notification", action = "GetNotification", receiverId = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetNotificationByIdApi",
                "api/notification/{id}",
                new { controller = "Notification", action = "GetNotificationById", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<-- Request controller -->
            config.Routes.MapHttpRoute(
                "GetAllRequestApi",
                "api/request",
                new { controller = "Request", action = "GetAllRequest" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetUserRequestApi",
                "api/request/user",
                new { controller = "Request", action = "GetUserRequest" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "AddRequestApi",
                "api/request",
                new { controller = "Request", action = "AddRequest" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                "GetRequestApi",
                "api/request/{requestId}",
                new { controller = "Request", action = "GetRequest", requestId = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //<-- Parent controller -->
            config.Routes.MapHttpRoute(
                "GetParentsApi",
                "api/parent",
                new { controller = "Parent", action = "GetParents" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "GetParentsByClassIdApi",
                "api/class/{classId}/parents",
                new { controller = "Parent", action = "GetParentsByClassId", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                "AddParentApi",
                "api/parent",
                new { controller = "Parent", action = "AddParent" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );
        }
    }
}
