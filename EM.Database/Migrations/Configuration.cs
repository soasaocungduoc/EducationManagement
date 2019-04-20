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


            context.Semesters.Add(new Semester
            {
                Name = "Học kỳ I",
                StartTime = Convert.ToDateTime("20/08/2014"),
                EndTime = Convert.ToDateTime("31/12/2014"),
                ScholasticId = 1
            });
            context.Semesters.Add(new Semester
            {
                Name = "Học kỳ II",
                StartTime = Convert.ToDateTime("01/01/2015"),
                EndTime = Convert.ToDateTime("31/05/2015"),
                ScholasticId = 1
            });
            context.Semesters.Add(new Semester
            {
                Name = "Học kỳ I",
                StartTime = Convert.ToDateTime("20/08/2015"),
                EndTime = Convert.ToDateTime("31/12/2015"),
                ScholasticId = 2
            });
            context.Semesters.Add(new Semester
            {
                Name = "Học kỳ II",
                StartTime = Convert.ToDateTime("01/01/2016"),
                EndTime = Convert.ToDateTime("31/05/2016"),
                ScholasticId = 2
            });
            context.Semesters.Add(new Semester
            {
                Name = "Học kỳ I",
                StartTime = Convert.ToDateTime("20/08/2016"),
                EndTime = Convert.ToDateTime("31/12/2016"),
                ScholasticId = 3
            });
            context.Semesters.Add(new Semester
            {
                Name = "Học kỳ II",
                StartTime = Convert.ToDateTime("01/01/2017"),
                EndTime = Convert.ToDateTime("31/05/2017"),
                ScholasticId = 3
            });
            context.Semesters.Add(new Semester
            {
                Name = "Học kỳ I",
                StartTime = Convert.ToDateTime("20/08/2017"),
                EndTime = Convert.ToDateTime("31/12/2017"),
                ScholasticId = 4
            });
            context.Semesters.Add(new Semester
            {
                Name = "Học kỳ II",
                StartTime = Convert.ToDateTime("01/01/2018"),
                EndTime = Convert.ToDateTime("31/05/2018"),
                ScholasticId = 4
            });
            context.Semesters.Add(new Semester
            {
                Name = "Học kỳ I",
                StartTime = Convert.ToDateTime("20/08/2018"),
                EndTime = Convert.ToDateTime("31/12/2018"),
                ScholasticId = 5
            });
            context.Semesters.Add(new Semester
            {
                Name = "Học kỳ II",
                StartTime = Convert.ToDateTime("01/01/2019"),
                EndTime = Convert.ToDateTime("31/05/2019"),
                ScholasticId = 5
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
