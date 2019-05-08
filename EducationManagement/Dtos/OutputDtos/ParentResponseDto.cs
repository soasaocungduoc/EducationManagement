using EM.Database.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class ParentResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("user_info")]
        public UserResponseDto UserInfo { get; set; }

        public ParentResponseDto()
        {

        }

        public ParentResponseDto(int id, UserResponseDto userInfo)
        {
            Id = id;
            UserInfo = userInfo;
        }

        public ParentResponseDto(Parent parent)
        {
            Id = parent.Id;
            UserInfo = new UserResponseDto(parent.User);
        }
    }
}