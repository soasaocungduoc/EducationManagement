using EM.Database.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class SchoolYearResponseDto
    {
        public SchoolYearResponseDto(int id, int startYear, int endYear, bool isCurrent)
        {
            Id = id;
            StartYear = startYear;
            EndYear = endYear;
            IsCurrent = isCurrent;
        }

        public SchoolYearResponseDto()
        {

        }

        public SchoolYearResponseDto(SchoolYear year)
        {
            Id = year.Id;
            StartYear = year.StartYear;
            EndYear = year.EndYear;
            IsCurrent = (year.StartYear <= Convert.ToInt32(DateTime.Now.Year.ToString()) && (year.EndYear >= Convert.ToInt32(DateTime.Now.Year.ToString())));
        }

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("start_year")]
        public int StartYear { get; set; }
        [JsonProperty("end_year")]
        public int EndYear { get; set; }
        [JsonProperty("is_current")]
        public bool IsCurrent { get; set; }
    }
}