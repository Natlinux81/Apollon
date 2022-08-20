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

        public DeleteTournamentCommand(OverviewListingItemViewModel overviewListingItemViewModel, TournamentsStore tournamentStore)
        {
            _overviewListingItemViewModel = overviewListingItemViewModel;
            _tournamentStore = tournamentStore;            
        }
        
        public override async Task ExecuteAsync(object parameter)
        {
            Tournament tournament = _overviewListingItemViewModel.Tournament;

            try
            {
                await _tournamentStore.Delete(tournament.Id);
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
