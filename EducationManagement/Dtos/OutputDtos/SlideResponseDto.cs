using EM.Database.Schema;
using Newtonsoft.Json;

namespace EducationManagement.Dtos.OutputDtos
{
    public class SlideResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("is_shown")]
        public bool IsShown { get; set; }

        public SlideResponseDto()
        {

        }

        public SlideResponseDto(Slide slide)
        {
            Id = slide.Id;
            Title = slide.Title;
            ImageUrl = slide.ImageUrl;
            Path = slide.Path;
            IsShown = slide.IsShown;
        }

    }
}