using EducationManagement.Controllers.Bases;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using System.Net;
using System.Net.Http;
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
        [HttpPost]
        [Route]
        [ActionName("AddSlide")]
        public IHttpActionResult AddSlide([FromBody] SlideDto slideDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = _slideService.AddSlide(slideDto);
                if (result == null)
                    return BadRequest("An error occurred when adding slide. Please try again.");
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ActionName("UpdateSlide")]
        public IHttpActionResult UpdateSlide(int id, [FromBody] SlideDto slideDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = _slideService.UpdateSlide(id,slideDto);
                if (result == null)
                    return BadRequest("An error occurred when updating slide. Please try again.");
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
