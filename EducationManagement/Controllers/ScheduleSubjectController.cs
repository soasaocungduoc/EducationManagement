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
    public class ScheduleSubjectController : BaseApiController
    {
        private readonly IScheduleSubjectService _scheduleSubjectService;
        public ScheduleSubjectController(IScheduleSubjectService scheduleSubjectService)
        {
            _scheduleSubjectService = scheduleSubjectService;
        }

        [HttpGet]
        [ActionName("GetScheduleSubjectsByClassId")]
        public IHttpActionResult GetScheduleSubjectsByClassId(int id, [FromBody] SemesterIdDto semesterId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = _scheduleSubjectService.GetScheduleSubjectsByClassId(id, semesterId);
                if (result == null)
                    return BadRequest("Cannot found this class");
                return Ok(result);
                   
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetScheduleSubjectsByStudentId")]
        public IHttpActionResult GetScheduleSubjectsByStudentId(int id, [FromBody] SemesterIdDto semesterId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = _scheduleSubjectService.GetScheduleSubjectsByStudentId(id, semesterId);
                if (result == null)
                    return BadRequest("Cannot found this student");
                return Ok(result);

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetTeachingSchedulesByTeacherId")]
        public IHttpActionResult GetTeachingSchedulesByTeacherId(int id, [FromBody] SemesterIdDto semesterId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = _scheduleSubjectService.GetTeachingScheduleByTeacherId(id, semesterId);
                if (result == null)
                    return BadRequest("Cannot found this teacher");
                return Ok(result);

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
