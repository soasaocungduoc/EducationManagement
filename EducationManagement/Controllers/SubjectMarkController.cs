using EducationManagement.Controllers.Bases;
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
    }
}
