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

            context.Functions.Add(new Function
            {
                ScreenId = 1,
                Name = "Get list of news",
                Description = "Lay danh sach tin tuc",
                Area = "Home",
                ControllerName = "NewsController",
                ActionName = "GetNews",
            });
            context.Functions.Add(new Function
            {
                ScreenId = 1,
                Name = "Delete news",
                Description = "Xoa tin tuc",
                Area = "Admin",
                ControllerName = "NewsController",
                ActionName = "DeleteNews",
            });
            context.Functions.Add(new Function
            {
                ScreenId = 2,
                Name = "Add news",
                Description = "Them tin tuc",
                Area = "Admin",
                ControllerName = "NewsController",
                ActionName = "AddNews",
            });
            context.Functions.Add(new Function
            {
                ScreenId = 2,
                Name = "Edit news",
                Description = "Chinh sua tin tuc",
                Area = "Admin",
                ControllerName = "NewsController",
                ActionName = "UpdateNews",
            });

            context.Functions.Add(new Function
            {
                ScreenId = 3,
                Name = "Get list of teachers",
                Description = "Lay danh sach giao vien",
                Area = "Admin",
                ControllerName = "TeacherController",
                ActionName = "GetTeachers",
            });
            context.Functions.Add(new Function
            {
                ScreenId = 4,
                Name = "Get list of slides",
                Description = "Lay danh sach slide",
                Area = "Admin",
                ControllerName = "SlideController",
                ActionName = "GetSlides",
            });

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
