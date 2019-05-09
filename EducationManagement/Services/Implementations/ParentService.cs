using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MoreLinq;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Commons;

namespace EducationManagement.Services.Implementations
{
    public class ParentService : IParentService
    {
        private readonly DataContext db = new DataContext();
        

        public bool AddParent(ParentDto parent)
        {
            try
            {
                var user = new EM.Database.Schema.User
                {
                    FirstName = parent.FirstName,
                    LastName = parent.LastName,
                    Gender = parent.Gender,
                    Birthday = parent.Birthday,
                    Address = parent.Address,
                    PhoneNumber = parent.PhoneNumber,
                    IdentificationNumber = parent.IdentificationNumber,
                    Avatar = parent.Avatar
                };

                db.Users.Add(user);
                db.SaveChanges();
                var account = new EM.Database.Schema.Account
                {
                    UserName = parent.Username,
                    Password = FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(parent.Password)),
                    UserId = user.Id,
                    GroupId = db.Groups.FirstOrDefault(x => !x.DelFlag && x.Name.Equals("Parent")).Id
                };

                db.Accounts.Add(account);
                db.SaveChanges();

                var parentFromDb = new EM.Database.Schema.Parent
                {
                    UserId = user.Id
                };
                db.Parents.Add(parentFromDb);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

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