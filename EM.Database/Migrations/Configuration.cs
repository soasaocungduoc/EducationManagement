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
            for (int i = 1; i < 7; i++)
            {
                context.Permissions.Add(new Permission
                {
                    GroupId = i,
                    FunctionId = 13,
                    IsEnable = true,
                });
                context.Permissions.Add(new Permission
                {
                    GroupId = i,
                    FunctionId = 14,
                    IsEnable = true,
                });
                context.Permissions.Add(new Permission
                {
                    GroupId = i,
                    FunctionId = 15,
                    IsEnable = true,
                });
                context.Permissions.Add(new Permission
                {
                    GroupId = i,
                    FunctionId = 16,
                    IsEnable = true,
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
