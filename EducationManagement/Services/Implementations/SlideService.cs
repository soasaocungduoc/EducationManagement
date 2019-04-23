using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;

namespace EducationManagement.Services.Implementations
{
    public class SlideService : ISlideService
    {
        private readonly DataContext db = new DataContext();

        public SlideResponseDto AddSlide(SlideDto slide)
        {
            DbContextTransaction transaction = db.Database.BeginTransaction();
            try
            {
                var newslide = db.Slides.Add(new EM.Database.Schema.Slide
                {
                    Title = slide.Title,
                    ImageUrl = slide.ImageUrl,
                    Path = slide.Path,
                    IsShown = slide.IsShown
                });
               
                db.SaveChanges();
                transaction.Commit();
                return new SlideResponseDto(newslide);
            }
            catch (Exception)
            {
                transaction.Rollback();
                return null;
            }

        }

        public bool DeleteSlide(int id)
        {
            DbContextTransaction transaction = db.Database.BeginTransaction();
            try
            {
                var slideFromDb = db.Slides.FirstOrDefault(n => !n.DelFlag && n.Id == id);
                if (slideFromDb == null) return false;
                slideFromDb.DelFlag = true;
                db.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }

        public SlideResponseDto GetSlideById(int id)
        {
            try
            {
                return new SlideResponseDto(db.Slides.FirstOrDefault(s => !s.DelFlag && s.Id == id));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<SlideResponseDto> GetSlides(SlideConditionSearch conditionSearch)
        {
            try
            {
                // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
                if (conditionSearch == null)
                {
                    conditionSearch = new SlideConditionSearch();
                }

                // Lấy các thông tin dùng để phân trang
                var paging = new Commons.Paging(db.Slides.Count(x => !x.DelFlag &&
                    (conditionSearch.KeySearch == null ||
                    (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                    , conditionSearch.CurrentPage, conditionSearch.PageSize);

                // Tìm kiếm và lấy dữ liệu theo trang
                var listOfSlide = db.Slides.Where(x => !x.DelFlag &&
                    (conditionSearch.KeySearch == null ||
                    (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                    .OrderBy(x => x.Id)
                    .Skip((paging.CurrentPage - 1) * paging.NumberOfRecord)
                    .Take(paging.NumberOfRecord).Select(x => new SlideResponseDto{
                        Id = x.Id,
                        Title = x.Title,
                        ImageUrl = x.ImageUrl,
                        Path = x.Path,
                        IsShown = x.IsShown
                    }).ToList();
                return listOfSlide == null ? null:listOfSlide;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SlideResponseDto UpdateSlide(int id, SlideDto slide)
        {
            
            DbContextTransaction transaction = db.Database.BeginTransaction();
            try
            {
                var slideFromDb = db.Slides.FirstOrDefault(n => !n.DelFlag && n.Id == id);
                if (slide == null) return null;
                slideFromDb.Title = slide.Title;
                slideFromDb.Path = slide.Path;
                slideFromDb.ImageUrl = slide.ImageUrl;
                slideFromDb.IsShown = slide.IsShown;
                db.SaveChanges();
                transaction.Commit();
                return new SlideResponseDto(slideFromDb);
            }
            catch (Exception)
            {
                transaction.Rollback();
                return null;
            }
        }
    }
}