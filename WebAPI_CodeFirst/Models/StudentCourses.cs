using System.ComponentModel.DataAnnotations;

namespace WebAPI_CodeFirst.Models
{
	public class StudentCourses
	{
		[Key]
		public int StudentId { get; set; }
		public Students Students { get; set; }
		[Key]
		public int CourseId { get; set; }
		public Courses Courses { get; set;}


	}
}
