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


            for (int i = 7; i < 12; i++)
            {
                context.Permissions.Add(new Permission
                {
                    GroupId = 1,
                    FunctionId = i,
                    IsEnable = true,
                });
                context.Permissions.Add(new Permission
                {
                    GroupId = 2,
                    FunctionId = i,
                    IsEnable = true,
                });
                context.Permissions.Add(new Permission
                {
                    GroupId = 3,
                    FunctionId = i,
                    IsEnable = true,
                });
            }


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
