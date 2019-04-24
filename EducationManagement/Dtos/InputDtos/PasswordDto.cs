using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class PasswordDto
    {
        [JsonProperty("old_password")]
        [Required]
        [StringLength(100)]
        public string OldPassword { get; set; }

        [JsonProperty("new_password")]
        [Required]
        [StringLength(100)]
        public string NewPassword { get; set; }
    }
}