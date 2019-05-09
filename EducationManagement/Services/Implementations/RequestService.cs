using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using EM.Database.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EducationManagement.Services.Implementations
{
    public class RequestService : IRequestService
    {
        private readonly DataContext db = new DataContext();
        
        public RequestResponseDto Add(RequestDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            var request = new Notification();

            try
            {
                request.SenderId = dto.SenderId;
                request.Title = dto.Title;
                request.Content = dto.Content;
                request.Type = "request";

                db.Notifications.Add(request);
                db.SaveChanges();
            }
            catch
            {
                return null;
            }

            return Get(request.Id);
        }

        public RequestResponseDto Get(int requestId)
        {
            var requestFromDb = db.Notifications
                .Include(x => x.Sender)
                .FirstOrDefault(x => x.Type == "request" && x.Id == requestId && x.DelFlag == false);

            if(requestFromDb == null)
            {
                return null;
            }

            return new RequestResponseDto()
            {
                 Id = requestFromDb.Id,
                 Title = requestFromDb.Title,
                 Content = requestFromDb.Content,
                 Sender = new UserResponseDto(requestFromDb.Sender)
            };
        }

        
        public List<RequestResponseDto> GetAll()
        {
            var requests = new List<RequestResponseDto>();

            requests = db.Notifications
                .Include(x => x.Sender)
                .Where(x => x.Type == "request" && x.DelFlag == false)
                .Select(x => new RequestResponseDto {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Sender = x.Sender == null? null : new UserResponseDto()
                    {
                        Id = x.Sender.Id,
                        FirstName = x.Sender.FirstName,
                        LastName = x.Sender.LastName,
                        Address = x.Sender.Address,
                        Avatar = x.Sender.Avatar,
                        Birthday = x.Sender.Birthday,
                        Gender = x.Sender.Gender,
                        IdentificationNumber = x.Sender.IdentificationNumber,
                        PhoneNumber = x.Sender.PhoneNumber
                    }
                }).ToList();

            return requests;
        }

        public List<RequestResponseDto> GetUserRequest(int userId)
        {
            var requests = new List<RequestResponseDto>();

            requests = db.Notifications
                .Include(x => x.Sender)
                .Where(x => x.Type == "request" && x.SenderId == userId && x.DelFlag == false)
                .Select(x => new RequestResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Sender = x.Sender == null ? null : new UserResponseDto()
                    {
                        Id = x.Sender.Id,
                        FirstName = x.Sender.FirstName,
                        LastName = x.Sender.LastName,
                        Address = x.Sender.Address,
                        Avatar = x.Sender.Avatar,
                        Birthday = x.Sender.Birthday,
                        Gender = x.Sender.Gender,
                        IdentificationNumber = x.Sender.IdentificationNumber,
                        PhoneNumber = x.Sender.PhoneNumber
                    }
                }).ToList();

            return requests;
        }
    }
}