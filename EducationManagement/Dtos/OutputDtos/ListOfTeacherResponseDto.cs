using EducationManagement.Commons;
using EducationManagement.Dtos.InputDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class ListOfTeacherResponseDto
    {
        [JsonProperty("list_of_teachers")]
        public List<TeacherResponseDto> ListOfTeacher { set; get; }
        [JsonProperty("paging")]
        public Paging Paging { set; get; }
        [JsonProperty("teacher_condition_search")]
        public TeacherConditionSearch Condition { set; get; }
        public ListOfTeacherResponseDto()
        {
            this.ListOfTeacher = new List<TeacherResponseDto>();
            this.Condition = new TeacherConditionSearch();
            this.Paging = new Paging();
        }
    }
}