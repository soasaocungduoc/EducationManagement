using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class TypeMarkService : ITypeMarkService
    {
        private readonly DataContext db = new DataContext();

        public List<TypeMarkResponseDto> GetTypeMarks()
        {
            return db.TypeMarks.Where(x => !x.DelFlag).ToList().
                Select(x => new TypeMarkResponseDto(x)).ToList();
        }
    }
}