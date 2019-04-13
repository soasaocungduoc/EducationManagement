using EducationManagement.Dtos.OutputDtos;
using System.Collections.Generic;

namespace EducationManagement.Services.Abstractions
{
    public interface INewsService
    {
        List<NewsResponseDto> GetNews();

        NewsResponseDto GetNews(int newId);

        bool Delete(int newsId);
    }
}
