using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class ListStudentOfParentResponseDto
    {
        [JsonProperty("parent_info")]
        public ParentInfoForListStudent ParentInfo { get; set; }

        [JsonProperty("all_student")]
        public List<StudentOfParentResponseDto> Students { get; set; }

        public ListStudentOfParentResponseDto()
        {

        }

        public ListStudentOfParentResponseDto(ParentInfoForListStudent parentInfo, List<StudentOfParentResponseDto> students)
        {
            ParentInfo = parentInfo;
            Students = students;
        }
    }
}