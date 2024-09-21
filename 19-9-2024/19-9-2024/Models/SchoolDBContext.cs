using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace _19_9_2024.Models
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext() : base("SchoolDBConnectionString")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }

}