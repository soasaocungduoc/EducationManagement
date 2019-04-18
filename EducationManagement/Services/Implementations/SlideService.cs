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
                    IsShown = slide.IsShown == null ? true : slide.IsShown
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

        public ListOfSlideResponseDto GetSlides(SlideConditionSearch conditionSearch)
        {
            try
            {
                // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
                if (conditionSearch == null)
                {
                    conditionSearch = new SlideConditionSearch();
                }

                ListOfSlideResponseDto listOfSlide = new ListOfSlideResponseDto();
                // Lấy các thông tin dùng để phân trang
                listOfSlide.Paging = new Commons.Paging(db.Slides.Count(x => !x.DelFlag &&
                    (conditionSearch.KeySearch == null ||
                    (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                    , conditionSearch.CurrentPage, conditionSearch.PageSize);

                // Tìm kiếm và lấy dữ liệu theo trang
                listOfSlide.ListOfSlide = db.Slides.Where(x => !x.DelFlag &&
                    (conditionSearch.KeySearch == null ||
                    (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                    .OrderBy(x => x.Id)
                    .Skip((listOfSlide.Paging.CurrentPage - 1) * listOfSlide.Paging.NumberOfRecord)
                    .Take(listOfSlide.Paging.NumberOfRecord).Select(x => new SlideResponseDto(x)).ToList();
                listOfSlide.Condition = conditionSearch;
                return listOfSlide;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}