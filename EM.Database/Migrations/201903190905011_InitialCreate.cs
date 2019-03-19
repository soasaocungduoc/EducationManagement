namespace EM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Token = c.String(nullable: false, maxLength: 100),
                        IdUser = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NameGroup = c.String(nullable: false, maxLength: 50),
                        IdAccount = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.IdAccount)
                .Index(t => t.IdAccount);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdGroup = c.Int(nullable: false),
                        IdFunction = c.Int(nullable: false),
                        IdEnable = c.Boolean(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Function", t => t.IdFunction)
                .ForeignKey("dbo.Group", t => t.IdGroup)
                .Index(t => t.IdGroup)
                .Index(t => t.IdFunction);
            
            CreateTable(
                "dbo.Function",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdScreen = c.Int(nullable: false),
                        NameFunction = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                        Area = c.String(nullable: false, maxLength: 50),
                        NameController = c.String(nullable: false, maxLength: 50),
                        NameAction = c.String(nullable: false, maxLength: 50),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Screen", t => t.IdScreen)
                .Index(t => t.IdScreen);
            
            CreateTable(
                "dbo.Screen",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NameScreen = c.String(nullable: false, maxLength: 50),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Avatar = c.String(nullable: false, maxLength: 255),
                        Gender = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                        Address = c.String(nullable: false, maxLength: 200),
                        IdentityCard = c.String(nullable: false, maxLength: 12),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false),
                        Type = c.String(nullable: false, maxLength: 30),
                        IdSender = c.Int(),
                        IdReceiver = c.Int(),
                        IdClassReceiver = c.Int(),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.IdClassReceiver)
                .ForeignKey("dbo.User", t => t.IdReceiver)
                .ForeignKey("dbo.User", t => t.IdSender)
                .Index(t => t.IdSender)
                .Index(t => t.IdReceiver)
                .Index(t => t.IdClassReceiver);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NameClass = c.String(nullable: false, maxLength: 50),
                        NumberStudent = c.Int(nullable: false),
                        IdGrade = c.Int(nullable: false),
                        IdRoom = c.Int(nullable: false),
                        IdTeacher = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grade", t => t.IdGrade)
                .ForeignKey("dbo.Room", t => t.IdRoom)
                .ForeignKey("dbo.Teacher", t => t.IdTeacher)
                .Index(t => t.IdGrade)
                .Index(t => t.IdRoom)
                .Index(t => t.IdTeacher);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NameGrade = c.String(nullable: false, maxLength: 50),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NumberRoom = c.String(nullable: false, maxLength: 50),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScheduleSubject",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdDayLesson = c.Int(nullable: false),
                        IdSubject = c.Int(nullable: false),
                        IdClass = c.Int(nullable: false),
                        IdTeacher = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DayLesson", t => t.IdDayLesson)
                .ForeignKey("dbo.Subject", t => t.IdSubject)
                .ForeignKey("dbo.Teacher", t => t.IdTeacher)
                .ForeignKey("dbo.Classes", t => t.IdClass)
                .Index(t => t.IdDayLesson)
                .Index(t => t.IdSubject)
                .Index(t => t.IdClass)
                .Index(t => t.IdTeacher);
            
            CreateTable(
                "dbo.DayLesson",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Lesson = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NameSubject = c.String(nullable: false, maxLength: 50),
                        IdTeam = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Team", t => t.IdTeam)
                .Index(t => t.IdTeam);
            
            CreateTable(
                "dbo.SubjectMark",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Mark = c.Double(nullable: false),
                        IdTypeMark = c.Int(nullable: false),
                        IdStudent = c.Int(nullable: false),
                        IdSubject = c.Int(nullable: false),
                        IdSemester = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.IdStudent)
                .ForeignKey("dbo.Semester", t => t.IdSemester)
                .ForeignKey("dbo.TypeMark", t => t.IdTypeMark)
                .ForeignKey("dbo.Subject", t => t.IdSubject)
                .Index(t => t.IdTypeMark)
                .Index(t => t.IdStudent)
                .Index(t => t.IdSubject)
                .Index(t => t.IdSemester);
            
            CreateTable(
                "dbo.Semester",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NameSemester = c.String(nullable: false, maxLength: 20),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        IdScholastic = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scholastic", t => t.IdScholastic)
                .Index(t => t.IdScholastic);
            
            CreateTable(
                "dbo.Scholastic",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StartYear = c.Int(nullable: false),
                        EndYear = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Result",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdStudent = c.Int(nullable: false),
                        IdClassification = c.Int(nullable: false),
                        IdConduct = c.Int(nullable: false),
                        GPA = c.Double(nullable: false),
                        IdScholastic = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classification", t => t.IdClassification)
                .ForeignKey("dbo.Conduct", t => t.IdConduct)
                .ForeignKey("dbo.Student", t => t.IdStudent)
                .ForeignKey("dbo.Scholastic", t => t.IdScholastic)
                .Index(t => t.IdStudent)
                .Index(t => t.IdClassification)
                .Index(t => t.IdConduct)
                .Index(t => t.IdScholastic);
            
            CreateTable(
                "dbo.Classification",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NameClassification = c.String(nullable: false, maxLength: 50),
                        FromGPA = c.Double(nullable: false),
                        ToGPA = c.Double(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentTranscript",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdStudent = c.Int(nullable: false),
                        IdClassification = c.Int(nullable: false),
                        IdConduct = c.Int(nullable: false),
                        GPA = c.Double(nullable: false),
                        IdSemester = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conduct", t => t.IdConduct)
                .ForeignKey("dbo.Student", t => t.IdStudent)
                .ForeignKey("dbo.Classification", t => t.IdClassification)
                .ForeignKey("dbo.Semester", t => t.IdSemester)
                .Index(t => t.IdStudent)
                .Index(t => t.IdClassification)
                .Index(t => t.IdConduct)
                .Index(t => t.IdSemester);
            
            CreateTable(
                "dbo.Conduct",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TypeConduct = c.String(nullable: false, maxLength: 50),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        IdClass = c.Int(nullable: false),
                        IdParent = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parent", t => t.IdParent)
                .ForeignKey("dbo.Classes", t => t.IdClass)
                .ForeignKey("dbo.User", t => t.IdUser)
                .Index(t => t.IdUser)
                .Index(t => t.IdClass)
                .Index(t => t.IdParent);
            
            CreateTable(
                "dbo.Parent",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.TypeMark",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NameTypeMark = c.String(nullable: false, maxLength: 50),
                        Factor = c.Double(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NameTeam = c.String(nullable: false, maxLength: 50),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        IdTeam = c.Int(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Team", t => t.IdTeam)
                .ForeignKey("dbo.User", t => t.IdUser)
                .Index(t => t.IdUser)
                .Index(t => t.IdTeam);
            
            CreateTable(
                "dbo.AuditEntries",
                c => new
                    {
                        AuditEntryID = c.Int(nullable: false, identity: true),
                        EntitySetName = c.String(maxLength: 255),
                        EntityTypeName = c.String(maxLength: 255),
                        State = c.Int(nullable: false),
                        StateName = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AuditEntryID);
            
            CreateTable(
                "dbo.AuditEntryProperties",
                c => new
                    {
                        AuditEntryPropertyID = c.Int(nullable: false, identity: true),
                        AuditEntryID = c.Int(nullable: false),
                        RelationName = c.String(maxLength: 255),
                        PropertyName = c.String(maxLength: 255),
                        OldValue = c.String(),
                        NewValue = c.String(),
                    })
                .PrimaryKey(t => t.AuditEntryPropertyID)
                .ForeignKey("dbo.AuditEntries", t => t.AuditEntryID, cascadeDelete: true)
                .Index(t => t.AuditEntryID);
            
            CreateTable(
                "dbo.ErrorMsg",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Msg = c.String(nullable: false, maxLength: 255),
                        Type = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InforSchool",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NameSchool = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 12),
                        Email = c.String(nullable: false, maxLength: 15),
                        IntroSchool = c.String(nullable: false),
                        LinkWebsite = c.String(nullable: false, maxLength: 255),
                        Fax = c.String(nullable: false, maxLength: 30),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        UrlImage = c.String(nullable: false, maxLength: 255),
                        Summary = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        UrlImage = c.String(nullable: false, maxLength: 255),
                        Path = c.String(nullable: false, maxLength: 255),
                        IsShow = c.Boolean(nullable: false),
                        Created_at = c.DateTime(),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(),
                        Updated_by = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditEntryProperties", "AuditEntryID", "dbo.AuditEntries");
            DropForeignKey("dbo.Teacher", "IdUser", "dbo.User");
            DropForeignKey("dbo.Student", "IdUser", "dbo.User");
            DropForeignKey("dbo.Parent", "IdUser", "dbo.User");
            DropForeignKey("dbo.Notification", "IdSender", "dbo.User");
            DropForeignKey("dbo.Notification", "IdReceiver", "dbo.User");
            DropForeignKey("dbo.Student", "IdClass", "dbo.Classes");
            DropForeignKey("dbo.ScheduleSubject", "IdClass", "dbo.Classes");
            DropForeignKey("dbo.Teacher", "IdTeam", "dbo.Team");
            DropForeignKey("dbo.ScheduleSubject", "IdTeacher", "dbo.Teacher");
            DropForeignKey("dbo.Classes", "IdTeacher", "dbo.Teacher");
            DropForeignKey("dbo.Subject", "IdTeam", "dbo.Team");
            DropForeignKey("dbo.SubjectMark", "IdSubject", "dbo.Subject");
            DropForeignKey("dbo.SubjectMark", "IdTypeMark", "dbo.TypeMark");
            DropForeignKey("dbo.SubjectMark", "IdSemester", "dbo.Semester");
            DropForeignKey("dbo.StudentTranscript", "IdSemester", "dbo.Semester");
            DropForeignKey("dbo.Semester", "IdScholastic", "dbo.Scholastic");
            DropForeignKey("dbo.Result", "IdScholastic", "dbo.Scholastic");
            DropForeignKey("dbo.StudentTranscript", "IdClassification", "dbo.Classification");
            DropForeignKey("dbo.SubjectMark", "IdStudent", "dbo.Student");
            DropForeignKey("dbo.StudentTranscript", "IdStudent", "dbo.Student");
            DropForeignKey("dbo.Result", "IdStudent", "dbo.Student");
            DropForeignKey("dbo.Student", "IdParent", "dbo.Parent");
            DropForeignKey("dbo.StudentTranscript", "IdConduct", "dbo.Conduct");
            DropForeignKey("dbo.Result", "IdConduct", "dbo.Conduct");
            DropForeignKey("dbo.Result", "IdClassification", "dbo.Classification");
            DropForeignKey("dbo.ScheduleSubject", "IdSubject", "dbo.Subject");
            DropForeignKey("dbo.ScheduleSubject", "IdDayLesson", "dbo.DayLesson");
            DropForeignKey("dbo.Classes", "IdRoom", "dbo.Room");
            DropForeignKey("dbo.Notification", "IdClassReceiver", "dbo.Classes");
            DropForeignKey("dbo.Classes", "IdGrade", "dbo.Grade");
            DropForeignKey("dbo.Account", "IdUser", "dbo.User");
            DropForeignKey("dbo.Group", "IdAccount", "dbo.Account");
            DropForeignKey("dbo.Permission", "IdGroup", "dbo.Group");
            DropForeignKey("dbo.Function", "IdScreen", "dbo.Screen");
            DropForeignKey("dbo.Permission", "IdFunction", "dbo.Function");
            DropIndex("dbo.AuditEntryProperties", new[] { "AuditEntryID" });
            DropIndex("dbo.Teacher", new[] { "IdTeam" });
            DropIndex("dbo.Teacher", new[] { "IdUser" });
            DropIndex("dbo.Parent", new[] { "IdUser" });
            DropIndex("dbo.Student", new[] { "IdParent" });
            DropIndex("dbo.Student", new[] { "IdClass" });
            DropIndex("dbo.Student", new[] { "IdUser" });
            DropIndex("dbo.StudentTranscript", new[] { "IdSemester" });
            DropIndex("dbo.StudentTranscript", new[] { "IdConduct" });
            DropIndex("dbo.StudentTranscript", new[] { "IdClassification" });
            DropIndex("dbo.StudentTranscript", new[] { "IdStudent" });
            DropIndex("dbo.Result", new[] { "IdScholastic" });
            DropIndex("dbo.Result", new[] { "IdConduct" });
            DropIndex("dbo.Result", new[] { "IdClassification" });
            DropIndex("dbo.Result", new[] { "IdStudent" });
            DropIndex("dbo.Semester", new[] { "IdScholastic" });
            DropIndex("dbo.SubjectMark", new[] { "IdSemester" });
            DropIndex("dbo.SubjectMark", new[] { "IdSubject" });
            DropIndex("dbo.SubjectMark", new[] { "IdStudent" });
            DropIndex("dbo.SubjectMark", new[] { "IdTypeMark" });
            DropIndex("dbo.Subject", new[] { "IdTeam" });
            DropIndex("dbo.ScheduleSubject", new[] { "IdTeacher" });
            DropIndex("dbo.ScheduleSubject", new[] { "IdClass" });
            DropIndex("dbo.ScheduleSubject", new[] { "IdSubject" });
            DropIndex("dbo.ScheduleSubject", new[] { "IdDayLesson" });
            DropIndex("dbo.Classes", new[] { "IdTeacher" });
            DropIndex("dbo.Classes", new[] { "IdRoom" });
            DropIndex("dbo.Classes", new[] { "IdGrade" });
            DropIndex("dbo.Notification", new[] { "IdClassReceiver" });
            DropIndex("dbo.Notification", new[] { "IdReceiver" });
            DropIndex("dbo.Notification", new[] { "IdSender" });
            DropIndex("dbo.Function", new[] { "IdScreen" });
            DropIndex("dbo.Permission", new[] { "IdFunction" });
            DropIndex("dbo.Permission", new[] { "IdGroup" });
            DropIndex("dbo.Group", new[] { "IdAccount" });
            DropIndex("dbo.Account", new[] { "IdUser" });
            DropTable("dbo.Slide");
            DropTable("dbo.News");
            DropTable("dbo.InforSchool");
            DropTable("dbo.ErrorMsg");
            DropTable("dbo.AuditEntryProperties");
            DropTable("dbo.AuditEntries");
            DropTable("dbo.Teacher");
            DropTable("dbo.Team");
            DropTable("dbo.TypeMark");
            DropTable("dbo.Parent");
            DropTable("dbo.Student");
            DropTable("dbo.Conduct");
            DropTable("dbo.StudentTranscript");
            DropTable("dbo.Classification");
            DropTable("dbo.Result");
            DropTable("dbo.Scholastic");
            DropTable("dbo.Semester");
            DropTable("dbo.SubjectMark");
            DropTable("dbo.Subject");
            DropTable("dbo.DayLesson");
            DropTable("dbo.ScheduleSubject");
            DropTable("dbo.Room");
            DropTable("dbo.Grade");
            DropTable("dbo.Classes");
            DropTable("dbo.Notification");
            DropTable("dbo.User");
            DropTable("dbo.Screen");
            DropTable("dbo.Function");
            DropTable("dbo.Permission");
            DropTable("dbo.Group");
            DropTable("dbo.Account");
        }
    }
}
