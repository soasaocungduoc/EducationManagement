using EducationManagement.Controllers.Bases;
using EducationManagement.Dtos.OutputDtos;
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
        [ActionName("GetSlides")]
        public IHttpActionResult GetSlides([FromBody]SlideConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_slideService.GetSlides(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        [ActionName("GetSlideById")]
        public IHttpActionResult GetSlideById(int id)
        {
            try
            {
                var result = _slideService.GetSlideById(id);
                if (result == null)
                    return BadRequest("Cannot found");
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
