using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos
{
    public class User
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

        [JsonProperty("identification_number")]
        public string IdentificationNumber { get; set; }

        public User(EM.Database.Schema.User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Avatar = user.Avatar;
            Gender = user.Gender;
            Birthday = user.Birthday;
            PhoneNumber = user.PhoneNumber;
            Address = user.Address;
            IdentificationNumber = user.IdentificationNumber;
        }
    }
}