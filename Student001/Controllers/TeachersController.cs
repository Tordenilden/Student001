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
    public class TeachersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TeachersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Teachers
        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetTeacher()
        {
            // henter alle teachers
            var query = _context.Teacher.ToList();
            List<Teacher> query23 = _context.Teacher.ToList();

            // kan vi request teachercourse ?
            var query1 = _context.Teacher
                .Include(teacher => teacher.TeacherCourse)
                .ThenInclude(tc => tc.course).ToList();
            var query2 = _context.Teacher
               .Include(teacher => teacher.TeacherCourse).ToList();



            // hvorfor det ? lidt senere

            return query2;
            //db.Categories.Where(c => c.Id == categoryId).SelectMany(c => c.Articles)?
            
            //var query = _context.TeacherCourse.Where(tc=>tc.teacherId==1).SelectMany(c=>c.course)).
            //return await _context.Teacher.ToListAsync();
        }

        /*postman data tilbage
         *  {
        "teacherId": 1,
        "firstname": "Polle",
        "surname": "ibsen",
        "address": "smølfevej 55",
        "teacherCourse": null    --- det er fordi der mangler et join at de ikke er fyldt ud!!
    },
         
             */

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        { // burde altid lave en try-catch-finally måske
            Teacher teacher = null;
            var exists = await _context.Teacher.FindAsync(id);
            if (exists != null)
            {
                teacher = await _context.Teacher.Where(teacher => teacher.teacherId == id)
               .Include(teacher => teacher.TeacherCourse)
               .ThenInclude(tc => tc.course).SingleOrDefaultAsync(); // mærkeligt den ikke kan se course
            }
            else { return NotFound(); }

            return teacher; // Ok() bliver kaldt automatisk
        }
        //var q = await _context.Teacher.Where(t => t.teacherId == 1).SelectMany(a => a.TeacherCourse).Select(tc => tc.course).ToListAsync();
        //var t = await _context.Teacher.Where(t => t.teacherId == 1).SelectMany(a => a.TeacherCourse).Select(tc => tc.course).ToListAsync();
        // PUT: api/Teachers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")] // opdater en teacher
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.teacherId)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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

        // POST: api/Teachers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            _context.Teacher.Add(teacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher", new { id = teacher.teacherId }, teacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teacher.Remove(teacher);
            await _context.SaveChangesAsync();

            return teacher;
        }

        private bool TeacherExists(int id)
        {
            return _context.Teacher.Any(e => e.teacherId == id);
        }
    }
}
