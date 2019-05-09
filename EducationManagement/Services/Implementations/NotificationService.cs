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
                notification.ClassReceiverId = dto.ClassReceiverId;
                notification.Title = dto.Title;
                notification.Content = dto.Content;
                notification.Type = "notification";

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

        public NotificationDetailDto GetById(int id)
        {
            var notificationFromDb = db.Notifications
                .Include(x => x.Receiver)
                .Include(x => x.Class)
                .FirstOrDefault(x => x.Type == "notification" && x.Id == id && x.DelFlag == false);

            if (notificationFromDb == null)
            {
                return null;
            }

            var classFromDb = db.Classes
                .Include(x => x.Room)
                .Include(x => x.Grade)
                .Include(x => x.Teacher)
                .FirstOrDefault(x => x.Id == notificationFromDb.ClassReceiverId && x.DelFlag == false);

            string teacherName = null;

            if(classFromDb != null)
            {
                var teacherFromDb = db.Teachers.Include(x => x.User)
                    .FirstOrDefault(x => x.Id == classFromDb.TeacherId && x.DelFlag == false);

                if(teacherFromDb != null)
                {
                    teacherName = teacherFromDb.User.FirstName + " " + teacherFromDb.User.LastName;
                }
            }

            return new NotificationDetailDto()
            {
                Id = notificationFromDb.Id,
                Title = notificationFromDb.Title,
                Content = notificationFromDb.Content,
                Type = notificationFromDb.Type,
                Receiver = new UserResponseDto(notificationFromDb.Receiver),
                ClassReceiver = classFromDb == null ? null : new ClassResponseDto()
                {
                    Id = classFromDb.Id,
                    Name = classFromDb.Name,
                    NumberOfStudents = classFromDb.NumberOfStudents,
                    GradeName = classFromDb.Grade.Name,
                    RoomNumber = classFromDb.Room.RoomNumber,
                    TeacherName =  teacherName
                }
            };
        }
    }
}