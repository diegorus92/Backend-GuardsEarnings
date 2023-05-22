using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Models
{
    public class Work
    {
        public long WorkId { get; set; }
        public string EnterTime { get; set; } //hh:mm
        public string OutTime { get; set; } //hh:mm
        public float? Payment { get; set; }

        public  Guard? Guard { get; set; }
        public  Target? Target { get; set; }
        public  Journey? Journey { get; set; }
    }
}
