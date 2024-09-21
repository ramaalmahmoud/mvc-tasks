namespace _19_9_2024.Migrations
{
    using _19_9_2024.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_19_9_2024.Models.SchoolDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_19_9_2024.Models.SchoolDBContext context)
        {
            context.Courses.AddOrUpdate(
             p => p.Name, // Use Name as the identifier to avoid duplicates
             new Course { Name = "Math", Description = "Math involves the study of numbers, equations, functions, and geometric shapes, teaching students critical problem-solving skills through concepts like algebra, calculus, and geometry." },
             new Course { Name = "English", Description = "English focuses on language and literature, including grammar, vocabulary, reading comprehension, and writing. It enhances communication skills and introduces students to diverse literary works." },
             new Course { Name = "Arabic", Description = "Arabic covers the study of the Arabic language, including grammar, reading, writing, and speaking. It also introduces classical and modern literature, enhancing understanding of Arab culture and history." });
        }
    }
}
