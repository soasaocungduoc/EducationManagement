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
    public class ClassController : BaseApiController
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        [ActionName("GetClasses")]
        public IHttpActionResult GetClasses()
        {
            try
            {
                return Ok(_classService.GetClasses());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetClassesByGradeId")]
        public IHttpActionResult GetClasses(int id)
        {
            try
            {
                var result = _classService.GetClassesByGradeId(id);
                if (result == null)
                    return BadRequest("Cannot found this grade");
                return Ok(result);

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
