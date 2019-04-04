using EducationManagement.Dtos.OutputDtos;
using System.Collections.Generic;

namespace EducationManagement.Services.Abstractions
{
    public interface ISlideService
    {
        List<SlideResponseDto> GetSlides();
    }
}
