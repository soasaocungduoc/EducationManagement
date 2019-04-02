using Newtonsoft.Json;

namespace EducationManagement.Dtos.OutputDtos
{
    public class LoginResultDto
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("user")]
        public UserInformationResponseDto User { get; set; }

        [JsonProperty("group")]
        public GroupResponseDto Group { get; set; }
    }
}