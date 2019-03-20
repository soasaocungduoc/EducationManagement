using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using EM.Database.Schema;
using EM.Database.Schema.Bases;
using Z.EntityFramework.Plus;


namespace EM.Database
{

    public partial class DataContext : DbContext
    {
        private static string ConnectionString = "Server=tcp:educationmanagement.database.windows.net,1433;Initial Catalog=educationmanagement;Persist Security Info=False;Users ID=man.dut;Password=1042107Td;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public DataContext()
           : base(ConnectionString)

        {
            System.Data.Entity.Database.SetInitializer<DataContext>(new DatabaseCreation());
        }
        public DataContext(string connectionString)
            : base(connectionString)
        {
            System.Data.Entity.Database.SetInitializer<DataContext>(new DatabaseCreation());
        }
        public override int SaveChanges()
        {
            try
            {
                if (ChangeTracker.HasChanges())
                {
                    foreach (var entry
                        in ChangeTracker.Entries())
                    {
                        try
                        {
                            var root = (Table)entry.Entity;
                            var now = DateTime.Now;
                            switch (entry.State)
                            {
                                case EntityState.Added:
                                    {
                                        root.Created_at = now;
                                        root.Created_by = DatabaseCreation.GetIdAccount();
                                        root.Updated_at = null;
                                        root.Updated_by = null;
                                        root.DelFlag = false;
                                        break;
                                    }
                                case EntityState.Modified:
                                    {
                                        root.Updated_at = now;
                                        root.Updated_by = DatabaseCreation.GetIdAccount();
                                        break;
                                    }
                            }
                        }
                        catch { }
                    }
                    var audit = new Audit();
                    audit.PreSaveChanges(this);
                    var rowAffecteds = base.SaveChanges();
                    audit.PostSaveChanges();

                    if (audit.Configuration.AutoSavePreAction != null)
                    {
                        audit.Configuration.AutoSavePreAction(this, audit);
                    }
                    return base.SaveChanges();
                }
                return 0;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AuditEntry> AuditEntries { get; set; }
        public virtual DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Classification> Classifications { get; set; }
        public virtual DbSet<Conduct> Conducts { get; set; }
        public virtual DbSet<DayLesson> DayLessons { get; set; }
        public virtual DbSet<ErrorMessage> ErrorMsgs { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<SchoolInfomation> SchoolInfomations { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<ScheduleSubject> ScheduleSubjects { get; set; }
        public virtual DbSet<Scholastic> Scholastics { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentTranscript> StudentTranscripts { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectMark> SubjectMarks { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TypeMark> TypeMarks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Class>()
                .HasMany(e => e.Notifications)
                .WithOptional(e => e.Class)
                .HasForeignKey(e => e.IdClassReceiver);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.ScheduleSubjects)
                .WithRequired(e => e.Class)
                .HasForeignKey(e => e.IdClass)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Class)
                .HasForeignKey(e => e.IdClass)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classification>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Classification)
                .HasForeignKey(e => e.IdClassification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classification>()
                .HasMany(e => e.StudentTranscripts)
                .WithRequired(e => e.Classification)
                .HasForeignKey(e => e.IdClassification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Conduct>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Conduct)
                .HasForeignKey(e => e.IdConduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Conduct>()
                .HasMany(e => e.StudentTranscripts)
                .WithRequired(e => e.Conduct)
                .HasForeignKey(e => e.IdConduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DayLesson>()
                .HasMany(e => e.ScheduleSubjects)
                .WithRequired(e => e.DayLesson)
                .HasForeignKey(e => e.IdDayLesson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Function>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Function)
                .HasForeignKey(e => e.IdFunction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grade>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Grade)
                .HasForeignKey(e => e.IdGrade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.IdGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.IdGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Parent>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Parent)
                .HasForeignKey(e => e.IdParent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Room)
                .HasForeignKey(e => e.IdRoom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Screen>()
                .HasMany(e => e.Functions)
                .WithRequired(e => e.Screen)
                .HasForeignKey(e => e.IdScreen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Scholastic>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Scholastic)
                .HasForeignKey(e => e.IdScholastic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Scholastic>()
                .HasMany(e => e.Semesters)
                .WithRequired(e => e.Scholastic)
                .HasForeignKey(e => e.IdScholastic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semester>()
                .HasMany(e => e.StudentTranscripts)
                .WithRequired(e => e.Semester)
                .HasForeignKey(e => e.IdSemester)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semester>()
                .HasMany(e => e.SubjectMarks)
                .WithRequired(e => e.Semester)
                .HasForeignKey(e => e.IdSemester)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.IdStudent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentTranscripts)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.IdStudent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.SubjectMarks)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.IdStudent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.ScheduleSubjects)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.IdSubject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.SubjectMarks)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.IdSubject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.IdTeacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.ScheduleSubjects)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.IdTeacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Subjects)
                .WithRequired(e => e.Team)
                .HasForeignKey(e => e.IdTeam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Teachers)
                .WithRequired(e => e.Team)
                .HasForeignKey(e => e.IdTeam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeMark>()
                .HasMany(e => e.SubjectMarks)
                .WithRequired(e => e.TypeMark)
                .HasForeignKey(e => e.IdTypeMark)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.NotificationSenders)
                .WithOptional(e => e.UserSender)
                .HasForeignKey(e => e.IdSender);

            modelBuilder.Entity<User>()
                .HasMany(e => e.NotificationReceivers)
                .WithOptional(e => e.UserReceiver)
                .HasForeignKey(e => e.IdReceiver);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Parents)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Teachers)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);
        }
    }
    public class DatabaseCreation : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Groups.Add(new Group
            {
                NameGroup = "Admin"
            });

