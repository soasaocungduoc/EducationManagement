using System.Net;
using System.Net.Http;
using EducationManagement.Controllers.Bases;
using EducationManagement.Services.Abstractions;
using System.Web.Http;
using EducationManagement.Commons;
using EducationManagement.Dtos.InputDtos;

namespace EducationManagement.Controllers
{
    [RoutePrefix("api/news")]
    public class NewsController : BaseApiController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        [ActionName("GetNews")]
        public IHttpActionResult GetNews()
        {
            return Ok(_newsService.GetNews());
        }

        [HttpGet]
        [Route("{newsId}")]
        [ActionName("GetNewsById")]
        public IHttpActionResult GetNews(int newsId)
        {
            return Ok(_newsService.GetNews(newsId));
        }

        [Authorize]
        [HttpDelete]
        [Route("{newsId}")]
        public IHttpActionResult DeleteNews(int newsId)
        {
            var token = Request.GetAuthorizationHeader();

            if (AuthenticationValidation.IsAdminOrMod(token))
            {
                return ResponseMessage(_newsService.Delete(newsId)
                    ? Request.CreateResponse(HttpStatusCode.OK, "News is deleted.")
                    : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid news id."));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.Forbidden,
                "Only admin or mod can delete a news."));
        }

        [Authorize]
        [HttpPost]
        [Route]
        [ActionName("AddNews")]
        public IHttpActionResult AddNews([FromBody] NewsDto news)
        {
            var token = Request.GetAuthorizationHeader();

            if (!AuthenticationValidation.IsAdminOrMod(token))
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Forbidden,
                    "Only admin or mod can create a news."));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_newsService.AddNews(news)) return Ok("News created.");

            return BadRequest("An error occurred when adding news. Please try again.");
        }

        [Authorize]
        [HttpPost]
        [Route("{newsId}")]
        public IHttpActionResult UpdateNews(int newsId, [FromBody] NewsDto news)
        {
            var token = Request.GetAuthorizationHeader();

            if (!AuthenticationValidation.IsAdminOrMod(token))
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Forbidden,
                    "Only admin or mod can modify a news."));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_newsService.UpdateNews(newsId, news)) return Ok("News updated.");

            return BadRequest("Invalid news id.");
        }
    }
}
