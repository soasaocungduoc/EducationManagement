using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly DataContext db = new DataContext();

        public List<TeamResponseDto> GetTeams()
        {
            return db.Teams.Where(x => !x.DelFlag).ToList().
                Select(x => new TeamResponseDto(x)).ToList();
        }
    }
}