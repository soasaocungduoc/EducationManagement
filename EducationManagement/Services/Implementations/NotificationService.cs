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

        public NotificationDetailDto GetById(int id)
        {
            var notificationFromDb = db.Notifications
                .FirstOrDefault(x => x.Id == id && x.DelFlag == false);

            if (notificationFromDb == null)
            {
                return null;
            }

            UserResponseDto receiver = null;
            UserResponseDto sender = null;
            ClassResponseDto classReceiver = null;

            if (notificationFromDb.ReceiverId != null)
            {
                receiver = new UserResponseDto(db.Users
                .FirstOrDefault(x => x.Id == notificationFromDb.ReceiverId && x.DelFlag == false));
            }

            if (notificationFromDb.SenderId != null)
            {
                sender = new UserResponseDto(db.Users
                .FirstOrDefault(x => x.Id == notificationFromDb.SenderId && x.DelFlag == false));
            }

            if (notificationFromDb.ClassReceiverId != null)
            {
                var classFromDb = db.Classes
                    .FirstOrDefault(x => x.Id == notificationFromDb.ClassReceiverId && x.DelFlag == false);

                if(classFromDb != null)
                {
                    var gradeFromDb = db.Grades.FirstOrDefault(x => x.Id == classFromDb.GradeId && x.DelFlag == false);
                    var roomfromDb = db.Rooms.FirstOrDefault(x => x.Id == classFromDb.RoomId && x.DelFlag == false);
                    var teacherFromDb = db.Teachers.FirstOrDefault(x => x.Id == classFromDb.TeacherId && x.DelFlag == false);

                    string teacherName = null;

                    if(teacherFromDb != null)
                    {
                        var teacherUserFromDb = db.Users.FirstOrDefault(x => x.Id == teacherFromDb.UserId && x.DelFlag == false);
                        teacherName = teacherUserFromDb == null ? null : teacherUserFromDb.FirstName + " " + teacherUserFromDb.LastName;
                    }

                    classReceiver = new ClassResponseDto()
                    {
                        Id = classFromDb.Id,
                        Name = classFromDb.Name,
                        NumberOfStudents = classFromDb.NumberOfStudents,
                        GradeName = gradeFromDb == null ? null : gradeFromDb.Name,
                        RoomNumber = roomfromDb == null ? null : roomfromDb.RoomNumber,
                        TeacherName = teacherName 
                    };
                }
                
            }

            return new NotificationDetailDto()
            {
                Id = notificationFromDb.Id,
                Title = notificationFromDb.Title,
                Content = notificationFromDb.Content,
                Type = notificationFromDb.Type,
                Receiver = receiver,
                Sender = sender,
                ClassReceiver = classReceiver
            };
        }
    }
}