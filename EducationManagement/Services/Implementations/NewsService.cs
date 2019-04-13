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
            return db.News.Where(n => !n.DelFlag).ToList().Select(x => new NewsResponseDto(x)).ToList();
        }

        public NewsResponseDto GetNews(int newsId)
        {
            return new NewsResponseDto(db.News.FirstOrDefault(n => !n.DelFlag && n.Id == newsId));
        }

        public bool Delete(int newsId)
        {
            var newsFromDb = db.News.FirstOrDefault(n => !n.DelFlag && n.Id == newsId);
            if (newsFromDb == null) return false;
            newsFromDb.DelFlag = true;
            db.SaveChanges();
            return true;
        }
    }
}