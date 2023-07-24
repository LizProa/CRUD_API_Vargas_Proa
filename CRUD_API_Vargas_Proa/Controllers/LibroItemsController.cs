using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD_API_Vargas_Proa.Models;

namespace CRUD_API_Vargas_Proa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroItemsController : ControllerBase
    {
        private readonly LibroContext _context;

        public LibroItemsController(LibroContext context)
        {
            _context = context;
        }

        // GET: api/LibroItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroItem>>> GetLibroItems()
        {
          if (_context.LibroItems == null)
          {
              return NotFound();
          }
            return await _context.LibroItems.ToListAsync();
        }

        // GET: api/LibroItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroItem>> GetLibroItem(int id)
        {
          if (_context.LibroItems == null)
          {
              return NotFound();
          }
            var libroItem = await _context.LibroItems.FindAsync(id);

            if (libroItem == null)
            {
                return NotFound();
            }

            return libroItem;
        }

        // PUT: api/LibroItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibroItem(int id, LibroItem libroItem)
        {
            if (id != libroItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(libroItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroItemExists(id))
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

        // POST: api/LibroItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LibroItem>> PostLibroItem(LibroItem libroItem)
        {
          if (_context.LibroItems == null)
          {
              return Problem("Entity set 'LibroContext.LibroItems'  is null.");
          }
            _context.LibroItems.Add(libroItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLibroItem), new { id = libroItem.Id }, libroItem);
        }

        // DELETE: api/LibroItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibroItem(int id)
        {
            if (_context.LibroItems == null)
            {
                return NotFound();
            }
            var libroItem = await _context.LibroItems.FindAsync(id);
            if (libroItem == null)
            {
                return NotFound();
            }

            _context.LibroItems.Remove(libroItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroItemExists(int id)
        {
            return (_context.LibroItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
