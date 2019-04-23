using EducationManagement.Commons;
using EducationManagement.Controllers.Bases;
using EducationManagement.Dtos.InputDtos;
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
    [AdminAuthorization]
    [RoutePrefix("api/student")]
    public class StudentController : BaseApiController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        [ActionName("AddStudents")]
        public IHttpActionResult AddStudents([FromBody] StudentDto[] dtos)
        {
            if (dtos == null)
            {
                return BadRequest("invalid input dto");
            }
            
            var result = _studentService.AddStudents(dtos);

            if (result == null)
            {
                return Ok();
            }

            string responseMessage = "invalid student: ";

            foreach(int i in result)
            {
                responseMessage = responseMessage + i;
            }
            return Ok(responseMessage);
        }

        
    }
}
