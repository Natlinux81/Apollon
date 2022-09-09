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
    public class NavBarViewModel : ViewModelBase

    {

        public ICommand NavigateOverviewCommand { get; }
        public NavBarViewModel(NavigationStore navigationStore, SelectedTournamentsStore selectedTournamentsStore, ModalNavigationStore modalNavigationStore, TournamentsStore tournamentsStore)
        {
            NavigateOverviewCommand = new NavigateCommand<OverviewViewModel>(navigationStore, () => new OverviewViewModel(tournamentsStore, selectedTournamentsStore, modalNavigationStore,navigationStore));
            
        }
    }
}
