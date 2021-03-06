﻿using System;
using Newtonsoft.Json;

namespace EducationManagement.Dtos.OutputDtos
{
    public class NewsResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        
        [JsonProperty("summary")]
        public string Summary { get; set; }
        
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        public NewsResponseDto()
        {

        }

        public NewsResponseDto(EM.Database.Schema.News news)
        {
            if (news == null) return;
            Id = news.Id;
            Title = news.Title;
            ImageUrl = news.ImageUrl;
            Summary = news.Summary;
            Content = news.Content;
            CreatedAt = news.CreatedAt;
        }
    }
}