using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECinema.Web.Models.Domain
{
    public class ECinemaMovie
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public string genre { get; set; }

        public int rating { get; set; }

    }
}
