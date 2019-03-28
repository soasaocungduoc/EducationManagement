using System.Net;
using System.Net.Http;
using System.Web.Http;
using EducationManagement.Commons;
using EducationManagement.Controllers.Bases;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Services.Abstractions;

namespace EducationManagement.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody] LoginDto dto)
        {
            if(dto == null)
                return BadRequest();

            var result = authenticationService.Login(dto);

            if (result == null)
                return CreateUnauthorizedResponse("Invalid username or password");

            var output = Request.CreateResponse(HttpStatusCode.OK, result);
            
            output.Headers.Add("Authorization", JwtAuthenticationExtensions.CreateToken(result));

            return ResponseMessage(output);
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
