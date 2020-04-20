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
    public class ZipcodesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ZipcodesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Zipcodes
        [HttpGet]// hvilken metode er dette her??
        public async Task<ActionResult<IEnumerable<Zipcode>>> GetZipcode()
        {
            // vi prøver bare lige noget af!!!
            // henter alle zipcodes ud og ikke andet
            //var zipcodeList = await _context.Zipcode.Include(zipcode => zipcode.student)
            //    .Select(s => s.zipcode).ToListAsync();

            //var zipcodeList = await _context.Zipcode.Include(zipcode => zipcode.student)
            //.Select(s => s.city).ToListAsync();
            var zipcodeList = await _context.Zipcode.Include(zipcode => zipcode.student)
            .Where(ff => ff.zipcode == 4000).ToListAsync();

            return zipcodeList;

            //hvis I har 3 tabeller eller flere ser forespørgslerne lidt anderledes ud
            //var zipcodeList1 = await _context.tabela
            //    .Include(tabelb => tabelb.kolonne)   // ny primær tabel
            //    .Include(tabelc => tabelc.kolonne)   // ny primær tabel
            //    .Where(ff => ff.zipcode == 4000).ToListAsync();

            //var zipcodeList1 = await _context.tabela
            //    .Include(tabelb => tabelb.kolonne)   // ny primær tabel
            //    .ThenInclude(tabelc => tabelc.kolonne) // "under tabel" en tabel / List i en tabel
            //    .Where(ff => ff.zipcode == 4000).ToListAsync();



        }

        // GET: api/Zipcodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zipcode>> GetZipcode(int id)
        {
            var zipcode = await _context.Zipcode.FindAsync(id);

            if (zipcode == null)
            {
                return NotFound();
            }

            return zipcode;
        }

        // PUT: api/Zipcodes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZipcode(int id, Zipcode zipcode)
        {
            if (id != zipcode.zipcodeId)
            {
                return BadRequest();
            }

            _context.Entry(zipcode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZipcodeExists(id))
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

        // POST: api/Zipcodes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Zipcode>> PostZipcode(Zipcode zipcode)
        {
            _context.Zipcode.Add(zipcode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZipcode", new { id = zipcode.zipcodeId }, zipcode);
        }

        // DELETE: api/Zipcodes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Zipcode>> DeleteZipcode(int id)
        {
            var zipcode = await _context.Zipcode.FindAsync(id);
            if (zipcode == null)
            {
                return NotFound();
            }

            _context.Zipcode.Remove(zipcode);
            await _context.SaveChangesAsync();

            return zipcode;
        }

        private bool ZipcodeExists(int id)
        {
            return _context.Zipcode.Any(e => e.zipcodeId == id);
        }
    }
}
