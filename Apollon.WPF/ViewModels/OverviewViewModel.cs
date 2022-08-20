using Apollon.WPF.Commands;
using Apollon.Domain.Models;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class OverviewViewModel : ViewModelBase
    {
        public OverviewListingViewModel OverviewListingViewModel { get; }
        public OverviewDetailsViewModel OverviewDetailsViewModel{ get; }

        public ICommand AddTournamentCommand { get; }  

        public OverviewViewModel(TournamentsStore tournamentStore, SelectedTournamentsStore selectedTournamentStore, ModalNavigationStore modalNavigationStore)
        {
            OverviewListingViewModel = OverviewListingViewModel.LoadViewModel(selectedTournamentStore, modalNavigationStore, tournamentStore);
            OverviewDetailsViewModel = new OverviewDetailsViewModel(selectedTournamentStore);

            AddTournamentCommand = new OpenAddTournamentCommand(tournamentStore, modalNavigationStore); 
        }
    }
}
