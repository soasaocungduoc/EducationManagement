using Newtonsoft.Json;
using System;

namespace EducationManagement.Dtos.OutputDtos
{
    public class ProfileResultDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("gender")]
        public bool Gender { get; set; }

        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("indetification_number")]
        public string IdentificationNumber { get; set; }
    }
}