using EducationManagement.Fillters;
using EducationManagement.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EducationManagement.Controllers
{
    public class TypeMarkController : ApiController
    {
        private readonly ITypeMarkService _typeMarkService;

        public TypeMarkController(ITypeMarkService typeMarkService)
        {
            _typeMarkService = typeMarkService;
        }

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetTypeMarks")]
        public IHttpActionResult GetTypeMarks()
        {
            try
            {
                return Ok(_typeMarkService.GetTypeMarks());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
