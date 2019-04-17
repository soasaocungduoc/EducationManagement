using EducationManagement.Dtos.OutputDtos;
using System.Collections.Generic;

namespace EducationManagement.Services.Abstractions
{
    public interface ISlideService
    {
        ListOfSlideResponseDto GetSlides(SlideConditionSearch conditionSearch);
        SlideResponseDto GetSlideById(int id);
    }
}
