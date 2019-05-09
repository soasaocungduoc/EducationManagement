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
    public interface IRequestService
    {
        bool Add(RequestDto dto);

        RequestResponseDto Get(int requestId);

        List<RequestResponseDto> GetAll();
    }
}
