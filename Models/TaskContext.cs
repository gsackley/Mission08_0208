
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mission08_0208.Models
{
    public class TaskContext : DbContext
    {
        // Constructor
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            // Leave blank for now
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Seeding the Data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );

            mb.Entity<Task>().HasData(
                new Task
                {
                    TaskId = 1,
                    TaskName = "Finish Applications",
                    DueDate = "03/08/2023",
                    Quadrant = 1,
                    CategoryId = 2,
                    Completed = false,

                },
                new Task
                {
                    TaskId = 2,
                    TaskName = "Call mom",
                    DueDate = "",
                    Quadrant = 4,
                    CategoryId = 1,
                    Completed = false,
                },
                new Task
                {
                    TaskId = 3,
                    TaskName = "Ask out Tiffany",
                    DueDate = "",
                    Quadrant = 2,
                    CategoryId = 1,
                    Completed = false,
                },
                new Task
                {
                    TaskId = 4,
                    TaskName = "Nicole gets dunked!",
                    DueDate = "04/01/2023",
                    Quadrant = 2,
                    CategoryId = 4,
                    Completed = false,
                }
            );
        }
    }
}
