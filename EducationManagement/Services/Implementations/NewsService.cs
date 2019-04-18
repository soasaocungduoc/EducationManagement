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
        public ListOfNewsResponseDto GetNews(NewsConditionSearch conditionSearch)
        {
            try
            {
                // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
                if (conditionSearch == null)
                {
                    conditionSearch = new NewsConditionSearch();
                }

                ListOfNewsResponseDto listOfNews = new ListOfNewsResponseDto();
                // Lấy các thông tin dùng để phân trang
                listOfNews.Paging = new Commons.Paging(db.News.Count(x => !x.DelFlag &&
                    (conditionSearch.KeySearch == null ||
                    (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                    , conditionSearch.CurrentPage, conditionSearch.PageSize);

                // Tìm kiếm và lấy dữ liệu theo trang
                listOfNews.ListOfNews = db.News.Where(x => !x.DelFlag &&
                    (conditionSearch.KeySearch == null ||
                    (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                    .OrderBy(x => x.Id)
                    .Skip((listOfNews.Paging.CurrentPage - 1) * listOfNews.Paging.NumberOfRecord)
                    .Take(listOfNews.Paging.NumberOfRecord).Select(x => new NewsResponseDto
                    {
                        Id = x.Id,
                        Title = x.Title,
                        ImageUrl = x.ImageUrl,
                        Summary = x.Summary,
                        Content = x.Content,
                        CreatedAt = x.CreatedAt
                    }).ToList();
                listOfNews.Condition = conditionSearch;
                return listOfNews;
            }
            catch (Exception e)
            {
                throw e;
            }
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

        public bool AddNews(NewsDto news)
        {
            try
            {
                db.News.Add(new News
                {
                    Title = news.Title,
                    Summary = news.Summary,
                    Content = news.Content,
                    ImageUrl = news.ImageUrl
                });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateNews(int newsId, NewsDto news)
        {
            var newsFromDb = db.News.FirstOrDefault(n => n.Id == newsId);
            if (newsFromDb == null) return false;
            newsFromDb.Title = news.Title;
            newsFromDb.Summary = news.Summary;
            newsFromDb.ImageUrl = news.ImageUrl;
            newsFromDb.Content = news.Content;
            db.SaveChanges();
            return true;
        }
    }
}