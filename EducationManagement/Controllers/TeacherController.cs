using EducationManagement.Controllers.Bases;
using EducationManagement.Dtos.InputDtos;
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
    public class TeacherController : BaseApiController
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        [ActionName("GetTeachers")]
        public IHttpActionResult GetTeachers([FromBody]TeacherConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_teacherService.GetListOfTeachers(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
