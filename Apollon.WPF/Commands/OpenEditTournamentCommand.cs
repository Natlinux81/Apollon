using Apollon.Domain.Models;
using Apollon.WPF.Stores;
using Apollon.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Commands
{
    public class OpenEditTournamentCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;        
        private readonly OverviewListingItemViewModel _overviewListingItemViewModel;
        private readonly TournamentsStore _tournamentStore;

        public OpenEditTournamentCommand(OverviewListingItemViewModel overviewListingItemViewModel, TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore)
        {
            _overviewListingItemViewModel = overviewListingItemViewModel;
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            Tournament tournament = _overviewListingItemViewModel.Tournament;

            EditTournamentViewModel editTournamentViewModel = new EditTournamentViewModel(_modalNavigationStore, _tournamentStore, tournament);
            _modalNavigationStore.CurrentViewModel = editTournamentViewModel;
        }
    }
}
