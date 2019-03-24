using Newtonsoft.Json;

namespace EducationManagement.Dtos.InputDtos
{
    public class LoginDto
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}