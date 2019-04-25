using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class StudentOfParentResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("user")]
        public UserResponseDto UserInfo { get; set; }

        [JsonProperty("class_name")]
        public ClassInfoForListStudent ClassInfo { get; set; }
    }
}