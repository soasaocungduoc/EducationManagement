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
        public ClassInfoForListStudent ClassInfo { get; set; }

        [JsonProperty("parent_name")]
        public ParentInfoForListStudent ParentInfo { get; set; }

        public StudentResponseDto()
        {

        }

        public StudentResponseDto(int id, UserResponseDto userInfo, ClassInfoForListStudent classInfo, ParentInfoForListStudent parentInfo)
        {
            Id = id;
            UserInfo = userInfo;
            ClassInfo = classInfo;
            ParentInfo = parentInfo;
        }
    }
}