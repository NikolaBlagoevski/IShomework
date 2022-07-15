using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECinema.Web.Models.Domain
{
    public class ECinemaTicketInCart
    {
        public Guid ticketId { get; set; }

        public Guid cartId { get; set; }

        public ECinemaTicket ticket { get; set; }

        public ECinemaCart cart { get; set; }

        public int numberOfTickets { get; set; }

    }
}
