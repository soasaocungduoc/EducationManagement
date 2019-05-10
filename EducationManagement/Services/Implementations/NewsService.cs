using System;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System.Collections.Generic;
using System.Linq;
using EducationManagement.Dtos.InputDtos;
using EM.Database.Schema;

namespace EducationManagement.Services.Implementations
{
    public class NewsService : INewsService
    {
        private readonly DataContext db = new DataContext();
        
        public NewsResponseDto GetNews(int newsId)
        {
            var newsFromDb = db.News.FirstOrDefault(x => x.DelFlag == false && x.Id == newsId);

            if(newsFromDb == null)
            {
                return null;
            }

            return new NewsResponseDto(newsFromDb);
        }

        public bool Delete(int newsId)
        {
            var newsFromDb = db.News.FirstOrDefault(x => x.DelFlag == false && x.Id == newsId);

            if (newsFromDb == null)
            {
                return false;
            }

            newsFromDb.DelFlag = true;

            db.SaveChanges();

            return true;
        }

        public bool AddNews(NewsDto dto)
        {
            try
            {
                var news = new News
                {
                    Title = dto.Title,
                    Summary = dto.Summary,
                    Content = dto.Content,
                    ImageUrl = dto.ImageUrl
                };

                db.News.Add(news);

                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateNews(int newsId, NewsDto dto)
        {
            var newsFromDb = db.News.FirstOrDefault(x => x.Id == newsId && x.DelFlag == false);

            if (newsFromDb == null)
            {
                return false;
            }

            newsFromDb.Title = dto.Title;
            newsFromDb.Summary = dto.Summary;
            newsFromDb.ImageUrl = dto.ImageUrl;
            newsFromDb.Content = dto.Content;

            db.SaveChanges();

            return true;
        }

        public List<NewsResponseDto> GetNews(NewsConditionSearch conditionSearch)
        {
            try
            {
                if (conditionSearch == null)
                {
                    conditionSearch = new NewsConditionSearch();
                }

                var paging = new Commons.Paging(db.News.Count(x => !x.DelFlag &&
                    (conditionSearch.KeySearch == null ||
                    (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                    , conditionSearch.CurrentPage, conditionSearch.PageSize);

                var listOfNews = db.News.Where(x => !x.DelFlag &&
                    (conditionSearch.KeySearch == null ||
                    (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                    .OrderBy(x => x.Id)
                    .Skip((paging.CurrentPage - 1) * paging.NumberOfRecord)
                    .Take(paging.NumberOfRecord).Select(x => new NewsResponseDto
                    {
                        Id = x.Id,
                        Title = x.Title,
                        ImageUrl = x.ImageUrl,
                        Summary = x.Summary,
                        Content = x.Content,
                        CreatedAt = x.CreatedAt
                    }).ToList();
                return listOfNews == null ? null : listOfNews;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}