namespace _18_9_2024.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToAssignment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignments", "Description", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Name", c => c.String());
            DropColumn("dbo.Assignments", "Description");
        }
    }
}
