using EducationManagement.Controllers.Bases;
using EducationManagement.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EducationManagement.Controllers
{
    public class ConductController : BaseApiController
    {
        private readonly IConductService _conductService;

        public ConductController(IConductService conductService)
        {
            _conductService = conductService;
        }

        [Authorize]
        [HttpGet]
        [ActionName("GetConducts")]
        public IHttpActionResult GetConducts()
        {
            try
            {
                return Ok(_conductService.GetConducts());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
