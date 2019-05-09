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
        [HttpPost]
        [ActionName("AddRequest")]
        public IHttpActionResult AddRequest([FromBody] RequestDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var result = _notificationService.AddRequest(dto);

            if (result == true)
            {
                return Ok();
            }

            return BadRequest();
        }

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetRequest")]
        public IHttpActionResult GetRequest(int requestId)
        {
            var result = _notificationService.GetRequest(requestId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
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

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetNotificationById")]
        public IHttpActionResult GetNotificationById(int id)
        {
            var result = _notificationService.GetById(id);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
