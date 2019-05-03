using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using EM.Database.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace EducationManagement.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly DataContext db = new DataContext();
        public void AddStudent(StudentDto dto)
        {
            var user = new User();
            var account = new Account();
            var student = new Student();
            
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

                account.UserName = "student_account" + db.Accounts.Max(x => x.Id).ToString();
                account.Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5("12345678"));
                account.UserId = user.Id;
                account.GroupId = 4;

                db.Accounts.Add(account);

                student.UserId = user.Id;
                student.ClassId = dto.ClassId;
                student.ParentId = dto.ParentId;
                student.Status = 0;

                db.Students.Add(student);

            }
            catch(Exception e)
            {
                throw e;
            }
            
            db.SaveChanges();
        }

        public int[] AddStudents(StudentDto[] dtos)
        {
            var errorIndexs = new List<int>();

            int i = 0;

            foreach (StudentDto dto in dtos)
            {
                try
                {
                    AddStudent(dto);
                }
                catch
                {
                    errorIndexs.Add(i);
                }
                i++;
            }
            
            return errorIndexs.ToArray();
        }

        public StudentResponseDto Get(int studentId)
        {
            var studentFromDb = db.Students
                .Include(x => x.User)
                .Include(x => x.Parent)
                .Include(x => x.Class)
                .FirstOrDefault(x => x.Id == studentId && x.DelFlag == false);

            if (studentFromDb == null)
            {
                return null;
            }

            var parentFromDb = db.Parents
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == studentFromDb.ParentId && x.DelFlag == false);

            if(parentFromDb == null)
            {
                return null;
            }

            return new StudentResponseDto()
            {
                Id = studentFromDb.Id,
                UserInfo = new UserResponseDto(studentFromDb.User),
                ClassInfo = new ClassInfoForListStudent(studentFromDb.Class),
                ParentInfo = new ParentInfoForListStudent()
                {
                    Id = studentFromDb.ParentId,
                    Name = parentFromDb.User.FirstName
                }
            };
        }

        public StudentResponseDto Update(int studentId, StudentDto dto)
        {
            var studentFromDb = db.Students.FirstOrDefault(x => x.Id == studentId && x.DelFlag == false);

            if(studentFromDb == null)
            {
                return null;
            }
            
            var userFromDb = db.Users.FirstOrDefault(x => x.Id == studentFromDb.UserId && x.DelFlag == false);

            if (userFromDb == null)
            {
                return null;
            }

            try
            {
                studentFromDb.ParentId = dto.ParentId;
                studentFromDb.ClassId = dto.ClassId;

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

            return Get(studentId);
        }

        public bool Delete(int studentId)
        {
            var studentFromDb = db.Students.FirstOrDefault(x => x.Id == studentId && x.DelFlag == false);

            if (studentFromDb == null)
            {
                return false;
            }

            try
            {
                studentFromDb.DelFlag = true;

                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public ListStudentsOfClassResponseDto GetStudentsByClassId(int classId)
        {
            try
            {
                var Class = db.Classes.FirstOrDefault(x => !x.DelFlag && x.Id == classId);
                if (Class == null) return null;
                ListStudentsOfClassResponseDto students = new ListStudentsOfClassResponseDto();

                students.ClassInfo = new ClassInfoForListStudent(Class);

                students.Students = db.Students.Include(u => u.User).Include(c => c.Class).Include(p => p.Parent).Where(x => !x.DelFlag && x.ClassId == classId).ToList()
                    .Select(s => new StudentOfClassResponseDto
                    {
                        Id = s.Id,
                        UserInfo = new UserResponseDto(s.User),
                        ParentInfo = new ParentInfoForListStudent(s.Parent.UserId, db.Parents.Include(u => u.User).FirstOrDefault(x => !x.DelFlag && x.Id == s.ParentId).User.FirstName)
                    }).ToList();
                return students;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ListStudentOfParentResponseDto GetStudentsByParentId(int id)
        {
            try
            {
                var parent = db.Parents.Include(u => u.User).FirstOrDefault(x => !x.DelFlag && x.UserId == id);
                if (parent == null) return null;
                ListStudentOfParentResponseDto students = new ListStudentOfParentResponseDto();
                students.ParentInfo = new ParentInfoForListStudent(id, parent.User.LastName + " " + parent.User.FirstName);
                students.Students = db.Students.Include(u => u.User).Include(c => c.Class).Include(p => p.Parent).Where(x => !x.DelFlag && x.Parent.UserId == id).ToList()
                    .Select(s => new StudentOfParentResponseDto
                    {
                        Id = s.Id,
                        ClassInfo = new ClassInfoForListStudent(s.Class),
                        UserInfo = new UserResponseDto(s.User),
                    }).ToList();
                return students;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}