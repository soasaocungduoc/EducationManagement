using EducationManagement.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EducationManagement.Controllers
{
    public class SemesterController : ApiController
    {
        private readonly ISemesterService _semesterService;
        public SemesterController(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        [HttpGet]
        [ActionName("GetSemesters")]
        public IHttpActionResult GetSemesters(int id)
        {
            try
            {
                return Ok(_semesterService.GetSemesters(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
