using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class TeacherResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("user")]
        public UserResponseDto UserInfo { get; set; }

        [JsonProperty("team_name")]
        public TeamResponseDto TeamInfo { get; set; }

        public TeacherResponseDto()
        {
            
        }

        public TeacherResponseDto(int id, UserResponseDto user, TeamResponseDto teamInfo)
        {
            Id = id;
            UserInfo = user;
            TeamInfo = teamInfo;
        }
    }
}