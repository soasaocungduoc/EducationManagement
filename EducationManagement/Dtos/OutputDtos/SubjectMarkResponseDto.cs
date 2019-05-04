using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class SubjectMarkResponseDto
    {

        [JsonProperty("subject_name")]
        public string SubjectName { get; set; }

        [JsonProperty("all_mark")]
        public List<MarkResponseDto> ListMark { get; set; }

        public SubjectMarkResponseDto()
        {

        }

        public SubjectMarkResponseDto(string subjectName, List<MarkResponseDto> listMark)
        {
            SubjectName = subjectName;
            ListMark = listMark;
        }
    }
}