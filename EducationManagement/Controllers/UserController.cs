using EducationManagement.Services.Abstractions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EducationManagement.Commons;
using EducationManagement.Controllers.Bases;
using Newtonsoft.Json;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Fillters;

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
        [AdminAuthorization]
        [HttpPut]
        [ActionName("UpdateAvatar")]
        public IHttpActionResult UpdateAvatar(int userId, [FromBody] UrlDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var result = _userService.UpdateAvatar(userId, dto);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Route]
        [HttpGet]
        [ActionName("GetUsers")]
        public IHttpActionResult GetUsers()
        {
            try
            {
                var token = Request.GetAuthorizationHeader();

                if (!AuthenticationValidation.IsAdmin(token))
                {
                    return Response(HttpStatusCode.Unauthorized, "Not allowed.");
                }
                return Ok(_userService.GetUsers());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("{userId}")]
        [HttpDelete]
        public IHttpActionResult DeleteUsers(int userId)
        {
            try
            {
                var token = Request.GetAuthorizationHeader();

                if (!AuthenticationValidation.IsAdmin(token))
                {
                    return Response(HttpStatusCode.Unauthorized, "Not allowed.");
                }
                if (_userService.DeleteUser(userId))
                    return Ok("delete successed");
                return BadRequest("delete failed");
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route]
        [HttpPost]
        public IHttpActionResult AddUser([FromBody] UserInfoDto userInfo)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var token = Request.GetAuthorizationHeader();

                if (!AuthenticationValidation.IsAdmin(token))
                {
                    return Response(HttpStatusCode.Unauthorized, "Not allowed.");
                }
                if (_userService.AddUser(userInfo))
                    return Ok("add successed");
                return BadRequest("add failed");
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
