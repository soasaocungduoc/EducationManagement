using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class UserDto
    {

        [JsonProperty("phone_number")]
        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
    }
}