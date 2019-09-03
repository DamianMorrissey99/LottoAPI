using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LottoAPI.Models;

namespace LottoAPI.Services
{
    public class TicketRepository : ITicketRepository
    {
        private readonly LottoAPIContext _appContext;

        public TicketRepository(LottoAPIContext appContext)
        {
            _appContext = appContext;
        }

        public Ticket CreateTickets(int numberOfLines)
        {
            Ticket newTicket = new Ticket();

            for (int i = 0; i < numberOfLines; i++)
            {
                var newLine = CreateNewTicketLine();
                newTicket.TicketLines.Add(newLine);
            }
           var tickets =  _appContext.Tickets.Add(newTicket);
           return (Ticket)tickets;
        }

        private TicketLines CreateNewTicketLine()
        {

        }

        public Ticket GetTicket(int ticketId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetTickets()
        {
            throw new NotImplementedException();
        }

        public int GetTicketStatus(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Ticket UpdateTicket(List<Ticket> tickets)
        {
            throw new NotImplementedException();
        }
    }
}
