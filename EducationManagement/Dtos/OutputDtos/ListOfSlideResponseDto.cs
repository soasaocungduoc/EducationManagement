using EducationManagement.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class ListOfSlideResponseDto
    {
        [JsonProperty("list_of_slide")]
        public List<SlideResponseDto> ListOfSlide { set; get; }
        [JsonProperty("paging")]
        public Paging Paging { set; get; }
        [JsonProperty("slide_condition_search")]
        public SlideConditionSearch Condition { set; get; }
        public ListOfSlideResponseDto()
        {
            this.ListOfSlide = new List<SlideResponseDto>();
            this.Condition = new SlideConditionSearch();
            this.Paging = new Paging();
        }
    }
}