using EducationManagement.Controllers.Bases;
using EducationManagement.Services.Abstractions;
using System.Linq;
using System.Web.Http;

namespace EducationManagement.Controllers
{

    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// update user avatar
        /// </summary>
        [Route("api/user/update/avatar")]
        [HttpPost]
        public IHttpActionResult UpdateAvatar([FromBody] string url)
        {
            if(url == null)
            {
                return BadRequest();
            }

            var token = Request.Headers.GetValues("Token");

            _userService.UpdateAvatar(token.FirstOrDefault(), url);

            return Ok();
        }
    }
}
