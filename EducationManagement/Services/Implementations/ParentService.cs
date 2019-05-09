using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MoreLinq;

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

        public List<ParentResponseDto> GetParentsByClassId(int classId)
        {
            if (db.Classes.FirstOrDefault(x => !x.DelFlag && x.Id == classId) == null)
                return null;
            var parentIds = db.Students.Include(x => x.Parent).ToList()
                .Where(x => !x.DelFlag && x.ClassId == classId)
                .Select(x => x.ParentId);

            var result = new List<ParentResponseDto>();

            if (parentIds == null) return result;

            var parents = db.Parents.Include(x => x.User)
                .Where(x => !x.DelFlag && parentIds.Contains(x.Id)).ToList()
                .Select(x=> new ParentResponseDto(x)).ToList();
            return parents ?? new List<ParentResponseDto>();
        }
    }
}