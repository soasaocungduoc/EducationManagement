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
    public class SubjectController : BaseApiController
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        
        [HttpGet]
        [ActionName("GetSubjects")]
        public IHttpActionResult GetSubjects()
        {
            try
            {
                return Ok(_subjectService.GetSubjects());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetSubjectBySubjectId")]
        public IHttpActionResult GetSubjectBySubjectId(int subjectId)
        {
            try
            {
                var result = _subjectService.GetSubjectBySubjectId(subjectId);
                if (result == null)
                    return BadRequest("Cannot found this subject");
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [ActionName("AddSubject")]
        public IHttpActionResult AddSubject([FromBody] SubjectDto subjectDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = _subjectService.AddSubject(subjectDto);
                if(result == null)
                    return BadRequest("Add faild");
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [ActionName("UpdateSubject")]
        public IHttpActionResult UpdateSubject(int subjectId,[FromBody] SubjectDto subjectDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = _subjectService.UpdateSubject(subjectDto, subjectId);
                if (result == null)
                    return BadRequest("Update faild");
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpDelete]
        [ActionName("DeleteSubject")]
        public IHttpActionResult DeleteSubject(int subjectId)
        {
            try
            {
                if (_subjectService.DeleteSubject(subjectId))
                    return Ok("Delete successed");
                return BadRequest("Delete faild");
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
