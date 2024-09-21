namespace _18_9_2024.Migrations
{
    using _18_9_2024.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_18_9_2024.Models.SchoolDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_18_9_2024.Models.SchoolDBContext context)
        {
            context.Students.AddOrUpdate(
            p => p.Name, // Use Name as the identifier to avoid duplicates
            new Student { Name = "Product A",Class = "Math" },
            new Student { Name = "Product B", Class = "20.0M" },
            new Student { Name = "Product C", Class = "30.0M" }
        );

        }
    }
}
