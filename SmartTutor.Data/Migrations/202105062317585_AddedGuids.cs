namespace SmartTutor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuids : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Subject", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Tutor", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tutor", "OwnerId");
            DropColumn("dbo.Subject", "OwnerId");
            DropColumn("dbo.Student", "OwnerId");
        }
    }
}
