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

            context.Teachers.Add(new Teacher
            {
                UserId = 33,
                TeamId = 19
            });
            context.Teachers.Add(new Teacher
            {
                UserId = 34,
                TeamId = 19
            });
            context.Teachers.Add(new Teacher
            {
                UserId = 35,
                TeamId = 20
            });
            context.Teachers.Add(new Teacher
            {
                UserId = 36,
                TeamId = 20
            });
            context.Teachers.Add(new Teacher
            {
                UserId = 37,
                TeamId = 21
            });
            context.Teachers.Add(new Teacher
            {
                UserId = 38,
                TeamId = 21
            });
            context.Teachers.Add(new Teacher
            {
                UserId = 39,
                TeamId = 22
            });
            context.Teachers.Add(new Teacher
            {
                UserId = 40,
                TeamId = 23
            });
            context.Teachers.Add(new Teacher
            {
                UserId = 41,
                TeamId = 23
            });
            context.Teachers.Add(new Teacher
            {
                UserId = 42,
                TeamId = 23
            });
            context.Teachers.Add(new Teacher
            {
                UserId = 43,
                TeamId = 24
            });
            context.Teachers.Add(new Teacher
            {
                UserId = 44,
                TeamId = 25
            });
            context.Teachers.Add(new Teacher
            {
                UserId = 45,
                TeamId = 25
            });

            //context.Functions.Add(new Function
            //{
            //    ScreenId = 4,
            //    Name = "DeleteSlide",
            //    Description = "Xoa slide",
            //    Area = "Admin",
            //    ControllerName = "Slide",
            //    ActionName = "DeleteSlide",
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
