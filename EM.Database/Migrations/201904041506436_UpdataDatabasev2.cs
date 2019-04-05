namespace EM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataDatabasev2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "UserName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Account", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Function", "ControllerName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Function", "ActionName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.User", "Avatar", c => c.String(nullable: false));
            AlterColumn("dbo.Subject", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Semester", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ErrorMessage", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.News", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.SchoolInformation", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.SchoolInformation", "WebsiteUrl", c => c.String(nullable: false));
            AlterColumn("dbo.SchoolInformation", "Fax", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Slide", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Slide", "Path", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Slide", "Path", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Slide", "ImageUrl", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.SchoolInformation", "Fax", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.SchoolInformation", "WebsiteUrl", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.SchoolInformation", "Email", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.News", "ImageUrl", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.ErrorMessage", "Message", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Semester", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Subject", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.User", "Avatar", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Function", "ActionName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Function", "ControllerName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Account", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Account", "UserName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
