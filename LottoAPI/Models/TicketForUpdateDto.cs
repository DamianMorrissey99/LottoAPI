using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LottoAPI.Models
{
    public class TicketForUpdateDto
    {
        public List<TicketLines> TicketLines { get; set; }
    }
}
