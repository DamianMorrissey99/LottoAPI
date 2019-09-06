using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LottoAPI.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        [Required]
        public bool Amended { get; set; }

        public List<TicketLines> TicketLines { get; set; }

        //public static implicit operator List<object>(Ticket v)
        //{
        //    throw new NotImplementedException();
        //}

        //public static explicit operator Ticket(EntityEntry<Ticket> v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
