using Apollon.WPF.Commands;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class WarningDeleteViewModel : ViewModelBase
    {
        public ICommand WarningCloseCommand { get;}
        public ICommand DeleteCommand { get; }
        public WarningDeleteViewModel(ModalNavigationStore modalNavigationStore,TournamentsStore tournamentsStore, OverviewListingItemViewModel overviewListingItemViewModel)
        {
            WarningCloseCommand = new CloseModalCommand(modalNavigationStore);
            DeleteCommand = new DeleteTournamentCommand(overviewListingItemViewModel, tournamentsStore, modalNavigationStore);
        }
    }
}
