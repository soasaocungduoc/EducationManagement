using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class ScheduleSubjectOfClassDto
    {
        [Required]
        [JsonProperty("class_id")]
        public int ClassId { get; set; }

        [Required]
        [JsonProperty("semester_id")]
        public int SemesterId { get; set; }

        [Required]
        [JsonProperty("schedule_subjects")]
        public List<ScheduleSubjectDto> ScheduleSubjects { get; set; }

    }
}