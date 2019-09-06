using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LottoAPI.Models
{
    public class TicketDto
    {
        public int TicketId { get; set; }      

        public List<TicketLines> TicketLines { get; set; }
    }
}
