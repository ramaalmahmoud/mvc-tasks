using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _19_9_2024.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Duedate { get; set; }
        [ForeignKey("Classes")]
        public int classId { get; set; }
        public Classes Classes { get; set; }

    }
}