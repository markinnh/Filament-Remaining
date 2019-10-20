using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FilamentRemaining.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public Spool.PredefinedSpools PredefinedSpools { get; set; } = new Spool.PredefinedSpools();
        public string[] Names { get => PredefinedSpools.Definitions.Keys.ToArray(); }
        private string selectedPredefinedSpool="3D Solutech";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string SelectedPredefinedSpool
        {
            get => selectedPredefinedSpool;
            set
            {
                selectedPredefinedSpool = value;
                FilamentCalc.SpoolDefinition = PredefinedSpools.Definitions[value];
                OnPropertyChanged(nameof(FilamentCalc));
                OnPropertyChanged(nameof(SelectedPredefinedSpool));
            }
        }
        private decimal filamentRemaining;
        public decimal FilamentRemaining
        {
            get => filamentRemaining; 
            set
            {
                if (filamentRemaining != value)
                {
                    filamentRemaining = value;
                    OnPropertyChanged(nameof(FilamentRemaining));
                }
            }
        }

        public Spool.FilamentCalc FilamentCalc { get; set; }
        private ICommand doCalculate;
        public ICommand DoCalculate
        {
            get
            {
                if (doCalculate == null)
                    doCalculate = new RelayCommand(handleDoCalculate);
                return doCalculate;
            }
        }

        private void handleDoCalculate(object obj)
        {
            FilamentRemaining = (decimal)Math.Round(FilamentCalc.CalcRemaining(),3)/1000;
            //throw new NotImplementedException();
        }

        public MainWindowViewModel()
        {
            FilamentCalc = new Spool.FilamentCalc();
            FilamentCalc.ValueChanged += FilamentCalc_NotifyChanged;
            FilamentCalc.SpoolDefinition = PredefinedSpools.Definitions[selectedPredefinedSpool];
        }

        private void FilamentCalc_NotifyChanged(object sender, EventArgs e)
        {
            handleDoCalculate(null);
        }
    }
}
