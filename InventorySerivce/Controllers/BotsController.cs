using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventorySerivce.Data;
using InventorySerivce.Models;
using InventorySerivce.Services.EntityServices;

namespace InventorySerivce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotsController : ControllerBase
    {
        private readonly InventorySerivceContext _context;
        private readonly IBotService _botservice;

        public BotsController(InventorySerivceContext context, IBotService botService)
        {
            _context = context;
            _botservice = botService;
        }

        // GET: api/Bots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bot>>> GetBot()
        {
            return Ok(_botservice.GetAllBots());
        }

        // GET: api/Bots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bot>> GetBot(long id)
        {
            var bot = await _context.Bot.FindAsync(id);

            if (bot == null)
            {
                return NotFound();
            }

            return bot;
        }

        // PUT: api/Bots/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBot(long id, Bot bot)
        {
            if (id != bot.Id)
            {
                return BadRequest();
            }

            _context.Entry(bot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BotExists(id))
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

        // POST: api/Bots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bot>> PostBot(Bot bot)
        {
            _botservice.AddBot(bot);
            return Created("/api/bots/" + bot.Id, bot);
        }

        // DELETE: api/Bots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBot(long id)
        {
            var bot = await _context.Bot.FindAsync(id);
            if (bot == null)
            {
                return NotFound();
            }

            _context.Bot.Remove(bot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BotExists(long id)
        {
            return _context.Bot.Any(e => e.Id == id);
        }
    }
}
