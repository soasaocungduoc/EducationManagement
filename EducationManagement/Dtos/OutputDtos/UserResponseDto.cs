using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class UserResponseDto
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

        public UserResponseDto()
        {

        }

        public UserResponseDto(EM.Database.Schema.User user)
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

        public UserResponseDto(int id, string firstName, string lastName, string avatar, bool gender, DateTime birthday, string phoneNumber, string address, string identificationNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Avatar = avatar;
            Gender = gender;
            Birthday = birthday;
            PhoneNumber = phoneNumber;
            Address = address;
            IdentificationNumber = identificationNumber;
        }
    }
}