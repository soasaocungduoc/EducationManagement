using EducationManagement.Controllers.Bases;
using EducationManagement.Services.Abstractions;
using System.Web.Http;

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
    }
}
