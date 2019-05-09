using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class ConductService : IConductService
    {
        private readonly DataContext db = new DataContext();

        public List<ConductResponseDto> GetConducts()
        {
            return db.Conducts.Where(x => !x.DelFlag).ToList().
                Select(x => new ConductResponseDto(x)).ToList();
        }
    }
}