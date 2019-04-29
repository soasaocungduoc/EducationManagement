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
    public class TeacherController : BaseApiController
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [AdminAuthorization]
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

        [AdminAuthorization]
        [HttpPost]
        [ActionName("AddTeacher")]
        public IHttpActionResult AddTeacher([FromBody] TeacherDto dto)
        {
            if (dto == null)
            {
                return BadRequest("null input");
            }

            var result = _teacherService.Add(dto);

            if (result == true)
            {
                return Ok();
            }

            return BadRequest("invalid input");
        }

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetTeacher")]
        public IHttpActionResult GetTeacher(int teacherId)
        {
            var result = _teacherService.Get(teacherId);

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
