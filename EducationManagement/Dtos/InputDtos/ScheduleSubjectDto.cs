using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.InputDtos
{
    public class ScheduleSubjectDto
    {
        [Required]
        [JsonProperty("day_of_week")]
        public int DayOfWeek { get; set; }

        [Required]
        [JsonProperty("lesson")]
        public int Lesson { get; set; }

        [Required]
        [JsonProperty("subject_id")]
        public int SubjectId { get; set; }

        [Required]
        [JsonProperty("teacher_id")]
        public int TeacherId { get; set; }

        public ScheduleSubjectDto()
        {

        }

        public ScheduleSubjectDto(int dayOfWeek, int lesson, int subjectId, int teacherId)
        {
            DayOfWeek = dayOfWeek;
            Lesson = lesson;
            SubjectId = subjectId;
            TeacherId = teacherId;
        }
    }
}