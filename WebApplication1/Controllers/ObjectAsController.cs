using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectAsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ObjectAsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/ObjectAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjectA>>> GetA()
        {
            return await _context.A.Include(a => a.ObjectBs).ToListAsync();
        }

        // GET: api/ObjectAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectA>> GetObjectA(int id)
        {
            var objectA = await _context.A.Include(a => a.ObjectBs).FirstOrDefaultAsync(a => a.id == id);

            if (objectA == null)
            {
                return NotFound();
            }

            return objectA;
        }

        // PUT: api/ObjectAs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjectA(int id, ObjectA objectA)
        {
            if (id != objectA.id)
            {
                return BadRequest();
            }

            _context.Entry(objectA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectAExists(id))
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

        // POST: api/ObjectAs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ObjectA>> PostObjectA(ObjectA objectA)
        {
            _context.A.Add(objectA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjectA", new { id = objectA.id }, objectA);
        }

        // DELETE: api/ObjectAs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjectA(int id)
        {
            var objectA = await _context.A.FindAsync(id);
            if (objectA == null)
            {
                return NotFound();
            }

            _context.B.RemoveRange(objectA.ObjectBs);
            _context.A.Remove(objectA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjectAExists(int id)
        {
            return _context.A.Any(e => e.id == id);
        }
    }
}
