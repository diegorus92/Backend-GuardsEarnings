using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Models
{
    public class Journey
    {
        public long JourneyId { get; set; } 
        public DateTime Date {  get; set; }

        public virtual ICollection<Work>? Works { get; set; }
    }
}
