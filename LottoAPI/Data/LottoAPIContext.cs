using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LottoAPI.Models
{
    public class LottoAPIContext : DbContext
    {
        public LottoAPIContext (DbContextOptions<LottoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<LottoAPI.Models.TicketLines> TicketLines { get; set; }
        public DbSet<LottoAPI.Models.Ticket> Tickets { get; set; }
    }
}
