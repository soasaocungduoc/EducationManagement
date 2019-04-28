using EducationManagement.Services.Abstractions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EducationManagement.Commons;
using EducationManagement.Controllers.Bases;
using Newtonsoft.Json;
using EducationManagement.Dtos.InputDtos;

namespace EducationManagement.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("{userId}")]
        [HttpGet]
        public IHttpActionResult GetUserById(int userId)
        {
            var token = Request.Headers.GetValues("Authorization").First();
            return ValidatePermission(token, userId)
                ? Ok(_userService.GetUserInfoById(userId))
                : Response(HttpStatusCode.Unauthorized, "Not allowed.");
        }

        [Route("{userId}")]
        [HttpPut]
        public IHttpActionResult UpdateUserById(int userId, [FromBody] UserDto user)
        {
            var token = Request.GetAuthorizationHeader();

            if (!ValidatePermission(token, userId))
            {
                return Response(HttpStatusCode.Unauthorized, "Not allowed.");
            }

            if (ModelState.IsValid)
            {
                var result = _userService.UpdateUser(user, userId);

                return result == null
                    ? Response(HttpStatusCode.BadRequest, "Fail to update.")
                    : Ok(result);

            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// update user avatar
        /// </summary>
        [Route("{userId}/avatar")]
        [HttpPut]
        public IHttpActionResult UpdateAvatar(int userId, [JsonProperty("avatar_url")] [FromBody] UrlDto dto)
        {
            if(dto == null)
            {
                return Response(HttpStatusCode.BadRequest, "Invalid or missing avatar url.");
            }

            var token = Request.Headers.GetValues("Authorization").First();

            if (!ValidatePermission(token, userId))
            {
                return Response(HttpStatusCode.Unauthorized, "Not allowed.");
            }

            var result = _userService.UpdateAvatar(userId, dto);

            return result == false
                ? Response(HttpStatusCode.BadRequest, "Fail to update.")
                : Response(HttpStatusCode.OK, "Avatar is updated.");
        }

        [HttpGet]
        [ActionName("GetUsers")]
        public IHttpActionResult GetUsers()
        {
            try
            {
                return Ok(_userService.GetUsers());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        private IHttpActionResult Response(HttpStatusCode statusCode, string message)
        {
            return ResponseMessage(new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(message)
            });
        }

        private static bool ValidatePermission(string token, int userId)
        {
            var tokenInformation = JwtAuthenticationExtensions.ExtractTokenInformation(token);
            if (tokenInformation == null) return false;
            return tokenInformation.GroupName == "Admin" ||
                   tokenInformation.GroupName == "Mod" ||
                   tokenInformation.UserId == userId;
        }

        
    }
}
