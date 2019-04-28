using EM.Database.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class GradeResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public GradeResponseDto()
        {

        }

        public GradeResponseDto(Grade grade)
        {
            Id = grade.Id;
            Name = grade.Name;
        }

        public GradeResponseDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}