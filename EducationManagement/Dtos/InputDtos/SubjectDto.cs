using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class SubjectDto
    {
        [JsonProperty("subject_name")]
        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; }

        [JsonProperty("team_id")]
        [Required]
        public int TeamId { get; set; }
    }
}