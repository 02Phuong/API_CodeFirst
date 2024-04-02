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
		public DbSet<Students> Student {  get; set; }
		public DbSet<Courses> Course { get; set; }
		public DbSet<StudentCourses> StudentCourse { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{

				builder.Entity<StudentCourses>()
					.HasKey(sc => new { sc.StudentId, sc.CourseId });

			builder.Entity<StudentCourses>()
				.HasOne(sc => sc.Students)
				.WithMany(s => s.StudentCourse)
				.HasForeignKey(sc => sc.StudentId);


			builder.Entity<StudentCourses>()
					.HasOne(sc => sc.Courses)
					.WithMany(c => c.StudentCourse)
					.HasForeignKey(sc => sc.CourseId);
		}
		}

}

