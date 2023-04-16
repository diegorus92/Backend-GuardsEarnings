using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_BL.Dtos
{
    public class GuardDTO
    {
        public long GuardId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string? Cellphone { get; set; }
        public string Direction { get; set; }
    }
}
