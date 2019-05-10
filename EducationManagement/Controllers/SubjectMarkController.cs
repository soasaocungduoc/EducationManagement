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
    public class SubjectMarkController : BaseApiController
    {
        private readonly ISubjectMarkService _subjectMarkService;

        public SubjectMarkController(ISubjectMarkService subjectMarkService)
        {
            _subjectMarkService = subjectMarkService;
        }

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetSubjectMarksOfStudent")]
        public IHttpActionResult GetSubjectMarksOfStudent(int userId, int semesterId)
        {
            try
            {
                var result = _subjectMarkService.GetSubjectMarks(userId, semesterId);
                if (result == null)
                    return BadRequest("Cannot found this student");
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetMarkInClass")]
        public IHttpActionResult GetMarkInClass(int userId, int semesterId, int classId)
        {
            try
            {
                var result = _subjectMarkService.GetMarksInClass(classId, semesterId, userId);
                if (result == null)
                    return BadRequest("Cannot found");
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [AdminAuthorization]
        [HttpPost]
        [ActionName("AddSubjectMarksforStudents")]
        public IHttpActionResult AddSubjectMarksforStudents([FromBody] SubjectMarkDto dto)
        {
            var result = _subjectMarkService.Add(dto);

            if(result == false)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
