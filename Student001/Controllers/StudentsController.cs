using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student001.Model;

namespace Student001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        #region start
        private readonly DatabaseContext _context;

        public StudentsController(DatabaseContext context)
        {
            _context = context;
        }
        //var gg = from collection
        //         where noget er givet
        //        select kolonner mm
        // Hvis vi ønsker at joine allerede her, for at få data ud om zipcode mm....
        // GET: api/Students

        #endregion start
        #region Get all
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudent()
        {
            var studentList = _context.Student.Include(student => student.Zipcode).ToList();
            return studentList;//    _context.Student.ToList();
        }
        #endregion Get all
        #region Get one student
        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            // enVariabel = databasen.TabellenStudent.FindIDSomER(id) // id er eks. 3
            var student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }
        #endregion Get one student
        #region update student
        // PUT: api/Students/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.studentId)
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

        // POST: api/Students
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        #endregion update student
        #region Post data for student
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.studentId }, student);
        }
        #endregion Post data for student
        #region delete student
        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }
        #endregion delete student











        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.studentId == id);
        }
    }
}
//// GET: api/Students/zipcode/4000
//[HttpGet("zipcode/{code}")]
//public async Task<ActionResult<List<Student>>> GetStudent(int code)
//{
//    var studentList = await _context.Student.Include(student => student.Zipcode).ThenInclude(z => z.zipcode == code).ToListAsync();
//    return studentList;
//}