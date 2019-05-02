using Newtonsoft.Json;

namespace EducationManagement.Dtos.OutputDtos
{
    public class StudentResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("user")]
        public UserResponseDto UserInfo { get; set; }

        [JsonProperty("class_name")]
        public ClassInfoForListStudent ClassInfo { get; set; }

        [JsonProperty("parent_name")]
        public ParentInfoForListStudent ParentInfo { get; set; }
    }
}