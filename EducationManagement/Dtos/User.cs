using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstname")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("gender")]
        public bool Gender { get; set; }

        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty("phone_number")]
        [Required]
        [StringLength(15)]
        [Phone]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [JsonProperty("identification_number")]
        [Required]
        [StringLength(12)]
        public string IdentificationNumber { get; set; }

        public User()
        {
                
        }

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

        public User(int id, string firstName, string lastName, string avatar, bool gender, DateTime birthday, string phoneNumber, string address, string identificationNumber)
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