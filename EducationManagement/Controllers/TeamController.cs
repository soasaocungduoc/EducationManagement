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
    public class TeamController : BaseApiController
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [Authorize]
        [HttpGet]
        [ActionName("GetTeams")]
        public IHttpActionResult GetTeams()
        {
            try
            {
                return Ok(_teamService.GetTeams());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
