using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class NewsService : INewsService
    {
        private readonly DataContext db = new DataContext();
        public List<NewsDto> GetNews()
        {
            if (db.News.ToList() == null)
                return new List<NewsDto>();
            return db.News.Where(n => !n.DelFlag).ToList().Select(x => new NewsDto(x)).ToList();
        }
    }
}