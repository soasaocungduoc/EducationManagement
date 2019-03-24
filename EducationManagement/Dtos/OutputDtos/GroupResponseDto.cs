using Newtonsoft.Json;

namespace EducationManagement.Dtos.OutputDtos
{
    public class GroupResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}