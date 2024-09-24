using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventorySerivce.Data;
using InventorySerivce.Models;

namespace InventorySerivce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkinsController : ControllerBase
    {
        private readonly InventorySerivceContext _context;

        public SkinsController(InventorySerivceContext context)
        {
            _context = context;
        }

        // GET: api/Skins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skin>>> GetSkin()
        {
            return await _context.Skin.ToListAsync();
        }

        // GET: api/Skins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skin>> GetSkin(int id)
        {
            var skin = await _context.Skin.FindAsync(id);

            if (skin == null)
            {
                return NotFound();
            }

            return skin;
        }

        // PUT: api/Skins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkin(int id, Skin skin)
        {
            if (id != skin.Id)
            {
                return BadRequest();
            }

            _context.Entry(skin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkinExists(id))
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

        // POST: api/Skins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skin>> PostSkin(Skin skin)
        {
            _context.Skin.Add(skin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkin", new { id = skin.Id }, skin);
        }

        // DELETE: api/Skins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkin(int id)
        {
            var skin = await _context.Skin.FindAsync(id);
            if (skin == null)
            {
                return NotFound();
            }

            _context.Skin.Remove(skin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkinExists(int id)
        {
            return _context.Skin.Any(e => e.Id == id);
        }
    }
}
