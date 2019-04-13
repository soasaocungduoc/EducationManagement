using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EducationManagement.Dtos.InputDtos
{
    public class NewsDto
    {
        [Required]
        [StringLength(200)]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(200)]
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [Required]
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}