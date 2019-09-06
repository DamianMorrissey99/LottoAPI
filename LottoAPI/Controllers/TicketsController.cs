using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LottoAPI.Models;
using LottoAPI.Services;
using AutoMapper;

namespace LottoAPI.Controllers
{
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly LottoAPIContext _context;
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(LottoAPIContext appContext,  ITicketRepository ticketRepository)
        {
            _context = appContext;
            _ticketRepository = ticketRepository;
        }

        [HttpPost]
        public IActionResult CreateTicket(int numberOfLines)
        {
            //var tickets =_ticketRepository.CreateTickets(numberOfLines);
            _ticketRepository.CreateTicketsAsync(numberOfLines);
            //return new JsonResult(tickets);
           // return CreatedAtAction("Ticket Created",null);
            //return CreatedResult;
            return Ok();
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTicket", new { id = ticket.TicketId }, ticket);
         
        }

        // GET: api/Tickets
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            var ticketsFromRepo = await _ticketRepository.GetTicketsAsync();
            var tickets = Mapper.Map<IEnumerable<TicketDto>>(ticketsFromRepo);  

            return  Ok(tickets);
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticketFromRepo = await _ticketRepository.GetTicketAsync(id);

            if (ticketFromRepo == null)
            {
                return NotFound();
            }

            var ticket = Mapper.Map<TicketDto>(ticketFromRepo);

            return Ok(ticket);
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id,
                [FromBody] TicketForUpdateDto ticketForUpdate)
        {
            if (ticketForUpdate == null)
            {
                return BadRequest();
            }

            if (!_ticketRepository.TicketExists(id))
            {
                return NotFound();
            }

            _ticketRepository.UpdateTicket(ticketForUpdate, id);

            //if (id != ticket.TicketId)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        //[HttpPut("{id}")]
        //public async Task<IActionResult> GetStatusOfTicket(int id)
        //{
        //    var ticketFromRepo = await _ticketRepository.GetTicketLineStatus(id);

        //    if (ticketFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    var ticket = Mapper.Map<TicketLinesDto>(ticketFromRepo);

        //    //return new JsonResult(ticket);
        //    return Ok(ticket);
        //}

        // POST: api/Tickets
        //[HttpPost]
        //public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        //{
        //    _context.Tickets.Add(ticket);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTicket", new { id = ticket.TicketId }, ticket);
        //}

        //// DELETE: api/Tickets/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Ticket>> DeleteTicket(int id)
        //{
        //    var ticket = await _context.Tickets.FindAsync(id);
        //    if (ticket == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Tickets.Remove(ticket);
        //    await _context.SaveChangesAsync();

        //    return ticket;
        //}

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketId == id);
        }
    }
}
