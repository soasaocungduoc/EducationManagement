using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class NotificationDetailDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("receiver")]
        public UserResponseDto Receiver { get; set; }

        [JsonProperty("sender")]
        public UserResponseDto Sender { get; set; }

        [JsonProperty("classreceiver")]
        public ClassResponseDto ClassReceiver { get; set; }

        public NotificationDetailDto()
        {

        }

        public NotificationDetailDto(string title, string content, string type, UserResponseDto receiver, UserResponseDto sender, ClassResponseDto classReceiver)
        {
            Title = title;
            Content = content;
            Type = type;
            Receiver = receiver;
            Sender = sender;
            ClassReceiver = classReceiver;
        }
    }
}