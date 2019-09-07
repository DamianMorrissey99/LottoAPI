using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LottoAPI.Helpers;
using LottoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LottoAPI.Services
{
    public class TicketRepository : ITicketRepository
    {
        private readonly LottoAPIContext _appContext;

        public TicketRepository(LottoAPIContext appContext)
        {
            _appContext = appContext;
        }

        public void CreateTickets(int numberOfLines)
        {
             
                Ticket newTicket = new Ticket();
                List<TicketLines> newLines = new List<TicketLines>();

                for (int i = 0; i < numberOfLines; i++)
                {                
                    var newLine = CreateNewTicketLine();
                    newLines.Add(newLine);       
                }

                newTicket.TicketLines = newLines;

                var tickets =  _appContext.Tickets.Add(newTicket);
                _appContext.SaveChanges();
  
        }
    

        private TicketLines CreateNewTicketLine()
        {
            List<int> generatedNumbers = new List<int>();

            Random random = new Random();  
            
            // Generate randon number between 0 and 2
            for (int i = 0; i < 3; i++)
            {
                int num = random.Next(0,3);
                generatedNumbers.Add(num);
            }

            var lineResult = CalculateLineResult.GetResult(generatedNumbers);

            TicketLines newLine = new TicketLines();
            newLine.Number1 = generatedNumbers.ElementAt(0);
            newLine.Number2 = generatedNumbers.ElementAt(1);
            newLine.Number3 = generatedNumbers.ElementAt(2);
            newLine.Result = lineResult;

            return newLine;
        }

        public async Task<Ticket> GetTicketAsync(int ticketId)
        {  
            var ticket = await _appContext.Tickets.Include(y => y.TicketLines)
                                .Where(x => x.TicketId == ticketId)
                                .FirstOrDefaultAsync();

            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {  
            var result = await _appContext.Tickets.Include(y => y.TicketLines)
                                .ToListAsync()
                                .ConfigureAwait(true);
            return result;              
        }

        public async Task<IEnumerable<TicketLines>> GetTicketLineStatus(int ticketId)
        {
            var result = await _appContext.TicketLines.Where(y => y.TicketId == ticketId)
                                    .OrderBy(o => o.Result)
                                    .ToListAsync()
                                    .ConfigureAwait(false);

            // set the 'amended' status to true (should be 'status checked' not 'amended')         
            UpdateAmendStatusOfTicket(ticketId);

            return result;            
        }

        private void UpdateAmendStatusOfTicket(int ticketId)
        {
            var ticket = _appContext.Tickets.Where(x => x.TicketId == ticketId).FirstOrDefault();
            ticket.Amended = true;

            _appContext.Tickets.Update(ticket);
            _appContext.SaveChanges();
        }

        public Ticket AmendTicket(int id, int numberOfNewLines)
        {
            var existingTicket = _appContext.Tickets.Include(y => y.TicketLines).Where(x => x.TicketId == id).FirstOrDefault();

            List<TicketLines> newLines = new List<TicketLines>();

            for (int i = 0; i < numberOfNewLines; i++)
            {
                var newLine = CreateNewTicketLine();
                newLines.Add(newLine);                        
            }

            existingTicket.TicketLines.AddRange(newLines);

            _appContext.Tickets.Update(existingTicket);
            _appContext.SaveChanges();

            return existingTicket;

        }

        public bool TicketExists(int ticketId)
        {
            var ticket =  _appContext.Tickets.Where(x => x.TicketId == ticketId).FirstOrDefault();

            return ticket == null ? false : true;

        }

        public bool HasStatusBeenChecked(int ticketId)
        {
            var ticket = _appContext.Tickets.Where(x => x.TicketId == ticketId).FirstOrDefault();
     
            return ticket.Amended == false ? false : true;            
        }
    }
}
