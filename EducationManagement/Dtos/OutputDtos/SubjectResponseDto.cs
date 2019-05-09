using EM.Database.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class SubjectResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("team_info")]
        public TeamResponseDto TeamInfo { get; set; }

        public SubjectResponseDto()
        {

        }

        public SubjectResponseDto(int id, string name, TeamResponseDto teamInfo)
        {
            Id = id;
            Name = name;
            TeamInfo = teamInfo;
        }

        public SubjectResponseDto(Subject subject)
        {
            Id = subject.Id;
            Name = subject.Name;
            TeamInfo = new TeamResponseDto(subject.Team);
        }
    }
}