using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using System.Collections.Generic;

namespace EducationManagement.Services.Abstractions
{
    public interface ISlideService
    {
        ListOfSlideResponseDto GetSlides(SlideConditionSearch conditionSearch);
        SlideResponseDto GetSlideById(int id);
        SlideResponseDto AddSlide(SlideDto slide);
        SlideResponseDto UpdateSlide(int id, SlideDto slide);
        bool DeleteSlide(int id);

    }
}
