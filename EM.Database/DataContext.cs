using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Web;


namespace EM.Database
{

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }
        //public virtual DbSet<AuditEntry> Audit { set; get; }
        //public virtual DbSet<AuditEntryProperty> AuditProperty { set; get; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Classification> Classification { get; set; }
        public virtual DbSet<Conduct> Conduct { get; set; }
        public virtual DbSet<DayLesson> DayLesson { get; set; }
        public virtual DbSet<ErrorMsg> ErrorMsg { get; set; }
        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<InforSchool> InforSchool { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Screen> Screen { get; set; }
        public virtual DbSet<ScheduleSubject> ScheduleSubject { get; set; }
        public virtual DbSet<Scholastic> Scholastic { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentTranscript> StudentTranscript { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<SubjectMark> SubjectMark { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TypeMark> TypeMark { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Group)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.IdAccount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classes>()
                .HasMany(e => e.Notification)
                .WithOptional(e => e.Classes)
                .HasForeignKey(e => e.IdClassReceiver);

            modelBuilder.Entity<Classes>()
                .HasMany(e => e.ScheduleSubject)
                .WithRequired(e => e.Classes)
                .HasForeignKey(e => e.IdClass)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classes>()
                .HasMany(e => e.Student)
                .WithRequired(e => e.Classes)
                .HasForeignKey(e => e.IdClass)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classification>()
                .HasMany(e => e.Result)
                .WithRequired(e => e.Classification)
                .HasForeignKey(e => e.IdClassification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classification>()
                .HasMany(e => e.StudentTranscript)
                .WithRequired(e => e.Classification)
                .HasForeignKey(e => e.IdClassification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Conduct>()
                .HasMany(e => e.Result)
                .WithRequired(e => e.Conduct)
                .HasForeignKey(e => e.IdConduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Conduct>()
                .HasMany(e => e.StudentTranscript)
                .WithRequired(e => e.Conduct)
                .HasForeignKey(e => e.IdConduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DayLesson>()
                .HasMany(e => e.ScheduleSubject)
                .WithRequired(e => e.DayLesson)
                .HasForeignKey(e => e.IdDayLesson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Function>()
                .HasMany(e => e.Permission)
                .WithRequired(e => e.Function)
                .HasForeignKey(e => e.IdFunction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grade>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Grade)
                .HasForeignKey(e => e.IdGrade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Permission)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.IdGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Parent>()
                .HasMany(e => e.Student)
                .WithRequired(e => e.Parent)
                .HasForeignKey(e => e.IdParent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Room)
                .HasForeignKey(e => e.IdRoom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Screen>()
                .HasMany(e => e.Function)
                .WithRequired(e => e.Screen)
                .HasForeignKey(e => e.IdScreen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Scholastic>()
                .HasMany(e => e.Result)
                .WithRequired(e => e.Scholastic)
                .HasForeignKey(e => e.IdScholastic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Scholastic>()
                .HasMany(e => e.Semester)
                .WithRequired(e => e.Scholastic)
                .HasForeignKey(e => e.IdScholastic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semester>()
                .HasMany(e => e.StudentTranscript)
                .WithRequired(e => e.Semester)
                .HasForeignKey(e => e.IdSemester)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semester>()
                .HasMany(e => e.SubjectMark)
                .WithRequired(e => e.Semester)
                .HasForeignKey(e => e.IdSemester)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Result)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.IdStudent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentTranscript)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.IdStudent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.SubjectMark)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.IdStudent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.ScheduleSubject)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.IdSubject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.SubjectMark)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.IdSubject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.IdTeacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.ScheduleSubject)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.IdTeacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Subject)
                .WithRequired(e => e.Team)
                .HasForeignKey(e => e.IdTeam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Teacher)
                .WithRequired(e => e.Team)
                .HasForeignKey(e => e.IdTeam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeMark>()
                .HasMany(e => e.SubjectMark)
                .WithRequired(e => e.TypeMark)
                .HasForeignKey(e => e.IdTypeMark)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Account)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.NotificationSender)
                .WithOptional(e => e.UserSender)
                .HasForeignKey(e => e.IdSender);

            modelBuilder.Entity<User>()
                .HasMany(e => e.NotificationReceiver)
                .WithOptional(e => e.UserReceiver)
                .HasForeignKey(e => e.IdReceiver);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Parent)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Student)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Teacher)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);
        }
    }
}
