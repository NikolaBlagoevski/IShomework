using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECinema.Web.Models.Domain
{
    public class ECinemaTicket
    {

        public Guid id { get; set; }

        public int idMovie { get; set;  }

        public int priceOfTicket { get; set; }

        public DateTime dateValid { get; set; }


        public virtual ICollection<ECinemaTicketInCart> ticketsInCart { get; set; }

    }
}
