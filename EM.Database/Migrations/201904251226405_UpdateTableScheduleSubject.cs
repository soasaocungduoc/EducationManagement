namespace EM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableScheduleSubject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleSubject", "SemesterId", c => c.Int(nullable: false, defaultValue: 10));
            CreateIndex("dbo.ScheduleSubject", "SemesterId");
            AddForeignKey("dbo.ScheduleSubject", "SemesterId", "dbo.Semester", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleSubject", "SemesterId", "dbo.Semester");
            DropIndex("dbo.ScheduleSubject", new[] { "SemesterId" });
            DropColumn("dbo.ScheduleSubject", "SemesterId");
        }
    }
}
