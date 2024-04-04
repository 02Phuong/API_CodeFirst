using Microsoft.EntityFrameworkCore;
using System;
using WebAPI_CodeFirst.Models;
namespace WebAPI_CodeFirst.Data
{
	public class StudentDbContext : DbContext
	{
		public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
		{
		}
		public DbSet<Students> Student { get; set; }
		public DbSet<Courses> Course { get; set; }
		public DbSet<StudentCourses> StudentCourse { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Models.StudentCourses>().HasKey(h => new { h.StudentId, h.CourseId });

		}
	}

	public class DbInitializer
	{
		public static void Initialize(StudentDbContext context)
		{
			context.Database.EnsureCreated();

			// Add initial data here
			if (!context.Student.Any())
			{
				var students = new List<Students>
				{
					new Students { Name = "John Doe" },
					new Students { Name = "Jane Smith" }
                    // Add more students as needed
                };
				context.Student.AddRange(students);
				context.SaveChanges();
			}

			if (!context.Course.Any())
			{
				var courses = new List<Courses>
				{
					new Courses { CourseName = "Math", Description = "Mathematics course" },
					new Courses { CourseName = "Science", Description = "Science course" }
                    // Add more courses as needed
                };
				context.Course.AddRange(courses);
				context.SaveChanges();
			}

			// Add more initial data for other entities if needed
		}
	}

}

