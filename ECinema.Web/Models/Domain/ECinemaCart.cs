using ECinema.Web.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECinema.Web.Models.Domain
{
    public class ECinemaCart
    {
        public Guid id { get; set; }

        public string userId { get; set; }

        public ECinemaAppUser user { get; set; }

        public virtual ICollection<ECinemaTicketInCart> ticketsInCart { get; set; }
    }
}
