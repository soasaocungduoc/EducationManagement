using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class SubjectMarkOfStudentInClass
    {

        [JsonProperty("subject_name")]
        public string SubjectName { get; set; }

        [JsonProperty("list_of_students")]
        public List<StudentInfoForViewMark> Students { get; set; }

        public SubjectMarkOfStudentInClass()
        {

        }

        public SubjectMarkOfStudentInClass(string subjectName, List<StudentInfoForViewMark> students)
        {
            SubjectName = subjectName;
            Students = students;
        }
    }
}