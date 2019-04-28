using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class SemesterIdDto
    {
        [Required]
        [JsonProperty("semester_id")]
        public int id { get; set; }
    }
}