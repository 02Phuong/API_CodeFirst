using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebAPI_CodeFirst.Data;
using WebAPI_CodeFirst.Models;

namespace WebAPI_CodeFirst.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class StudentController : Controller
	{
		private readonly StudentDbContext _context;

		public StudentController(StudentDbContext context)
		{
			_context = context;
		}

		// GET: api/Students
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Students>>> GetStudent()
		{
			return await _context.Student.ToListAsync();
		}

		// GET: api/Students/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Students>> GetStudent(int id)
		{
			var student = await _context.Student.FindAsync(id);

			if (student == null)
			{
				return NotFound();
			}

			return student;
		}

		// POST: api/Students
		[HttpPost]
		public async Task<ActionResult<Students>> PostStudent(Students students)
		{
			_context.Student.Add(students);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetStudent", new { id = students.StudentId }, students);
		}
		// PUT: api/Students/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutStudent(int id, Students student)
		{
			if (id != student.StudentId)
			{
				return BadRequest();
			}

			_context.Entry(student).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!StudentExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// DELETE: api/Students/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteStudent(int id)
		{
			var student = await _context.Student.FindAsync(id);
			if (student == null)
			{
				return NotFound();
			}

			_context.Student.Remove(student);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool StudentExists(int id)
		{
			return _context.Student.Any(e => e.StudentId == id);
		}
	}
}
