using EducationManagement.Services.Abstractions;
using EducationManagement.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EducationManagement.Controllers
{
    public class ProfileController : ApiController
    {
        private readonly IProfileService ProfileService;

        public ProfileController(IProfileService ProfileService)
        {
            this.ProfileService = ProfileService;
        }

        [Route("Users/{id}")]
        [HttpGet]
        public IHttpActionResult GetProfile(int id)
        {
            if (!Request.Headers.Contains("Token"))
                return CreateUnauthorizedResponse("Missing token value in request headers");

            var token = Request.Headers.GetValues("Token");

            if (ProfileService.CheckExistToken(token.FirstOrDefault()))
                return CreateUnauthorizedResponse("Token does not exist in the database");

            int idUser = Convert.ToInt32(Convert.FromBase64String(token.FirstOrDefault()).ToString().Split('@')[0]);

            if (id != idUser)
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("The input id is not the same as the token string")
                });

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, ProfileService.GetUserInfoBbyId(id)));
        }

        private IHttpActionResult CreateUnauthorizedResponse(string message)
        {
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent(message)
            });
        }
    }
}
