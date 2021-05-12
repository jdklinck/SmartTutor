namespace SmartTutor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSetter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "FullName");
        }
    }
}
