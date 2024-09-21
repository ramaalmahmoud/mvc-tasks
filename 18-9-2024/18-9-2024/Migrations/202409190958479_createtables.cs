namespace _18_9_2024.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Student", "ID", "dbo.StudentDetails");
            DropIndex("dbo.Course", new[] { "teacherID" });
            DropIndex("dbo.Student", new[] { "ID" });
            DropColumn("dbo.StudentDetails", "StudentID");
            RenameColumn(table: "dbo.StudentDetails", name: "ID", newName: "StudentId");
            DropPrimaryKey("dbo.StudentDetails");
            DropPrimaryKey("dbo.Student");
            AddColumn("dbo.Course", "CourseName", c => c.String());
            AddColumn("dbo.Course", "CourseDescription", c => c.String());
            AddColumn("dbo.StudentDetails", "Phone", c => c.String());
            AlterColumn("dbo.StudentDetails", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Student", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.StudentDetails", "StudentId");
            AddPrimaryKey("dbo.Student", "ID");
            CreateIndex("dbo.Course", "TeacherID");
            CreateIndex("dbo.StudentDetails", "StudentId");
            AddForeignKey("dbo.StudentDetails", "StudentId", "dbo.Student", "ID");
            DropColumn("dbo.Course", "Name");
            DropColumn("dbo.Course", "Description");
            DropColumn("dbo.StudentDetails", "fatherPhone");
            DropColumn("dbo.StudentDetails", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentDetails", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.StudentDetails", "fatherPhone", c => c.String());
            AddColumn("dbo.Course", "Description", c => c.String());
            AddColumn("dbo.Course", "Name", c => c.String());
            DropForeignKey("dbo.StudentDetails", "StudentId", "dbo.Student");
            DropIndex("dbo.StudentDetails", new[] { "StudentId" });
            DropIndex("dbo.Course", new[] { "TeacherID" });
            DropPrimaryKey("dbo.Student");
            DropPrimaryKey("dbo.StudentDetails");
            AlterColumn("dbo.Student", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentDetails", "StudentId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.StudentDetails", "Phone");
            DropColumn("dbo.Course", "CourseDescription");
            DropColumn("dbo.Course", "CourseName");
            AddPrimaryKey("dbo.Student", "ID");
            AddPrimaryKey("dbo.StudentDetails", "ID");
            RenameColumn(table: "dbo.StudentDetails", name: "StudentId", newName: "ID");
            AddColumn("dbo.StudentDetails", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Student", "ID");
            CreateIndex("dbo.Course", "teacherID");
            AddForeignKey("dbo.Student", "ID", "dbo.StudentDetails", "ID");
        }
    }
}
