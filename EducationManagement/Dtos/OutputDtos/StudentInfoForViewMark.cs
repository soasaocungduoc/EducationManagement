using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class StudentInfoForViewMark
    {
        [JsonProperty("student_id")]
        public int StudentId { get; set; }

        [JsonProperty("student_name")]
        public string StudentName { get; set; }

        [JsonProperty("all_mark_for_subject")]
        public List<MarkResponseDto> Marks { get; set; }

        public StudentInfoForViewMark()
        {

        }

        public StudentInfoForViewMark(int studentId, string studentName, List<MarkResponseDto> marks)
        {
            StudentId = studentId;
            StudentName = studentName;
            Marks = marks;
        }
    }
}