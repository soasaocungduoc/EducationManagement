using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class MarkDto
    {
        [Required]
        [JsonProperty("studentId")]
        public int StudentId { get; set; }

        [Required]
        [JsonProperty("typeMarkId")]
        public int TypeMarkId { get; set; }

        [Required]
        [JsonProperty("mark")]
        public int Mark { get; set; }

        public MarkDto()
        {

        }
    }
}