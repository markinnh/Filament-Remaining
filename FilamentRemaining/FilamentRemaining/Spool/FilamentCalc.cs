using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilamentRemaining.Spool
{
    public class FilamentCalc
    {
        public event EventHandler ValueChanged;
        private decimal depth1 = 15;
        public decimal Depth1
        {
            get => depth1; 
            set
            {
                if (depth1 != value)
                {
                    depth1 = value;
                    OnValueChanged();
                }
            }
        }
        private decimal depth2 = 15;
        public decimal Depth2 { get=>depth2; 
            set {
                if (depth2 != value)
                {
                    depth2 = value ;
                    OnValueChanged();
                }
            } } 
        private decimal percentOffset = 94;
        public decimal PercentOffset
        {
            get => percentOffset; set
            {
                if (percentOffset != value)
                {
                    percentOffset = value;
                    OnValueChanged();
                }
            }
        }
        public SpoolDefinition SpoolDefinition { get; set; }
        private void OnValueChanged() => ValueChanged?.Invoke(this, EventArgs.Empty);
        internal decimal CalcRemaining()
        {
            //var lostSpool = 10;
            var percentUtilization = .95m;
            decimal length = 0.0m;
            decimal windAmount = (SpoolDefinition.SpoolWidth / SpoolDefinition.FilamentDiameter) * percentUtilization;
            var maxDiameter = SpoolDefinition.SpoolDiameter - (2 * ((Depth1 + Depth2) / 2));
            var curDiameter = SpoolDefinition.MinimumDiameter;
            var loop = 0;
            while (curDiameter < maxDiameter)
            {
                length += windAmount * (decimal)Math.PI * curDiameter;
                curDiameter += SpoolDefinition.FilamentDiameter * 2 * PercentOffset / 100;
                loop++;
            }
            Console.WriteLine($"Loop count : {loop}");
            return length;
            //throw new NotImplementedException();
        }
    }
}
