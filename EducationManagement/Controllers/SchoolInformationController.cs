using System.Web.Http;
using EducationManagement.Controllers.Bases;
using EducationManagement.Services.Abstractions;

namespace EducationManagement.Controllers
{
    [RoutePrefix("api/schoolinformation")]
    public class SchoolInformationController : BaseApiController
    {
        private readonly ISchoolInformationService _schoolInformationService;

        public SchoolInformationController(ISchoolInformationService schoolInformationService)
        {
            _schoolInformationService = schoolInformationService;
        }

        [HttpGet]
        [ActionName("GetSchoolInformation")]
        public IHttpActionResult GetSchoolInformation()
        {
            return Ok(_schoolInformationService.GetSchoolInformation());
        }
    }
}
