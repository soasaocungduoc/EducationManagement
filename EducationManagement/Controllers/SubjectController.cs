﻿using EducationManagement.Controllers.Bases;
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
    }
}
