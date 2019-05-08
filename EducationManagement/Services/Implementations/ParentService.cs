using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace EducationManagement.Services.Implementations
{
    public class ParentService : IParentService
    {
        private readonly DataContext db = new DataContext();

        public List<ParentResponseDto> GetParents()
        {
            return db.Parents.Include(x => x.User).Where(x => !x.DelFlag).ToList().
                Select(x => new ParentResponseDto(x)).ToList();
        }
    }
}