using EducationManagement.Dtos.InputDtos;
using EducationManagement.Services.Abstractions;
using EducationManagement.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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

        [Route("{id}")]
        [HttpPost]
        public IHttpActionResult UpdateUserById(int id,[FromBody] UserDto user)
        {
            var token = Request.Headers.Contains("Token") ? Request.Headers.GetValues("Token") : null;

            if (token == null || token.FirstOrDefault() == "")
            {
                return Response(HttpStatusCode.Unauthorized, "Invalid token.");
            }
            if(string.IsNullOrEmpty(user.Address) || string.IsNullOrEmpty(user.PhoneNumber) || !IsPhoneNumber(user.PhoneNumber))
            {
                return Response(HttpStatusCode.Unauthorized, "Invalid input.");
            }
            
            return _userService.UpdateUser(user,id)
                ? ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent))
                : Response(HttpStatusCode.Unauthorized, "Cannot update user");
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

        private bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }
    }
}
