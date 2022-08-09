using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class ApollonOverviewListingItemViewModel : ViewModelBase
    {
        public string Tournamentname { get; }
        public ICommand DeleteCommand { get; }

        public ApollonOverviewListingItemViewModel(string tournamentname)
        {
            Tournamentname = tournamentname;            
        }
    }
}
