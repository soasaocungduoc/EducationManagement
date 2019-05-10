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
    public class GradeController : BaseApiController
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        [Authorize]
        [HttpGet]
        [ActionName("GetGrades")]
        public IHttpActionResult GetGrades()
        {
            try
            {
                return Ok(_gradeService.GetGrades());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
