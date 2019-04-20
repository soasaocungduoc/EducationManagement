using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly DataContext db = new DataContext();

        public List<StudentResponseDto> GetStudentsByParentId(int parentId)
        {
            try
            {
                return db.Students.Include(u => u.User).Include(c => c.Class).Include(p => p.Parent).Where(x => !x.DelFlag && x.ParentId == parentId).ToList()
                    .Select(s => new StudentResponseDto
                    {
                        Id = s.Id,
                        ClassName = s.Class.Name,
                        UserInfo = new UserResponseDto(s.User),
                        ParentName = db.Parents.Include(u => u.User).FirstOrDefault(x => !x.DelFlag && x.Id == s.ParentId).User.FirstName
                    }).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}