using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Models
{
    public class Work
    {
        public long WorkId { get; set; }
        public float QtyHours { get; set; }

        public  ICollection<Guard>? Guards { get; set; }
        public  ICollection<Target>? Targets { get; set; }
        public  ICollection<Journey>? Journeys { get; set; }
    }
}
