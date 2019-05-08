using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class NotificationDto
    {
        [JsonProperty("senderid")]
        public int? SenderId { get; set; }

        [JsonProperty("receiverid")]
        public int? ReceiverId { get; set; }

        [JsonProperty("classreceiverid")]
        public int? ClassReceiverId { get; set; }

        [Required]
        [StringLength(100)]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        [JsonProperty("content")]
        public string Content { get; set; }

        [Required]
        [StringLength(30)]
        [JsonProperty("type")]
        public string Type { get; set; }

    }
}