using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Models
{
    public class Target
    {
        public long TargetId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float Payment { get; set; }
        public string Direction { get; set; }
        public string? MapLocation { get; set; } 
        public byte[]? Image { get; set; }
        public string? Notes { get; set; }

        [JsonIgnore]
        public virtual ICollection<Work>? Works { get; set; }
    }
}
