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
    public class SemesterController : BaseApiController
    {
        private readonly ISemesterService _semesterService;
        public SemesterController(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        [Authorize]
        [HttpGet]
        [ActionName("GetSemestersByYearId")]
        public IHttpActionResult GetSemestersByYearId(int id)
        {
            try
            {
                return Ok(_semesterService.GetSemestersByYearId(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
