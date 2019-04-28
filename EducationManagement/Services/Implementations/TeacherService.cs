using EducationManagement.Dtos;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using EM.Database.Schema;
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

        public bool Add(TeacherDto dto)
        {
            var user = new EM.Database.Schema.User();
            var account = new Account();
            var teacher = new Teacher();

            try
            {
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.Avatar = dto.Avatar;
                user.Gender = dto.Gender;
                user.Birthday = Convert.ToDateTime(dto.Birthday);
                user.PhoneNumber = dto.PhoneNumber;
                user.Address = dto.Address;
                user.IdentificationNumber = dto.IdentificationNumber;

                db.Users.Add(user);

                account.UserName = "teacher_" + db.Accounts.Max(x => x.Id).ToString();
                account.Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5("12345678"));
                account.UserId = user.Id;
                account.GroupId = 6;

                db.Accounts.Add(account);

                teacher.UserId = user.Id;
                teacher.TeamId = dto.TeamId;

                db.Teachers.Add(teacher);

            }
            catch (Exception e)
            {
                return false;
            }

            db.SaveChanges();

            return true;
        }

        public List<TeacherResponseDto> GetListOfTeachers(TeacherConditionSearch conditionSearch)
        {
            try
            {
                // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
                if (conditionSearch == null)
                {
                    conditionSearch = new TeacherConditionSearch();
                }

                // Lấy các thông tin dùng để phân trang
                var paging = new Commons.Paging(db.Teachers.Count(x => !x.DelFlag &&
                    (conditionSearch.KeySearch == null ||
                    (conditionSearch.KeySearch != null && ((x.User.FirstName.Contains(conditionSearch.KeySearch)) || 
                    (x.User.LastName.Contains(conditionSearch.KeySearch))))))
                    , conditionSearch.CurrentPage, conditionSearch.PageSize);

                // Tìm kiếm và lấy dữ liệu theo trang
                var listTeacherFromDb = db.Teachers.Include(u => u.User).Include(y=>y.Team).Where(x => !x.DelFlag &&
                    (conditionSearch.KeySearch == null ||
                    (conditionSearch.KeySearch != null && ((x.User.FirstName.Contains(conditionSearch.KeySearch)) ||
                    (x.User.LastName.Contains(conditionSearch.KeySearch))))))
                    .OrderBy(x => x.Id)
                    .Skip((paging.CurrentPage - 1) * paging.NumberOfRecord)
                    .Take(paging.NumberOfRecord).ToList();
                if (listTeacherFromDb == null)
                    return null;
                var listOfTeacher = listTeacherFromDb.Select(t => new TeacherResponseDto
                {
                    Id = t.Id,
                    TeamInfo = new TeamResponseDto(t.Team),
                    UserInfo = new UserResponseDto(t.User)
                }).ToList();
                return listOfTeacher;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}