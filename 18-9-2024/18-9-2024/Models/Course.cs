using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _18_9_2024.Models
{
    public class Course
    {
        public int ID { get; set; }

        public string CourseName { get; set; }
        public string CourseDescription { get;
            set;
        }
        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

    }
}