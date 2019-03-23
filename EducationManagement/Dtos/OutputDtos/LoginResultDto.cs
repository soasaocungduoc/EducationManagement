using Newtonsoft.Json;

namespace EducationManagement.Dtos.OutputDtos
{
    public class LoginResultDto
    {
        [JsonProperty("user_id")]
        public int? UserId { get; set; }
    }
}