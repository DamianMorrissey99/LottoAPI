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
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {           
            _ticketRepository = ticketRepository;
        }

        [HttpPost]
        public IActionResult CreateTicket(int numberOfLines)
        {
            _ticketRepository.CreateTickets(numberOfLines);
            //return CreatedAtAction("Ticket Created",new Ticket());         
            return Ok();
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
        public IActionResult AmendTicket(int id, int numberOfNewLines)
        {
            if (!_ticketRepository.TicketExists(id))
            {
                return NotFound();
            }

            if (_ticketRepository.HasStatusBeenChecked(id))
            {
                return Content("This ticket cannot be amended - it's status has already been checked");
            }
            
            var amndedTicket =  _ticketRepository.AmendTicket(id, numberOfNewLines);          

            return NoContent();
        }

    }
}
