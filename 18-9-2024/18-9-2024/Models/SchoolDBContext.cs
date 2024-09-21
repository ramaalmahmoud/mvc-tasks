using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _18_9_2024.Models
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext() : base("SchoolContext")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Assignment> Assignment { get; set; }

        public DbSet<StudentDetails> StudentDetails { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
             .HasOptional(s => s.Detail)
            .WithRequired(sd => sd.Student);

            modelBuilder.Entity<Teacher>()
            .HasMany(t => t.Courses)
            .WithRequired(c => c.Teacher)
            .HasForeignKey(c => c.TeacherID);
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Assignment>().ToTable("Assignment");
            modelBuilder.Entity<StudentDetails>().ToTable("StudentDetails");
            modelBuilder.Entity<Course>().ToTable("Course");
        }

    }
}