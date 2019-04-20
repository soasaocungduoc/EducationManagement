using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class ScheduleSubjectResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("subject_name")]
        public string SubjectName { get; set; }

        [JsonProperty("teacher_name")]
        public string TeacherName { get; set; }

        [JsonProperty("class_name")]
        public string ClassName { get; set; }

        [JsonProperty("day_of_week")]
        public int DayOfWeek { get; set; }

        [JsonProperty("lesson")]
        public int Lesson { get; set; }


        public ScheduleSubjectResponseDto()
        {

        }

        public ScheduleSubjectResponseDto(int id, string subjectName, string teacherName, string className, int dayOfWeek, int lesson)
        {
            Id = id;
            SubjectName = subjectName;
            TeacherName = teacherName;
            ClassName = className;
            DayOfWeek = dayOfWeek;
            Lesson = lesson;
        }
    }
}