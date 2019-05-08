using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class MarkInTeachingClassResponseDto
    {
        [JsonProperty("class_name")]
        public string ClassName { get; set; }

        [JsonProperty("list_of_subjects")]
        public List<SubjectMarkOfStudentInClass> Subjects { get; set; }

        public MarkInTeachingClassResponseDto()
        {

        }

        public MarkInTeachingClassResponseDto(string className, List<SubjectMarkOfStudentInClass> subjects)
        {
            ClassName = className;
            Subjects = subjects;
        }
    }
}