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
    public class UserController : ApiController
    {
        private readonly IUserService profileService;

        public UserController(IUserService profileService)
        {
            this.profileService = profileService;
        }

        [Route("users/{id}")]
        [HttpGet]
        public IHttpActionResult GetProfile(int id)
        {
            if (!Request.Headers.Contains("Token"))
                return CreateUnauthorizedResponse("Missing token value in request headers");

            var token = Request.Headers.GetValues("Token");

            int idUser = GetUserIdFromToken(token.FirstOrDefault());

            if (id != idUser || idUser == 0)
                return CreateUnauthorizedResponse("Invalid token or user id");

            return Ok(profileService.GetUserInfoBbyId(id));
        }

        private IHttpActionResult CreateUnauthorizedResponse(string message)
        {
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent(message)
            });
        }

        private int GetUserIdFromToken(string token)
        {
            try
            {
                return Convert.ToInt32(Encoding.ASCII.GetString(Convert.FromBase64String(token)).Split('@')[0]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
