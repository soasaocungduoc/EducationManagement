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
    public class SchoolYearController : BaseApiController
    {
        private readonly ISchoolYearService _schoolYearService;
        public SchoolYearController(ISchoolYearService schoolYearService)
        {
            _schoolYearService = schoolYearService;
        }

        [Authorize]
        [HttpGet]
        [ActionName("GetSchoolYears")]
        public IHttpActionResult GetSchoolYears()
        {
            try
            {
                return Ok(_schoolYearService.GetSchoolYears());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
