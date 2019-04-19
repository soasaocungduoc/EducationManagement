using EM.Database.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class TeamResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeamResponseDto()
        {

        }

        public TeamResponseDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public TeamResponseDto(Team team)
        {
            Id = team.Id;
            Name = team.Name;
        }
    }
}