using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_CodeFirst.Models;
using WebAPI_CodeFirst.Data;

namespace WebAPI_CodeFirst.Services
{
	public class StudentService : IStudentService
	{
			private readonly StudentDbContext _db;

			public StudentService(StudentDbContext db)
			{
				_db = db;
			}

			// Students Services

			public async Task<List<Students>> GetStudentsAsync()
			{
				try
				{
					return await _db.Student.ToListAsync();
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return null;
				}
			}

			public async Task<Students> GetStudentsAsync(Guid id)
			{
				try
				{
					return await _db.Student.FindAsync(id);
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return null;
				}
			}

			public async Task<Students> AddStudentsAsync(Students student)
			{
				try
				{
					await _db.Student.AddAsync(student);
					await _db.SaveChangesAsync();
					return student;
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return null;
				}
			}

			public async Task<Students> UpdateStudentsAsync(Students student)
			{
				try
				{
					_db.Entry(student).State = EntityState.Modified;
					await _db.SaveChangesAsync();
					return student;
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return null;
				}
			}

			public async Task<(bool, string)> DeleteStudentsAsync(Students student)
			{
				try
				{
					var existingStudent = await _db.Student.FindAsync(student.StudentId);
					if (existingStudent == null)
					{
						return (false, "Student not found.");
					}

					_db.Student.Remove(existingStudent);
					await _db.SaveChangesAsync();
					return (true, "Student deleted successfully.");
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return (false, $"An error occurred: {ex.Message}");
				}
			}

			// Courses Services

			public async Task<List<Courses>> GetCoursesAsync()
			{
				try
				{
					return await _db.Course.ToListAsync();
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return null;
				}
			}

			public async Task<Courses> GetCourseAsync(Guid id)
			{
				try
				{
					return await _db.Course.FindAsync(id);
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return null;
				}
			}

			public async Task<Courses> AddCourseAsync(Courses course)
			{
				try
				{
					await _db.Course.AddAsync(course);
					await _db.SaveChangesAsync();
					return course;
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return null;
				}
			}

			public async Task<Courses> UpdateCourseAsync(Courses course)
			{
				try
				{
					_db.Entry(course).State = EntityState.Modified;
					await _db.SaveChangesAsync();
					return course;
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return null;
				}
			}

			public async Task<(bool, string)> DeleteCourseAsync(Courses course)
			{
				try
				{
					var existingCourse = await _db.Course.FindAsync(course.CourseId);
					if (existingCourse == null)
					{
						return (false, "Course not found.");
					}

					_db.Course.Remove(existingCourse);
					await _db.SaveChangesAsync();
					return (true, "Course deleted successfully.");
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return (false, $"An error occurred: {ex.Message}");
				}
			}

			// StudentCourses Services

			public async Task<List<StudentCourses>> GetStudentCoursesAsync()
			{
				try
				{
					return await _db.StudentCourse.ToListAsync();
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return null;
				}
			}

			public async Task<StudentCourses> GetStudentCourseAsync(Guid studentId, Guid courseId)
			{
				try
				{
					return await _db.StudentCourse.FindAsync(studentId, courseId);
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return null;
				}
			}

			public async Task<StudentCourses> AddStudentCourseAsync(StudentCourses studentCourse)
			{
				try
				{
					await _db.StudentCourse.AddAsync(studentCourse);
					await _db.SaveChangesAsync();
					return studentCourse;
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return null;
				}
			}

			public async Task<StudentCourses> UpdateStudentCourseAsync(StudentCourses studentCourse)
			{
				try
				{
					_db.Entry(studentCourse).State = EntityState.Modified;
					await _db.SaveChangesAsync();
					return studentCourse;
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return null;
				}
			}

			public async Task<(bool, string)> DeleteStudentCourseAsync(StudentCourses studentCourse)
			{
				try
				{
					var existingStudentCourse = await _db.StudentCourse.FindAsync(studentCourse.StudentId, studentCourse.CourseId);
					if (existingStudentCourse == null)
					{
						return (false, "StudentCourse not found.");
					}

					_db.StudentCourse.Remove(existingStudentCourse);
					await _db.SaveChangesAsync();
					return (true, "StudentCourse deleted successfully.");
				}
				catch (Exception ex)
				{
					// Handle exception appropriately
					return (false, $"An error occurred: {ex.Message}");
				}
			}

			public Task<List<Students>> GetStudentssAsync()
			{
				throw new NotImplementedException();
			}

			public Task<List<StudentCourses>> GetStudentsCoursesAsync()
			{
				throw new NotImplementedException();
			}

			public Task<StudentCourses> GetStudentsCourseAsync(Guid studentId, Guid courseId)
			{
				throw new NotImplementedException();
			}

			Task<ActionResult<IEnumerable<Students>>> IStudentService.GetStudentsAsync()
			{
				throw new NotImplementedException();
			}
		}
	}

