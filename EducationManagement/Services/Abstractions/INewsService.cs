using EducationManagement.Dtos.OutputDtos;
using System.Collections.Generic;
using EducationManagement.Dtos.InputDtos;

namespace EducationManagement.Services.Abstractions
{
    public interface INewsService
    {
        List<NewsResponseDto> GetNews(NewsConditionSearch conditionSearch);

        NewsResponseDto GetNews(int newId);

        bool Delete(int newsId);

        bool AddNews(NewsDto dto);

        bool UpdateNews(int newsId, NewsDto dto);
    }
}