using EducationManagement.Commons;
using EducationManagement.Dtos.InputDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class ListOfNewsResponseDto
    {
        [JsonProperty("list_of_news")]
        public List<NewsResponseDto> ListOfNews { set; get; }
        [JsonProperty("paging")]
        public Paging Paging { set; get; }
        [JsonProperty("news_condition_search")]
        public NewsConditionSearch Condition { set; get; }
        public ListOfNewsResponseDto()
        {
            this.ListOfNews = new List<NewsResponseDto>();
            this.Condition = new NewsConditionSearch();
            this.Paging = new Paging();
        }
    }
}