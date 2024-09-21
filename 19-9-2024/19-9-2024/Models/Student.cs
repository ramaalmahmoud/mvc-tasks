using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _19_9_2024.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        [ForeignKey("Classes")]
        public int ClassId { get; set; }

        public Classes Classes { get; set; }
    }
}