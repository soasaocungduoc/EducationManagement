using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class UserInfoDto
    {
        [Required]
        [StringLength(100)]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        [JsonProperty("password")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("gender")]
        public bool Gender { get; set; }

        [Required]
        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(200)]
        [JsonProperty("address")]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        [Phone]
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; } = "https://res.cloudinary.com/dw0yzvsvn/image/upload/v1537351431/Images/9b06a7b3-142b-429e-945a-37f6f026e823.jpg";

        [Required]
        [StringLength(12)]
        [Phone]
        [JsonProperty("identification_number")]
        public string IdentificationNumber { get; set; }

        [Required]
        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }
    }
}