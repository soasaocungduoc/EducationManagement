using System.Net;
using System.Net.Http;
using System.Web.Http;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Services.Abstractions;

namespace EducationManagement.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IAuthenticationService loginService;

        public LoginController(IAuthenticationService loginService)
        {
            this.loginService = loginService;
        }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody] LoginDto dto)
        {
            if(dto == null)
            {
                return BadRequest();
            }

            var result = loginService.Login(dto);
            
            if (result == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("Invalid username or password")
                };
                
                return ResponseMessage(response);
            }

            var output = Request.CreateResponse(HttpStatusCode.OK, result);
            
            output.Headers.Add("Token", loginService.GetToken());

            return ResponseMessage(output);
        }
    }
}
