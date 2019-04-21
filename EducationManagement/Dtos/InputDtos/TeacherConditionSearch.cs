using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class TeacherConditionSearch
    {
        [JsonProperty("key_search_for_name")]
        public string KeySearch { set; get; }
        [JsonProperty("current_page")]
        public int CurrentPage { set; get; }
        [JsonProperty("page_size")]
        public int PageSize { set; get; }

        public TeacherConditionSearch()
        {
            this.KeySearch = "";
            this.PageSize = 200;
            this.CurrentPage = 1;
        }
    }
}