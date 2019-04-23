using EducationManagement.Controllers.Bases;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Fillters;
using EducationManagement.Services.Abstractions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EducationManagement.Controllers
{
    
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

        [AdminAuthorization]
        [HttpPost]
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

        [AdminAuthorization]
        [HttpPut]
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

        [AdminAuthorization]
        [HttpDelete]
        [ActionName("DeleteSlide")]
        public IHttpActionResult DeleteSlide(int id)
        {
            try
            {
                return ResponseMessage(_slideService.DeleteSlide(id)
                    ? Request.CreateResponse(HttpStatusCode.OK, "slide is deleted.")
                    : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid slide id."));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
