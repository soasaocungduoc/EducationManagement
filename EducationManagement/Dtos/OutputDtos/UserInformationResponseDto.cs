using Newtonsoft.Json;

namespace EducationManagement.Dtos.OutputDtos
{
    public class UserInformationResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        public UserInformationResponseDto(EM.Database.Schema.User user, string username)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            AvatarUrl = user.Avatar;
            Username = username;
        }
    }
}