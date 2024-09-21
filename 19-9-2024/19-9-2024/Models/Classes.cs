using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19_9_2024.Models
{
    public class Classes
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}