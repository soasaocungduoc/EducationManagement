using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class SubjectMarkDto
    {
        [Required]
        [JsonProperty("subjectId")]
        public int SubjectId { get; set; }

        [Required]
        [JsonProperty("semesterId")]
        public int SemesterId { get; set; }

        [Required]
        [JsonProperty("marks")]
        public List<MarkDto> Marks { get; set; }

        public SubjectMarkDto()
        {
        }

        public SubjectMarkDto(int subjectId, int semesterId, List<MarkDto> marks)
        {
            SubjectId = subjectId;
            SemesterId = semesterId;
            Marks = marks;
        }
    }
}