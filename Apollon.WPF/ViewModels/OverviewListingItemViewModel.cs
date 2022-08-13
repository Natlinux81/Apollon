using Apollon.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class OverviewListingItemViewModel : ViewModelBase
    {
        public Tournament Tournament { get;}        

        public string Tournamentname => Tournament.Tournamentname;
        public ICommand DeleteCommand { get; }
                
        public OverviewListingItemViewModel(Tournament tournament)
        {
            Tournament = tournament;
        }
    }
}
