using EM.Database.Schema;
using System;
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
            base.Seed(context);
            var Roomid = 1;
            for (int i = 1; i < 4; i++)
            {
                context.Classes.Add(new Class
                {
                    Name = "10A" + i,
                    GradeId = 2,
                    NumberOfStudents = 30,
                    TeacherId = 8,
                    RoomId = Roomid++
                });
                context.Classes.Add(new Class
                {
                    Name = "11A" + i,
                    GradeId = 3,
                    NumberOfStudents = 30,
                    TeacherId = 8,
                    RoomId = Roomid++
                });
                context.Classes.Add(new Class
                {
                    Name = "12A" + i,
                    GradeId = 4,
                    NumberOfStudents = 30,
                    TeacherId = 8,
                    RoomId = Roomid++
                });
            }

            for (int i = 1; i < 4; i++)
            {
                context.Classes.Add(new Class
                {
                    Name = "10B" + i,
                    GradeId = 2,
                    NumberOfStudents = 30,
                    TeacherId = 8,
                    RoomId = Roomid++
                });
                context.Classes.Add(new Class
                {
                    Name = "11B" + i,
                    GradeId = 3,
                    NumberOfStudents = 30,
                    TeacherId = 8,
                    RoomId = Roomid++
                });
                context.Classes.Add(new Class
                {
                    Name = "12B" + i,
                    GradeId = 4,
                    NumberOfStudents = 30,
                    TeacherId = 8,
                    RoomId = Roomid++
                });
            }

            //context.Functions.Add(new Function
            //{
            //    ScreenId = 8,
            //    Name = "GetTeachingSchedulesByTeacherId",
            //    Description = "Get list teaching schedule by teacherid",
            //    Area = "Admin",
            //    ControllerName = "ScheduleSubject",
            //    ActionName = "GetTeachingSchedulesByTeacherId",
            //});

            //context.Users.Add(new User
            //{
            //    FirstName = "Thông",
            //    LastName = "Trần Văn",
            //    Avatar = "https://i.pinimg.com/originals/78/7f/27/787f271113b6fae60a7144dbff2b394a.jpg",
            //    Gender = true,
            //    Birthday = new DateTime(1997, 10, 30),
            //    PhoneNumber = "0789456123",
            //    Address = "123 Nguyễn Lương Bằng",
            //    IdentificationNumber = "123456789",
            //});

            //context.Accounts.Add(new Account
            //{
            //    UserId = i,
            //    GroupId = 6,
            //    UserName = "teacher" + i,
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
