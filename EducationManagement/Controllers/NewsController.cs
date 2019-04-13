using System.Net;
using System.Net.Http;
using EducationManagement.Controllers.Bases;
using EducationManagement.Services.Abstractions;
using System.Web.Http;
using EducationManagement.Commons;

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
        public IHttpActionResult GetNews()
        {
            return Ok(_newsService.GetNews());
        }

        [HttpGet]
        [Route("{newsId}")]
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
    }
}
