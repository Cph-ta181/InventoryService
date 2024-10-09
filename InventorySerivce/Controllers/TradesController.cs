using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventorySerivce.Data;
using InventorySerivce.Models;
using InventorySerivce.Models.Dtos;
using InventorySerivce.Services.EntityServices;

namespace InventorySerivce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase
    {
        //private readonly InventorySerivceContext _context;
        private readonly ITradeService _tradeService;

        public TradesController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        // POST: api/Trades/Sell
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("sell")]
        public async Task<ActionResult<Trade>> SellTrade([FromBody] SellTradeDto sellTradeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_tradeService == null)
            {
                Console.WriteLine("Trade service = null");
            }
            await _tradeService.SellTrade(sellTradeDto);
            return CreatedAtAction("GetTrade", new object());
        }

        // GET: api/Trades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trade>>> GetTrade()
        {
            //return await _context.Trade.ToListAsync();
            return null;
        }

        // GET: api/Trades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trade>> GetTrade(int id)
        {
            /*var trade = await _context.Trade.FindAsync(id);

            if (trade == null)
            {
                return NotFound();
            }

            return trade;
            */
            return null;
        }

        // PUT: api/Trades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrade(int id, Trade trade)
        {
            /*if (id != trade.Id)
            {
                return BadRequest();
            }

            _context.Entry(trade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();*/
            return null;
        }

        // POST: api/Trades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trade>> PostTrade(Trade trade)
        {
            /*_context.Trade.Add(trade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrade", new { id = trade.Id }, trade);*/
            return null;
        }

        // DELETE: api/Trades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrade(int id)
        {
            /*var trade = await _context.Trade.FindAsync(id);
            if (trade == null)
            {
                return NotFound();
            }

            _context.Trade.Remove(trade);
            await _context.SaveChangesAsync();

            return NoContent();*/
            return null;
        }

        private bool TradeExists(int id)
        {
            //return _context.Trade.Any(e => e.Id == id);
            return false;
        }
    }
}
