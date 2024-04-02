using System.ComponentModel.DataAnnotations;

namespace WebAPI_CodeFirst.Models
{
	public class Students
	{
		[Key]
		public int StudentId { get; set; }
		public string? Name { get; set; }
		//many-to-many relationship
		public ICollection<StudentCourses> StudentCourse {  get; set; }
	}
}

