using EM.Database.Schema;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;

namespace EM.Database.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EM.Database.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {

            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 9,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 16,
            //    SemesterId = 10
            //});

            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 10,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 16,
            //    SemesterId = 10
            //});

            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 8,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 17,
            //    SemesterId = 10
            //});

            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 8.5,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 18,
            //    SemesterId = 10
            //});
            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 7.3,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 19,
            //    SemesterId = 10
            //});
            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 9,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 20,
            //    SemesterId = 10
            //});

            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 9.5,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 21,
            //    SemesterId = 10
            //});
            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 7.5,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 22,
            //    SemesterId = 10
            //});
            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 8.5,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 23,
            //    SemesterId = 10
            //});
            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 10,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 24,
            //    SemesterId = 10
            //});
            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 9,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 25,
            //    SemesterId = 10
            //});
            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 9.3,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 26,
            //    SemesterId = 10
            //});
            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 8,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 27,
            //    SemesterId = 10
            //});
            //context.SubjectMarks.Add(new SubjectMark
            //{
            //    Mark = 10,
            //    TypeMarkId = 3,
            //    StudentId = 5,
            //    SubjectId = 28,
            //    SemesterId = 10
            //});



            //context.Functions.Add(new Function
            //{
            //    ScreenId = 4,
            //    Name = "Get list of slides",
            //    Description = "Lay danh sach slide",
            //    Area = "Home",
            //    ControllerName = "SlideController",
            //    ActionName = "GetSlides",
            //});

            //List<string> ten = new List<string>{"An", "Kiều", "Cường", "Đạt", "Hằng", "Uyên", "Giàu", "Hạnh", "Trường", "Khiêm", "Lan", "Minh", "Ngọc", "Anh", "Phong", "Quốc",
            //    "Nhi", "Sơn", "Phúc", "Quyên", "Quang","My","Vy" };
            //List<string> ho = new List<string> { "Đinh", "Huỳnh", "Lê", "Trương", "Hoàng", "Trần", "Lý" };
            //for (int i = 0; i < 22; i++)
            //{
            //    context.Users.Add(new User
            //    {
            //        FirstName = ten[i],
            //        LastName = ho[i%7],
            //        Avatar = "https://i.pinimg.com/originals/78/7f/27/787f271113b6fae60a7144dbff2b394a.jpg",
            //        Gender = false,
            //        Birthday = new DateTime(1997, 10, i+1),
            //        PhoneNumber = "0789456123",
            //        Address = "123 Nguyen Luong Bang",
            //        IdentificationNumber = "123456789",
            //    });
            //}

            //for (int i = 77; i <= 98; i++)
            //{

            //    context.Parents.Add(new Parent
            //    {
            //        UserId = i
            //    });

            //    context.Accounts.Add(new Account
            //    {
            //        UserId = i,
            //        GroupId = 5,
            //        UserName = "parent" + i,
            //        Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5("123456")),
            //    });
            //}
            //context.Users.Add(new User
            //{
            //    FirstName = "Tram",
            //    LastName = "Huynh",
            //    Avatar = "https://i.pinimg.com/originals/78/7f/27/787f271113b6fae60a7144dbff2b394a.jpg",
            //    Gender = false,
            //    Birthday = new DateTime(1997, 10, 30),
            //    PhoneNumber = "0789456123",
            //    Address = "123 Nguyen Luong Bang",
            //    IdentificationNumber = "123456789",
            //});

            //context.Accounts.Add(new Account
            //{
            //    UserId = 5,
            //    GroupId = 3,
            //    UserName = "developer5",
            //    Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5("123456")),
            //});


            //// Your code...
            //// Could also be before try if you know the exception occurs in SaveChanges

            //context.SaveChanges();



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
