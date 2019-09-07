using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LottoAPI.Models;
using LottoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LottoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly LottoAPIContext _context;
        private readonly ITicketRepository _ticketRepository;

        public StatusController(LottoAPIContext appContext, ITicketRepository ticketRepository)
        {
            _context = appContext;
            _ticketRepository = ticketRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> GetStatusOfTicket(int id)
        {
            var ticketFromRepo = await _ticketRepository.GetTicketLineStatus(id);

            if (ticketFromRepo == null)
            {
                return NotFound();
            }

            var ticket = Mapper.Map<IEnumerable<TicketLinesDto>>(ticketFromRepo);

            return Ok(ticket);
        }

        private void UpdateAmendStatussOfTicket(int ticketId)
        {
            var ticket = _context.Tickets.Where(x => x.TicketId == ticketId).FirstOrDefault();
            ticket.Amended = true;

        }
    }
}