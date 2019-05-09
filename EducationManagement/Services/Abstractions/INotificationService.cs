using EducationManagement.Dtos;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Abstractions
{
    public interface INotificationService
    {
        bool Add(NotificationDto dto);

        List<NotificationResponseDto> Get(int receiverId);

        NotificationDetailDto GetById(int id);
    }
}
