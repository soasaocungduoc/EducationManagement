using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class RequestDto
    {
        [JsonProperty("senderid")]
        public int? SenderId { get; set; }

        [Required]
        [StringLength(100)]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        [JsonProperty("content")]
        public string Content { get; set; }
        
    }
}