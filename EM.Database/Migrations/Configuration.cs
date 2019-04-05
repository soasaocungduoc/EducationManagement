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

            context.Accounts.Add(new Account
            {
                UserId = 5,
                GroupId = 3,
                UserName = "developer5",
                Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5("123456")),
            });

            context.Accounts.Add(new Account
            {
                UserId = 3,
                GroupId = 6,
                UserName = "teacher3",
                Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5("123456")),
            });

            context.Accounts.Add(new Account
            {
                UserId = 4,
                GroupId = 5,
                UserName = "parent4",
                Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5("123456")),
            });

            context.Accounts.Add(new Account
            {
                UserId = 6,
                GroupId = 5,
                UserName = "mod4",
                Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5("123456")),
            });

            //// Your code...
            //// Could also be before try if you know the exception occurs in SaveChanges

            //context.SaveChanges();



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
