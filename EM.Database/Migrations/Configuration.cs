using EM.Database.Schema;

namespace EM.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EM.Database.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EM.Database.DataContext context)
        {
            //base.Seed(context);
            //context.Users.Add(new User
            //{
            //    Id = 1,
            //    FirstName = "Man",
            //    LastName = "Nguyen Van",
            //    Address = "Test",
            //    Birthday = new DateTime(1997, 7, 21),
            //    Gender = true,
            //    Avatar =
            //        "https://res.cloudinary.com/dw0yzvsvn/image/upload/v1537351431/Images/9b06a7b3-142b-429e-945a-37f6f026e823.jpg",
            //    PhoneNumber = "0966156153",
            //    IdentificationNumber = "201722516"
            //});

            //context.SaveChanges();

            //context.Accounts.Add(new Account
            //{
            //    Id = 1,
            //    IdUser = 1,
            //    UserName = "admin",
            //    Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5("password"))
            //});

            //context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
