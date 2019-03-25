using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            
            output.Headers.Add("Token", authenticationService.GetToken());

            return ResponseMessage(output);
        }

        [Route("logout")]
        [HttpDelete]
        public IHttpActionResult Logout()
        {
            if (!Request.Headers.Contains("Token"))
                return CreateUnauthorizedResponse("Missing token value in request headers");

            var token = Request.Headers.GetValues("Token");

            return authenticationService.Logout(token.FirstOrDefault())
                ? ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent))
                : CreateUnauthorizedResponse("Invalid token");

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
