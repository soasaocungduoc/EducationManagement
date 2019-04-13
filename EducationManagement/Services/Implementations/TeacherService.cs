using EducationManagement.Dtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly DataContext db = new DataContext();

        public List<Teacher> GetListOfTeachers()
        {
            return db.Teachers.Include(u => u.User).Where(x => !x.DelFlag).ToList().Select(t => new Teacher {
                Id = t.Id,
                TeamId = t.TeamId,
                User = new User(t.User)
            } ).ToList();
        }
    }
}