using EducationManagement.Controllers.Bases;
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
    public class ParentController : BaseApiController
    {
        private readonly IParentService _parentService;
        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpGet]
        [ActionName("GetParents")]
        public IHttpActionResult GetParents()
        {
            try
            {
                return Ok(_parentService.GetParents());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetParentsByClassId")]
        public IHttpActionResult GetParentsByClassId(int classId)
        {
            try
            {
                var result = _parentService.GetParentsByClassId(classId);
                if (result == null)
                    return BadRequest("Cannot found this class");
                return Ok(_parentService.GetParentsByClassId(classId));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [ActionName("AddParent")]
        public IHttpActionResult AddParent([FromBody] ParentDto parentDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                if (_parentService.AddParent(parentDto))
                    return Ok("Add successed");
                return BadRequest("Add failed");
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
