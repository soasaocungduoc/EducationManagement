using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class NewsConditionSearch
    {
        [JsonProperty("key_search_for_title")]
        public string KeySearch { set; get; }
        [JsonProperty("current_page")]
        public int CurrentPage { set; get; }
        [JsonProperty("page_size")]
        public int PageSize { set; get; }

        public NewsConditionSearch()
        {
            this.KeySearch = "";
            this.PageSize = 10;
            this.CurrentPage = 1;
        }
    }
}