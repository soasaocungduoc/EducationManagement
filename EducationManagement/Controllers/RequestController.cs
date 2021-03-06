﻿using EducationManagement.Commons;
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
    public class RequestController : BaseApiController
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
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

            var result = _requestService.Add(dto);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetRequest")]
        public IHttpActionResult GetRequest(int requestId)
        {
            var result = _requestService.Get(requestId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [AdminAuthorization]
        [HttpGet]
        [ActionName("GetAllRequest")]
        public IHttpActionResult GetAllRequest()
        {
            var result = _requestService.GetAll();

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetUserRequest")]
        public IHttpActionResult GetUserRequest(int userId)
        {
            try
            {
                if(Request.Headers.Authorization == null)
                {
                    return Unauthorized();
                }

                var token = Request.Headers.Authorization.ToString();

                if (!ValidatePermission(token, userId))
                {
                    return Unauthorized();
                }

                var result = _requestService.GetUserRequest(userId);

                if (result == null)
                {
                    return BadRequest();
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private static bool ValidatePermission(string token, int userId)
        {
            var tokenInformation = JwtAuthenticationExtensions.ExtractTokenInformation(token);
            if (tokenInformation == null) return false;
            return tokenInformation.GroupName == "Admin" ||
                   tokenInformation.GroupName == "Mod" ||
                   tokenInformation.UserId == userId;
        }
    }
}