            context.Groups.Add(new Group
            {
                NameGroup = "Developer",
            });

            context.Users.Add(new User
            {
                FirstName = "Tram",
                LastName = "Huynh",
                Avatar = "https://i.pinimg.com/originals/96/3f/1a/963f1ad51f6f388e78ddcc8bbff1999a.jpg",
                Gender = false,
                Birthday = new DateTime(1997,10,30),
                PhoneNumber = "0789456123",
                Address = "123 Nguyen Luong Bang",
                IdentificationNumber = "123456789",
            });

            context.Users.Add(new User
            {
                FirstName = "Man",
                LastName = "Nguyen Van",
                Address = "Test",
                Birthday = new DateTime(1997, 7, 21),
                Gender = true,
                Avatar =
                    "https://res.cloudinary.com/dw0yzvsvn/image/upload/v1537351431/Images/9b06a7b3-142b-429e-945a-37f6f026e823.jpg",
                PhoneNumber = "0966156153",
                IdentificationNumber = "201722516"
            });

            context.SaveChanges();

            context.Accounts.Add(new Account
            {
                UserName = "Admin",
                Password = GetMd5(GetSimpleMd5("Admin@123")),
                Token = "admin",
                IdUser = 1,
                IdGroup = 1
            });

            context.Accounts.Add(new Account
            {
                UserName = "Man",
                Password = GetMd5(GetSimpleMd5("password")),
                Token = "man",
                IdUser = 2,
                IdGroup = 2,
            });
        }
        private static string _secretKey = "SOASaoCungDuoc";

        /// <summary>
        /// Mã hóa MD5 của 1 chuỗi có thêm chuối khóa đầu và cuối.
        /// Author       :   TramHTD - 18/03/2019 - create
        /// </summary>
        /// <param name="str">
        /// Chuỗi cần mã hóa.
        /// </param>
        /// <returns>
        /// Chuỗi sau khi đã được mã hóa.
        /// </returns>
        public static string GetMd5(string str)
        {
            str = $"{_secretKey}{str}{_secretKey}";
            var arrBytes = System.Text.Encoding.UTF8.GetBytes(str);
            var myMd5 = new MD5CryptoServiceProvider();
            arrBytes = myMd5.ComputeHash(arrBytes);
            return arrBytes.Aggregate("", (current, b) => current + b.ToString("x2"));
        }
        /// <summary>
        /// Mã hóa MD5 của 1 chuỗi không có thêm chuối khóa đầu và cuối.
        /// Author       :   TramHTD - 18/03/2019 - create
        /// </summary>
        /// <param name="str">
        /// Chuỗi cần mã hóa.
        /// </param>
        /// <returns>
        /// Chuỗi sau khi đã được mã hóa
        /// </returns>
        public static string GetSimpleMd5(string str)
        {
            var arrBytes = System.Text.Encoding.UTF8.GetBytes(str);
            var myMd5 = new MD5CryptoServiceProvider();
            arrBytes = myMd5.ComputeHash(arrBytes);
            return arrBytes.Aggregate("", (current, b) => current + b.ToString("x2"));
        }
        /// <summary>
        /// Get IdAccount đang login
        /// Author       :   TramHTD - 18/03/2019 - create
        /// </summary>
        /// <returns>
        /// IdAccount nếu tồn tại, trả về 0 nếu không tồn tại
        /// </returns>
        public static int GetIdAccount()
        {
            try
            {
                var cookieToken = HttpContext.Current.Request.Cookies["token"];
                if (cookieToken == null)
                {
                    return 0;
                }
                var base64EncodedBytes = System.Convert.FromBase64String(HttpUtility.UrlDecode(cookieToken.Value));
                var token = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                var context = new DataContext();
                var account = context.Accounts.FirstOrDefault(x => x.Token == token && !x.DelFlag);
                return account?.Id ?? 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
