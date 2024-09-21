using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _18_9_2024.Models
{
    public class StudentDetails
    {

        
        [Key,ForeignKey("Student")] 

        public int StudentId { get; set; }

        public string FatherName { get; set; }

        public string Phone { get; set; }

        // Navigation property back to Student
        public Student Student { get; set; }
    }
}
