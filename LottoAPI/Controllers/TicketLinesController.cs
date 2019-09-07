using LottoAPI.Models;
using LottoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LottoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketLinesController : ControllerBase
    {
        private readonly LottoAPIContext _context;
        private readonly ITicketRepository _ticketRepository;

        public TicketLinesController(LottoAPIContext context, ITicketRepository ticketRepository)
        {
            _context = context;
            _ticketRepository = ticketRepository;
        }



        //// GET: api/TicketLines
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TicketLines>>> GetTicketLines()
        //{
        //    return await _context.TicketLines.ToListAsync();
        //}

        //// GET: api/TicketLines/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TicketLines>> GetTicketLines(int id)
        //{
        //    var ticketLines = await _context.TicketLines.FindAsync(id);

        //    if (ticketLines == null)
        //    {
        //        return NotFound();
        //    }

        //    return ticketLines;
        //}

        //// PUT: api/TicketLines/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTicketLines(int id, TicketLines ticketLines)
        //{
        //    if (id != ticketLines.TicketLinesId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(ticketLines).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TicketLinesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/TicketLines
        //[HttpPost]
        //public async Task<ActionResult<TicketLines>> PostTicketLines(TicketLines ticketLines)
        //{
        //    _context.TicketLines.Add(ticketLines);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTicketLines", new { id = ticketLines.TicketLinesId }, ticketLines);
        //}

        //// DELETE: api/TicketLines/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<TicketLines>> DeleteTicketLines(int id)
        //{
        //    var ticketLines = await _context.TicketLines.FindAsync(id);
        //    if (ticketLines == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TicketLines.Remove(ticketLines);
        //    await _context.SaveChangesAsync();

        //    return ticketLines;
        //}

        private bool TicketLinesExists(int id)
        {
            return _context.TicketLines.Any(e => e.TicketLinesId == id);
        }
    }
}
