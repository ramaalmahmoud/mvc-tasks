using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _18_9_2024.Models
{
    public class SchoolDBContext: DbContext
    {
        public SchoolDBContext():base("SchoolContext")
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }    
        public DbSet<Assignment> Assignment { get; set; }
    }
}