using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using EM.Database.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly DataContext db = new DataContext();
        public bool Add(NotificationDto dto)
        {
            if(dto == null)
            {
                return false;
            }

            try
            {
                var notification = new Notification();

                notification.ReceiverId = dto.ReceiverId;
                notification.SenderId = dto.SenderId;
                notification.ClassReceiverId = dto.ClassReceiverId;
                notification.Title = dto.Title;
                notification.Content = dto.Content;
                notification.Type = dto.Type;

                db.Notifications.Add(notification);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public List<NotificationResponseDto> Get(int receiverId)
        {
            var notifications = new List<NotificationResponseDto>();
            notifications = db.Notifications
                .Where(x => x.ReceiverId == receiverId && x.DelFlag == false)
                .Select(x => new NotificationResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Type = x.Type
                }).ToList();

            //case receiver is teacher
            var teacherFromDb = db.Teachers
                .FirstOrDefault(x => x.UserId == receiverId && x.DelFlag == false);
                
            if(teacherFromDb != null)
            {
                var teacherNotifications = db.Notifications
                .Where(x => x.ClassReceiverId == teacherFromDb.Id && x.DelFlag == false)
                .Select(x => new NotificationResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Type = x.Type
                }).ToList();

                if (teacherNotifications != null)
                {
                    notifications.AddRange(teacherNotifications);
                }
            }

            //case receiver is student
            var studentFromDb = db.Students
                .FirstOrDefault(x => x.UserId == receiverId && x.DelFlag == false);

            if(studentFromDb != null)
            {
                var studentNotifications = db.Notifications
                .Where(x => x.ClassReceiverId == studentFromDb.ClassId && x.DelFlag == false)
                .Select(x => new NotificationResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Type = x.Type
                }).ToList();

                if (studentNotifications != null)
                {
                    notifications.AddRange(studentNotifications);
                }
            }

            //case receiver is parent
            studentFromDb = db.Students
                .FirstOrDefault(x => x.ParentId == receiverId && x.DelFlag == false);

            if(studentFromDb != null)
            {
                var parentNotifications = db.Notifications
                .Where(x => x.ClassReceiverId == studentFromDb.ClassId && x.DelFlag == false)
                .Select(x => new NotificationResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Type = x.Type
                }).ToList();

                if (parentNotifications != null)
                {
                    notifications.AddRange(parentNotifications);
                }
            }
            
            if (notifications == null)
            {
                return null;
            }

            return notifications;  
        }
    }
}