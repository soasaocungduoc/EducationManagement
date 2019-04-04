using EducationManagement.Controllers.Bases;
using EducationManagement.Services.Abstractions;
using System.Web.Http;

namespace EducationManagement.Controllers
{
    [RoutePrefix("api/slide")]
    public class SlideController : BaseApiController
    {
        private readonly ISlideService _slideService;

        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
        }

        [HttpGet]
        public IHttpActionResult GetSlides()
        {
            return Ok(_slideService.GetSlides());
        }
    }
}
