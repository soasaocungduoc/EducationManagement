using EM.Database.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class SemesterResponseDto
    {
        

        public SemesterResponseDto()
        {

        }

        public SemesterResponseDto(Semester semester)
        {
            Id = semester.Id;
            Name = semester.Name;
            StartTime = semester.StartTime;
            EndTime = semester.EndTime;
            IsCurrent = (semester.StartTime <= DateTime.Now) && (DateTime.Now <= semester.EndTime);
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("is_current")]
        public bool IsCurrent { get; set; }
    }
}