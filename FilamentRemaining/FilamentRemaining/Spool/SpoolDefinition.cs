using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilamentRemaining.Spool
{
    public class SpoolDefinition
    {
        public decimal SpoolDiameter { get; set; }
        public decimal MinimumDiameter { get; set; }
        public decimal FilamentDiameter { get; set; }
        public decimal SpoolWidth { get; set; }
        public bool Verified { get; set; }
        //internal SpoolDefinition(decimal spoolDiameter, decimal mimumumDiameter, decimal filamentDiameter, decimal spoolWidth)
        //{
        //    SpoolDiameter = spoolDiameter;
        //    MinimumDiameter = mimumumDiameter;
        //    FilamentDiameter = filamentDiameter;
        //    SpoolWidth = spoolWidth;
        //    Verified = true;
        //}
        internal SpoolDefinition(decimal spoolDiameter,decimal minimumDiameter,decimal filamentDiameter,decimal spoolWidth,bool verified=true)
        {
            SpoolDiameter = spoolDiameter;
            MinimumDiameter = minimumDiameter;
            FilamentDiameter = filamentDiameter;
            SpoolWidth = spoolWidth;
            Verified = verified;
        }
    }
}
