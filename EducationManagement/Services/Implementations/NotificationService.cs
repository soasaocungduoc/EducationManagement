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
    }
}