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


            //for (int i = 1; i < 7; i++)
            //{
            //    context.Permissions.Add(new Permission
            //    {
            //        GroupId = i,
            //        FunctionId = 1,
            //        IsEnable = false,
            //    });
            //    context.Permissions.Add(new Permission
            //    {
            //        GroupId = i,
            //        FunctionId = 2,
            //        IsEnable = false,
            //    });
            //    context.Permissions.Add(new Permission
            //    {
            //        GroupId = i,
            //        FunctionId = 3,
            //        IsEnable = false,
            //    });
            //    context.Permissions.Add(new Permission
            //    {
            //        GroupId = i,
            //        FunctionId = 4,
            //        IsEnable = false,
            //    });
            //    context.Permissions.Add(new Permission
            //    {
            //        GroupId = i,
            //        FunctionId = 5,
            //        IsEnable = false,
            //    });
            //    context.Permissions.Add(new Permission
            //    {
            //        GroupId = i,
            //        FunctionId = 6,
            //        IsEnable = false,
            //    });
            //}



            context.Functions.Add(new Function
            {
                ScreenId = 2,
                Name = "Get news by id",
                Description = "Lay mot tin tuc",
                Area = "Home",
                ControllerName = "News",
                ActionName = "GetNewsById",
            });

            context.Functions.Add(new Function
            {
                ScreenId = 5,
                Name = "Get slide by id",
                Description = "Lay mot slide",
                Area = "Home",
                ControllerName = "Slide",
                ActionName = "GetSlideById",
            });

            context.Functions.Add(new Function
            {
                ScreenId = 5,
                Name = "Add slide",
                Description = "Them slide",
                Area = "Admin",
                ControllerName = "Slide",
                ActionName = "AddSlide",
            });
            context.Functions.Add(new Function
            {
                ScreenId = 5,
                Name = "UpdateSlide",
                Description = "Chinh sua slide",
                Area = "Admin",
                ControllerName = "Slide",
                ActionName = "UpdateSlide",
            });

            context.Functions.Add(new Function
            {
                ScreenId = 4,
                Name = "DeleteSlide",
                Description = "Xoa slide",
                Area = "Admin",
                ControllerName = "Slide",
                ActionName = "DeleteSlide",
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
