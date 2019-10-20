using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilamentRemaining.Spool
{
    public class PredefinedSpools
    {
        public Dictionary<string, SpoolDefinition> Definitions { get; set; }
        public PredefinedSpools()
        {
            Definitions = new Dictionary<string, SpoolDefinition>()
            {
                {"3D Solutech",new SpoolDefinition(200,81,1.75m,55) },
                {"Hatchbox", new SpoolDefinition(200,80,1.75m,55) }
            };
        }
    }
}
