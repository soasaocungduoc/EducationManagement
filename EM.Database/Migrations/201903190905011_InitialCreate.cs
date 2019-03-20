namespace EM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
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
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Groups",
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
                .ForeignKey("dbo.Accounts", t => t.IdAccount)
                .Index(t => t.IdAccount);
            
            CreateTable(
                "dbo.Permissions",
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
                .ForeignKey("dbo.Functions", t => t.IdFunction)
                .ForeignKey("dbo.Groups", t => t.IdGroup)
                .Index(t => t.IdGroup)
                .Index(t => t.IdFunction);
            
            CreateTable(
                "dbo.Functions",
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
                .ForeignKey("dbo.Screens", t => t.IdScreen)
                .Index(t => t.IdScreen);
            
            CreateTable(
                "dbo.Screens",
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
                "dbo.Users",
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
                "dbo.Notifications",
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
                .ForeignKey("dbo.Users", t => t.IdReceiver)
                .ForeignKey("dbo.Users", t => t.IdSender)
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
                .ForeignKey("dbo.Grades", t => t.IdGrade)
                .ForeignKey("dbo.Rooms", t => t.IdRoom)
                .ForeignKey("dbo.Teachers", t => t.IdTeacher)
                .Index(t => t.IdGrade)
                .Index(t => t.IdRoom)
                .Index(t => t.IdTeacher);
            
            CreateTable(
                "dbo.Grades",
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
                "dbo.Rooms",
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
                "dbo.ScheduleSubjects",
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
                .ForeignKey("dbo.DayLessons", t => t.IdDayLesson)
                .ForeignKey("dbo.Subjects", t => t.IdSubject)
                .ForeignKey("dbo.Teachers", t => t.IdTeacher)
                .ForeignKey("dbo.Classes", t => t.IdClass)
                .Index(t => t.IdDayLesson)
                .Index(t => t.IdSubject)
                .Index(t => t.IdClass)
                .Index(t => t.IdTeacher);
            
            CreateTable(
                "dbo.DayLessons",
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
                "dbo.Subjects",
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
                .ForeignKey("dbo.Teams", t => t.IdTeam)
                .Index(t => t.IdTeam);
            
            CreateTable(
                "dbo.SubjectMarks",
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
                .ForeignKey("dbo.Students", t => t.IdStudent)
                .ForeignKey("dbo.Semesters", t => t.IdSemester)
                .ForeignKey("dbo.TypeMarks", t => t.IdTypeMark)
                .ForeignKey("dbo.Subjects", t => t.IdSubject)
                .Index(t => t.IdTypeMark)
                .Index(t => t.IdStudent)
                .Index(t => t.IdSubject)
                .Index(t => t.IdSemester);
            
            CreateTable(
                "dbo.Semesters",
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
                .ForeignKey("dbo.Scholastics", t => t.IdScholastic)
                .Index(t => t.IdScholastic);
            
            CreateTable(
                "dbo.Scholastics",
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
                "dbo.Results",
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
                .ForeignKey("dbo.Classifications", t => t.IdClassification)
                .ForeignKey("dbo.Conducts", t => t.IdConduct)
                .ForeignKey("dbo.Students", t => t.IdStudent)
                .ForeignKey("dbo.Scholastics", t => t.IdScholastic)
                .Index(t => t.IdStudent)
                .Index(t => t.IdClassification)
                .Index(t => t.IdConduct)
                .Index(t => t.IdScholastic);
            
            CreateTable(
                "dbo.Classifications",
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
                "dbo.StudentTranscripts",
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
                .ForeignKey("dbo.Conducts", t => t.IdConduct)
                .ForeignKey("dbo.Students", t => t.IdStudent)
                .ForeignKey("dbo.Classifications", t => t.IdClassification)
                .ForeignKey("dbo.Semesters", t => t.IdSemester)
                .Index(t => t.IdStudent)
                .Index(t => t.IdClassification)
                .Index(t => t.IdConduct)
                .Index(t => t.IdSemester);
            
            CreateTable(
                "dbo.Conducts",
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
                "dbo.Students",
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
                .ForeignKey("dbo.Parents", t => t.IdParent)
                .ForeignKey("dbo.Classes", t => t.IdClass)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser)
                .Index(t => t.IdClass)
                .Index(t => t.IdParent);
            
            CreateTable(
                "dbo.Parents",
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
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.TypeMarks",
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
                "dbo.Teams",
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
                "dbo.Teachers",
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
                .ForeignKey("dbo.Teams", t => t.IdTeam)
                .ForeignKey("dbo.Users", t => t.IdUser)
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
                "dbo.ErrorMsgs",
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
                "dbo.InforSchools",
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
                "dbo.Slides",
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
            DropForeignKey("dbo.Teachers", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Students", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Parents", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Notifications", "IdSender", "dbo.Users");
            DropForeignKey("dbo.Notifications", "IdReceiver", "dbo.Users");
            DropForeignKey("dbo.Students", "IdClass", "dbo.Classes");
            DropForeignKey("dbo.ScheduleSubjects", "IdClass", "dbo.Classes");
            DropForeignKey("dbo.Teachers", "IdTeam", "dbo.Teams");
            DropForeignKey("dbo.ScheduleSubjects", "IdTeacher", "dbo.Teachers");
            DropForeignKey("dbo.Classes", "IdTeacher", "dbo.Teachers");
            DropForeignKey("dbo.Subjects", "IdTeam", "dbo.Teams");
            DropForeignKey("dbo.SubjectMarks", "IdSubject", "dbo.Subjects");
            DropForeignKey("dbo.SubjectMarks", "IdTypeMark", "dbo.TypeMarks");
            DropForeignKey("dbo.SubjectMarks", "IdSemester", "dbo.Semesters");
            DropForeignKey("dbo.StudentTranscripts", "IdSemester", "dbo.Semesters");
            DropForeignKey("dbo.Semesters", "IdScholastic", "dbo.Scholastics");
            DropForeignKey("dbo.Results", "IdScholastic", "dbo.Scholastics");
            DropForeignKey("dbo.StudentTranscripts", "IdClassification", "dbo.Classifications");
            DropForeignKey("dbo.SubjectMarks", "IdStudent", "dbo.Students");
            DropForeignKey("dbo.StudentTranscripts", "IdStudent", "dbo.Students");
            DropForeignKey("dbo.Results", "IdStudent", "dbo.Students");
            DropForeignKey("dbo.Students", "IdParent", "dbo.Parents");
            DropForeignKey("dbo.StudentTranscripts", "IdConduct", "dbo.Conducts");
            DropForeignKey("dbo.Results", "IdConduct", "dbo.Conducts");
            DropForeignKey("dbo.Results", "IdClassification", "dbo.Classifications");
            DropForeignKey("dbo.ScheduleSubjects", "IdSubject", "dbo.Subjects");
            DropForeignKey("dbo.ScheduleSubjects", "IdDayLesson", "dbo.DayLessons");
            DropForeignKey("dbo.Classes", "IdRoom", "dbo.Rooms");
            DropForeignKey("dbo.Notifications", "IdClassReceiver", "dbo.Classes");
            DropForeignKey("dbo.Classes", "IdGrade", "dbo.Grades");
            DropForeignKey("dbo.Accounts", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Groups", "IdAccount", "dbo.Accounts");
            DropForeignKey("dbo.Permissions", "IdGroup", "dbo.Groups");
            DropForeignKey("dbo.Functions", "IdScreen", "dbo.Screens");
            DropForeignKey("dbo.Permissions", "IdFunction", "dbo.Functions");
            DropIndex("dbo.AuditEntryProperties", new[] { "AuditEntryID" });
            DropIndex("dbo.Teachers", new[] { "IdTeam" });
            DropIndex("dbo.Teachers", new[] { "IdUser" });
            DropIndex("dbo.Parents", new[] { "IdUser" });
            DropIndex("dbo.Students", new[] { "IdParent" });
            DropIndex("dbo.Students", new[] { "IdClass" });
            DropIndex("dbo.Students", new[] { "IdUser" });
            DropIndex("dbo.StudentTranscripts", new[] { "IdSemester" });
            DropIndex("dbo.StudentTranscripts", new[] { "IdConduct" });
            DropIndex("dbo.StudentTranscripts", new[] { "IdClassification" });
            DropIndex("dbo.StudentTranscripts", new[] { "IdStudent" });
            DropIndex("dbo.Results", new[] { "IdScholastic" });
            DropIndex("dbo.Results", new[] { "IdConduct" });
            DropIndex("dbo.Results", new[] { "IdClassification" });
            DropIndex("dbo.Results", new[] { "IdStudent" });
            DropIndex("dbo.Semesters", new[] { "IdScholastic" });
            DropIndex("dbo.SubjectMarks", new[] { "IdSemester" });
            DropIndex("dbo.SubjectMarks", new[] { "IdSubject" });
            DropIndex("dbo.SubjectMarks", new[] { "IdStudent" });
            DropIndex("dbo.SubjectMarks", new[] { "IdTypeMark" });
            DropIndex("dbo.Subjects", new[] { "IdTeam" });
            DropIndex("dbo.ScheduleSubjects", new[] { "IdTeacher" });
            DropIndex("dbo.ScheduleSubjects", new[] { "IdClass" });
            DropIndex("dbo.ScheduleSubjects", new[] { "IdSubject" });
            DropIndex("dbo.ScheduleSubjects", new[] { "IdDayLesson" });
            DropIndex("dbo.Classes", new[] { "IdTeacher" });
            DropIndex("dbo.Classes", new[] { "IdRoom" });
            DropIndex("dbo.Classes", new[] { "IdGrade" });
            DropIndex("dbo.Notifications", new[] { "IdClassReceiver" });
            DropIndex("dbo.Notifications", new[] { "IdReceiver" });
            DropIndex("dbo.Notifications", new[] { "IdSender" });
            DropIndex("dbo.Functions", new[] { "IdScreen" });
            DropIndex("dbo.Permissions", new[] { "IdFunction" });
            DropIndex("dbo.Permissions", new[] { "IdGroup" });
            DropIndex("dbo.Groups", new[] { "IdAccount" });
            DropIndex("dbo.Accounts", new[] { "IdUser" });
            DropTable("dbo.Slides");
            DropTable("dbo.News");
            DropTable("dbo.InforSchools");
            DropTable("dbo.ErrorMsgs");
            DropTable("dbo.AuditEntryProperties");
            DropTable("dbo.AuditEntries");
            DropTable("dbo.Teachers");
            DropTable("dbo.Teams");
            DropTable("dbo.TypeMarks");
            DropTable("dbo.Parents");
            DropTable("dbo.Students");
            DropTable("dbo.Conducts");
            DropTable("dbo.StudentTranscripts");
            DropTable("dbo.Classifications");
            DropTable("dbo.Results");
            DropTable("dbo.Scholastics");
            DropTable("dbo.Semesters");
            DropTable("dbo.SubjectMarks");
            DropTable("dbo.Subjects");
            DropTable("dbo.DayLessons");
            DropTable("dbo.ScheduleSubjects");
            DropTable("dbo.Rooms");
            DropTable("dbo.Grades");
            DropTable("dbo.Classes");
            DropTable("dbo.Notifications");
            DropTable("dbo.Users");
            DropTable("dbo.Screens");
            DropTable("dbo.Functions");
            DropTable("dbo.Permissions");
            DropTable("dbo.Groups");
            DropTable("dbo.Accounts");
        }
    }
}
