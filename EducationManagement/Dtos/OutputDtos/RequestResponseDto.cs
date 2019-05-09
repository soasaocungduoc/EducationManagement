using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class RequestResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("sender")]
        public UserResponseDto Sender { get; set; }

        public RequestResponseDto()
        {

        }
    }
}
