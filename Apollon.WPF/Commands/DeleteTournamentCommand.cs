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
    public class DeleteTournamentCommand : AsyncCommandBase
    {        
        private readonly OverviewListingItemViewModel _overviewListingItemViewModel;
        private readonly TournamentsStore _tournamentStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public DeleteTournamentCommand(OverviewListingItemViewModel overviewListingItemViewModel, TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore)
        {
            _overviewListingItemViewModel = overviewListingItemViewModel;
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;
        }
        
        public override async Task ExecuteAsync(object parameter)
        {
            Tournament tournament = _overviewListingItemViewModel.Tournament;

            try
            {
                await _tournamentStore.Delete(tournament.Id);

                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
