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
    public class ObjectBsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ObjectBsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/ObjectBs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjectB>>> GetB()
        {
            return await _context.B.ToListAsync();
        }

        // GET: api/ObjectBs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectB>> GetObjectB(int id)
        {
            var objectB = await _context.B.FindAsync(id);

            if (objectB == null)
            {
                return NotFound();
            }

            return objectB;
        }

        // PUT: api/ObjectBs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjectB(int id, ObjectB objectB)
        {
            if (id != objectB.Id)
            {
                return BadRequest();
            }

            _context.Entry(objectB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectBExists(id))
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

        // POST: api/ObjectBs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ObjectB>> PostObjectB(ObjectB objectB)
        {
            _context.B.Add(objectB);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjectB", new { id = objectB.Id }, objectB);
        }

        // DELETE: api/ObjectBs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjectB(int id)
        {
            var objectB = await _context.B.FindAsync(id);
            if (objectB == null)
            {
                return NotFound();
            }

            _context.B.Remove(objectB);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjectBExists(int id)
        {
            return _context.B.Any(e => e.Id == id);
        }
    }
}
