using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class MarkResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("mark")]
        public double Mark { get; set; }

        [JsonProperty("type_mark")]
        public double TypeMark { get; set; }

        public MarkResponseDto()
        {

        }

        public MarkResponseDto(int id, double mark, double typeMark)
        {
            Id = id;
            Mark = mark;
            TypeMark = typeMark;
        }
    }
}