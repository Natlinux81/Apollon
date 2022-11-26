using Apollon.Domain.Models;
using Apollon.WPF.Commands;
using Apollon.WPF.Services;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class PreparationViewModel : ViewModelBase

    {
        public TournamentDetailsViewModel TournamentDetailsViewModel { get; }

        public ICommand NavigateOverviewCommand { get; }

        public PreparationViewModel(SelectedTournamentsStore selectedTournamentStore, NavigationStore navigationStore, ModalNavigationStore modalNavigationStore, TournamentsStore tournamentsStore)
        {
            TournamentDetailsViewModel = new TournamentDetailsViewModel(selectedTournamentStore);

            NavigateOverviewCommand = new NavigateCommand<OverviewViewModel>(new NavigationService<OverviewViewModel>(navigationStore, () => OverviewViewModel.LoadViewModel(selectedTournamentStore, modalNavigationStore, tournamentsStore, navigationStore)));
            
        }
        
    }
}
