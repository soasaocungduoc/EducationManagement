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
    public class ScheduleSubjectController : BaseApiController
    {
        private readonly IScheduleSubjectService _scheduleSubjectService;
        public ScheduleSubjectController(IScheduleSubjectService scheduleSubjectService)
        {
            _scheduleSubjectService = scheduleSubjectService;
        }

        [HttpGet]
        [ActionName("GetScheduleSubjectsByClassId")]
        public IHttpActionResult GetScheduleSubjectsByClassId(int id)
        {
            try
            {
                if (_scheduleSubjectService.GetScheduleSubjectsByClassId(id) == null)
                    return BadRequest("Cannot found");
                return Ok(_scheduleSubjectService.GetScheduleSubjectsByClassId(id));
                   
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetScheduleSubjectsByStudentId")]
        public IHttpActionResult GetScheduleSubjectsByStudentId(int id)
        {
            try
            {
                if (_scheduleSubjectService.GetScheduleSubjectsByStudentId(id) == null)
                    return BadRequest("Cannot found");
                return Ok(_scheduleSubjectService.GetScheduleSubjectsByStudentId(id));
                
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetTeachingSchedulesByTeacherId")]
        public IHttpActionResult GetTeachingSchedulesByTeacherId(int id)
        {
            try
            {
                if (_scheduleSubjectService.GetTeachingScheduleByTeacherId(id) == null)
                    return BadRequest("Cannot found");
                return Ok(_scheduleSubjectService.GetTeachingScheduleByTeacherId(id));

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
