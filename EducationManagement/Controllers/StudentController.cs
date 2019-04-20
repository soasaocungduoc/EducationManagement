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
    public class StudentController : BaseApiController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [ActionName("GetStudentsByParentId")]
        public IHttpActionResult GetStudentsByParentId(int id)
        {
            try
            {
                return Ok(_studentService.GetStudentsByParentId(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
