using EducationManagement.Controllers.Bases;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Fillters;
using EducationManagement.Services.Abstractions;
using System;
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

        [AdminAuthorization]
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

        
        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetStudentsByParentId")]
        public IHttpActionResult GetStudentsByParentId(int id)
        {
            try
            {
                var result = _studentService.GetStudentsByParentId(id);
                if (result != null)
                    return Ok(result);
                return BadRequest("Cannot found this parent");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        //[AdminAuthorization]
        [HttpGet]
        [ActionName("GetStudentsByClassId")]
        public IHttpActionResult GetStudentsByClassId(int id)
        {
            try
            {
                var result = _studentService.GetStudentsByClassId(id);
                if(result != null)
                    return Ok(result);
                return BadRequest("Cannot found this class");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetStudent")]
        public IHttpActionResult GetStudent(int studentId)
        {
            var result = _studentService.Get(studentId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
