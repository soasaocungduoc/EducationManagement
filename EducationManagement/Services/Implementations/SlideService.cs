using System.Collections.Generic;
using System.Linq;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;

namespace EducationManagement.Services.Implementations
{
    public class SlideService : ISlideService
    {
        private readonly DataContext db = new DataContext();
        
        public List<SlideResponseDto> GetSlides()
        {
            if (db.Slides.ToList() == null) return new List<SlideResponseDto>();
            return db.Slides.Where(x => !x.DelFlag).ToList().Select(s => new SlideResponseDto(s)).ToList();
        }
    }
}