using EducationManagement.Services.Abstractions;
using EducationManagement.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace EducationManagement.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            var token = Request.Headers.Contains("Token") ? Request.Headers.GetValues("Token") : null;

            if (token == null || token.FirstOrDefault() == "")
            {
                return Response(HttpStatusCode.Unauthorized, "Invalid token.");
            }

            return Ok(_userService.GetUserInfoById(id));
        }

        /// <summary>
        /// update user avatar
        /// </summary>
        [Route("avatar")]
        [HttpPost]
        public IHttpActionResult UpdateAvatar([FromBody] string url)
        {
            if(url == null)
            {
                return Response(HttpStatusCode.BadRequest, "Invalid avatar url.");
            }

            var token = Request.Headers.Contains("Token") ? Request.Headers.GetValues("Token") : null;


            if (token == null || token.FirstOrDefault() == "")
            {
                return Response(HttpStatusCode.Unauthorized, "Invalid token.");
            }

            var result = _userService.UpdateAvatar(token.FirstOrDefault(), url);

            if(result == false)
            {
                return Response(HttpStatusCode.BadRequest, "Fail to update.");
            }

            return Response(HttpStatusCode.OK, "Avatar is updated.");
        }

        private IHttpActionResult Response(HttpStatusCode statusCode, string message)
        {
            return ResponseMessage(new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(message)
            });
        }
    }
}
