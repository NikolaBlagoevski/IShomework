using ECinema.Web.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECinema.Web.Models.Identity
{
    public class ECinemaAppUser : IdentityUser
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string address { get; set; }

        public virtual ECinemaCart userCart { get; set; }

    }
}
