using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System.Collections.Generic;
using System.Linq;

namespace EducationManagement.Services.Implementations
{
    public class NewsService : INewsService
    {
        private readonly DataContext db = new DataContext();
        public List<NewsResponseDto> GetNews()
        {
            if (db.News.ToList() == null)
                return new List<NewsResponseDto>();
            return db.News.Where(n => !n.DelFlag).ToList().Select(x => new NewsResponseDto(x)).ToList();
        }
    }
}