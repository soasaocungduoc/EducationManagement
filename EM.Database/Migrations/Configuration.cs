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

            context.TypeMarks.Add(new TypeMark
            {
                Name = "Miệng",
                Factor = 1
            });

            context.TypeMarks.Add(new TypeMark
            {
                Name = "15 phút",
                Factor = 1
            });

            context.TypeMarks.Add(new TypeMark
            {
                Name = "1 tiết",
                Factor = 2
            });

            context.TypeMarks.Add(new TypeMark
            {
                Name = "Học kỳ",
                Factor = 3
            });

            context.TypeMarks.Add(new TypeMark
            {
                Name = "TBC",
                Factor = 0
            });

            context.Conducts.Add(new Conduct
            {
                ConductType = "Tốt"
            });
            context.Conducts.Add(new Conduct
            {
                ConductType = "Khá"
            });
            context.Conducts.Add(new Conduct
            {
                ConductType = "Trung bình"
            });
            context.Conducts.Add(new Conduct
            {
                ConductType = "Yếu"
            });

            context.Conducts.Add(new Conduct
            {
                ConductType = "Kém"
            });

            context.Classifications.Add(new Classification
            {
                FromGpa = 8.0,
                ToGpa = 10.0,
                Name = "Giỏi"
            });

            context.Classifications.Add(new Classification
            {
                FromGpa = 6.5,
                ToGpa = 7.9,
                Name = "Khá"
            });

            context.Classifications.Add(new Classification
            {
                FromGpa = 5.0,
                ToGpa = 6.4,
                Name = "Trung bình"
            });

            context.Classifications.Add(new Classification
            {
                FromGpa = 3.5,
                ToGpa = 4.9,
                Name = "Yếu"
            });

            context.Classifications.Add(new Classification
            {
                FromGpa = 0.0,
                ToGpa = 3.4,
                Name = "Kém"
            });

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
