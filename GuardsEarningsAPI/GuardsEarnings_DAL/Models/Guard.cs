using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Models
{
    public class Guard
    {
        public long GuardId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string? Cellphone { get; set; }
        public string Direction { get; set; }

        public virtual ICollection<Work>? Works { get; set; }
    }
}
