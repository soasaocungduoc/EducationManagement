using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class SlideDto
    {
        [JsonProperty("title")]
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [JsonProperty("image_url")]
        [Required]
        public string ImageUrl { get; set; }

        [JsonProperty("path")]
        [Required]
        public string Path { get; set; }

        [JsonProperty("is_shown")]
        public bool IsShown { get; set; } = true;
    }
}