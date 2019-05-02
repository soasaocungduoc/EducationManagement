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

        public TeacherResponseDto Get(int teacherId)
        {
            var teacher = db.Teachers.FirstOrDefault(x => x.Id == teacherId);

            if(teacher == null)
            {
                return null;
            }

            var team = db.Teams.FirstOrDefault(x => x.Id == teacher.TeamId);

            if(team == null)
            {
                return null;
            }

            var user = db.Users.FirstOrDefault(x => x.Id == teacher.UserId);

            if(user == null)
            {
                return null;
            }
            return new TeacherResponseDto()
            {
                Id = teacher.Id,
                TeamInfo = new TeamResponseDto()
                {
                    Id = teacher.TeamId,
                    Name = team.Name
                },
                UserInfo = new UserResponseDto()
                {
                    Id = teacher.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    Address = user.Address,
                    Birthday = user.Birthday,
                    IdentificationNumber = user.IdentificationNumber,
                    PhoneNumber = user.PhoneNumber,
                    Avatar = user.Avatar
                }

            };
        }

        public TeacherResponseDto Update(int teacherId, TeacherDto dto)
        {
            var teacherFromDb = db.Teachers.FirstOrDefault(x => x.Id == teacherId);

            if(teacherFromDb == null)
            {
                return null;
            }

            teacherFromDb.TeamId = dto.TeamId;

            var userFromDb = db.Users.FirstOrDefault(x => x.Id == teacherFromDb.UserId);

            if(userFromDb == null)
            {
                return null;
            }

            try
            {
                userFromDb.FirstName = dto.FirstName;
                userFromDb.LastName = dto.LastName;
                userFromDb.Gender = dto.Gender;
                userFromDb.Birthday = dto.Birthday;
                userFromDb.PhoneNumber = dto.PhoneNumber;
                userFromDb.Address = dto.Address;
                userFromDb.Avatar = dto.Avatar;
                userFromDb.IdentificationNumber = dto.IdentificationNumber;

                db.SaveChanges();
            }
            catch
            {
                return null;
            }

            return Get(teacherId);
        }

        public bool Delete(int teacherId)
        {
            var teacherFromDb = db.Teachers.FirstOrDefault(x => x.Id == teacherId);

            if(teacherFromDb == null)
            {
                return false;
            }

            try
            {
                teacherFromDb.DelFlag = true;

                db.SaveChanges();
            }
            catch
            {
                return false;
            }

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

        public string GetTeacherName(int teacherId)
        {
            try
            {
                return db.Teachers.Include(u => u.User).FirstOrDefault(x => !x.DelFlag && x.Id == teacherId).User.FirstName;
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}