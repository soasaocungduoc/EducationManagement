using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class ListStudentsOfClassResponseDto
    {
        [JsonProperty("class_info")]
        public ClassInfoForListStudent ClassInfo { get; set; }

        [JsonProperty("all_student")]
        public List<StudentOfClassResponseDto> Students { get; set; }

        public ListStudentsOfClassResponseDto()
        {

        }

        public ListStudentsOfClassResponseDto(ClassInfoForListStudent classInfo, List<StudentOfClassResponseDto> students)
        {
            ClassInfo = classInfo;
            Students = students;
        }
    }
}