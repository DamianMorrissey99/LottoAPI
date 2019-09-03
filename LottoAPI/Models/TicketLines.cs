using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LottoAPI.Models
{
    public class TicketLines
    {
        public int TicketLinesId { get; set; }
        public int TicketId { get; set; }
        [Required]
        public int Number1  { get; set; }
        [Required]
        public int Number2  { get; set; }
        [Required]
        public int Number3  { get; set; }
        [Required]
        public int Result  { get; set; }

    }
}
