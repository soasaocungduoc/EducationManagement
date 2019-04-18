using EducationManagement.Dtos.OutputDtos;
using System.Collections.Generic;
using EducationManagement.Dtos.InputDtos;

namespace EducationManagement.Services.Abstractions
{
    public interface INewsService
    {
        ListOfNewsResponseDto GetNews(NewsConditionSearch conditionSearch);

        NewsResponseDto GetNews(int newId);

        bool Delete(int newsId);

        bool AddNews(NewsDto news);

        bool UpdateNews(int newsId, NewsDto news);
    }
}
