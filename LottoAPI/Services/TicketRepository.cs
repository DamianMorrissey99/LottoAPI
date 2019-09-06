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

        public async Task CreateTicketsAsync(int numberOfLines)
        {
            try
            {           
                Ticket newTicket = new Ticket();
                List<TicketLines> newLines = new List<TicketLines>();

                for (int i = 0; i < numberOfLines; i++)
                {                
                    var newLine = CreateNewTicketLine();
                    newLines.Add(newLine);
                    //newTicket.TicketLines.Add(newLine);            
                }

                newTicket.TicketLines = newLines;

                var tickets =  _appContext.Tickets.Add(newTicket);
                //await _appContext.SaveChangesAsync().ConfigureAwait(false);
                _appContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //  return (Ticket)tickets;
            // return tickets;
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
                                    .ConfigureAwait(true); 

            return result;
            
        }

        public Ticket UpdateTicket(TicketForUpdateDto ticket, int id)
        {
            return null;
        }

        public bool TicketExists(int ticketId)
        {
            var ticket =  _appContext.Tickets.Where(x => x.TicketId == ticketId).FirstOrDefault();

            return ticket == null ? false : true;


            //if (ticket == null)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }
    }
}
