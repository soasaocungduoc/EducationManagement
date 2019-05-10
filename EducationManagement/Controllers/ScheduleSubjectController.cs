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
    public class ScheduleSubjectController : BaseApiController
    {
        private readonly IScheduleSubjectService _scheduleSubjectService;
        public ScheduleSubjectController(IScheduleSubjectService scheduleSubjectService)
        {
            _scheduleSubjectService = scheduleSubjectService;
        }

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetScheduleSubjectsByClassId")]
        public IHttpActionResult GetScheduleSubjectsByClassId(int id, int semesterId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = _scheduleSubjectService.GetScheduleSubjectsByClassId(id, new SemesterIdDto { id = semesterId });
                if (result == null)
                    return BadRequest("Cannot found this class");
                return Ok(result);
                   
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetScheduleSubjectsByStudentId")]
        public IHttpActionResult GetScheduleSubjectsByStudentId(int id, int semesterId)
        {
            try
            {
                var result = _scheduleSubjectService.GetScheduleSubjectsByStudentId(id, new SemesterIdDto {id = semesterId});
                if (result == null)
                    return BadRequest("Cannot found this student");
                return Ok(result);

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetTeachingSchedulesByTeacherId")]
        public IHttpActionResult GetTeachingSchedulesByTeacherId(int id, int semesterId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = _scheduleSubjectService.GetTeachingScheduleByTeacherId(id, new SemesterIdDto { id = semesterId });
                if (result == null)
                    return BadRequest("Cannot found this teacher");
                return Ok(result);

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [AdminAuthorization]
        [HttpPost]
        [ActionName("AddScheduleSubjectOfClass")]
        public IHttpActionResult AddScheduleSubjectOfClass(int classId, int semesterId,[FromBody] List<ScheduleSubjectDto> schedules)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var isSuccess = _scheduleSubjectService.AddScheduleSubjectsByClassId(new ScheduleSubjectOfClassDto { ClassId = classId, SemesterId = semesterId, ScheduleSubjects = schedules});
                if (!isSuccess)
                    return BadRequest("Add schedules faild");
                return Ok(_scheduleSubjectService.GetScheduleSubjectsByClassId(classId, new SemesterIdDto { id = semesterId }));

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
