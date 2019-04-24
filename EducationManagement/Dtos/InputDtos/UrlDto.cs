using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EducationManagement.Dtos.InputDtos
{
    public class UrlDto
    {   
        [Required]
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}