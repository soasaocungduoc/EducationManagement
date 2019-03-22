using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EducationManagement.Models;
using EducationManagement.Service;
using System.Security.Cryptography;
using EM.Database;
using EM.Database.Schema;


namespace EducationManagement.Controllers
{
    public class LoginController : ApiController
    {
        [Route("login/check")]
        [HttpPost]
        public IHttpActionResult Login([FromBody] Login login)
        {
            var result = new LoginService().CheckLogin(login);
            
            return Ok(result);
        }
    }
}
