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
    public class ParentController : BaseApiController
    {
        private readonly IParentService _parentService;
        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpGet]
        [ActionName("GetParents")]
        public IHttpActionResult GetParents()
        {
            try
            {
                return Ok(_parentService.GetParents());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
