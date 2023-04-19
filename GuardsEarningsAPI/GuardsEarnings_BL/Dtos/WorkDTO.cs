using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_BL.Dtos
{
    public class WorkDTO
    {
        public long WorkId { get; set; }
        public float QtyHours { get; set; }

        public long NewGuardId { get; set; }
        public long NewTargetId { get; set; }
        public long NewJourneyId { get; set; }
    }
}
