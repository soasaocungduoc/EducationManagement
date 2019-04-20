using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class StudentResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("user")]
        public UserResponseDto UserInfo { get; set; }

        [JsonProperty("class_name")]
        public string ClassName { get; set; }

        [JsonProperty("parent_name")]
        public string ParentName { get; set; }

        public StudentResponseDto()
        {

        }

        public StudentResponseDto(int id, UserResponseDto userInfo, string className, string parentName)
        {
            Id = id;
            UserInfo = userInfo;
            ClassName = className;
            ParentName = parentName;
        }
    }
}