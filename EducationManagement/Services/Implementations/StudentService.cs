using EducationManagement.Dtos.InputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using EM.Database.Schema;
using System.Linq;
using System;
using System.Collections.Generic;

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

    }
}