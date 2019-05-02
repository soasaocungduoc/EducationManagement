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
    public class SubjectController : BaseApiController
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        [ActionName("GetSubjects")]
        public IHttpActionResult GetSubjects()
        {
            try
            {
                return Ok(_subjectService.GetSubjects());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
