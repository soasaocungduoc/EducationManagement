namespace EM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateConductClassificationTypeMarksDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ScheduleSubject", "SemesterId", "dbo.Semester");
            DropIndex("dbo.ScheduleSubject", new[] { "SemesterId" });
            DropColumn("dbo.ScheduleSubject", "SemesterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScheduleSubject", "SemesterId", c => c.Int(nullable: false));
            CreateIndex("dbo.ScheduleSubject", "SemesterId");
            AddForeignKey("dbo.ScheduleSubject", "SemesterId", "dbo.Semester", "Id");
        }
    }
}
