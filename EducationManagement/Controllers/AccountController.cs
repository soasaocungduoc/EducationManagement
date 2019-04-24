using EducationManagement.Commons;
using EducationManagement.Controllers.Bases;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EducationManagement.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPut]
        [ActionName("ChangePassword")]
        public IHttpActionResult ChangePassword(int id, [FromBody] PasswordDto password)
        {
            try
            {
                var token = Request.Headers.GetValues("Authorization").First();

                if (!FunctionCommon.ValidatePermission(token, id))
                {
                    return ResponseMessage(new HttpResponseMessage(HttpStatusCode.Unauthorized)
                    {
                        Content = new StringContent("Not allowed.")
                    });
                }
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var i = _accountService.ChangePassword(password, id);
                if (i == -1)
                    return BadRequest("Cannot found this account");
                else if (i == 0)
                    return BadRequest("Old password isn't correct");
                return Ok("Update password success");


            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
