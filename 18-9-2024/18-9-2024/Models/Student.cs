using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _18_9_2024.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Class { get; set; }

        // Navigation property to StudentDetails
        public StudentDetails Detail { get; set; }
    }
}
