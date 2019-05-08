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
    public class NotificationController : BaseApiController
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [AdminAuthorization]
        [HttpPost]
        [ActionName("AddNotification")]
        public IHttpActionResult AddNotification([FromBody] NotificationDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var result = _notificationService.Add(dto);

            if (result == true)
            {
                return Ok();
            }

            return BadRequest();
        }

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetNotification")]
        public IHttpActionResult GetNotification(int receiverId)
        {
            var result = _notificationService.Get(receiverId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
