using EducationManagement.Controllers.Bases;
using EducationManagement.Fillters;
using EducationManagement.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EducationManagement.Controllers
{
    [AdminAuthorization]
    [RoutePrefix("api/teacher")]
    public class TeacherController : BaseApiController
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        [ActionName("GetTeachers")]
        public IHttpActionResult GetTeachers()
        {
            return Ok(_teacherService.GetListOfTeachers());
        }
    }
}
