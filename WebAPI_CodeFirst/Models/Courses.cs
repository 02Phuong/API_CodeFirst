using System.ComponentModel.DataAnnotations;

namespace WebAPI_CodeFirst.Models
{
	public class Courses
	{
		[Key]
		public int CourseId { get; set; }
		public string? CourseName { get; set; }
		public string? Description { get; set; }

		//many-to-many relationship
		public ICollection<StudentCourses> StudentCourse { get; set; }
	}
}

