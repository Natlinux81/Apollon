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
        private readonly WarningDeleteViewModel _warningDeleteViewModel; 

        public DeleteTournamentCommand(WarningDeleteViewModel warningDeleteViewModel, OverviewListingItemViewModel overviewListingItemViewModel, TournamentsStore tournamentsStore, ModalNavigationStore modalNavigationStore)
        {
            _warningDeleteViewModel = warningDeleteViewModel;
            _overviewListingItemViewModel = overviewListingItemViewModel;
            _tournamentStore = tournamentsStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public OverviewListingItemViewModel OverviewListingItemViewModel { get; }
        public TournamentsStore TournamentsStore { get; }
        public ModalNavigationStore ModalNavigationStore { get; }
        public WarningDeleteViewModel WarningDeleteViewModel { get; }

        public override async Task ExecuteAsync(object parameter)
        {
            _warningDeleteViewModel.ErrorMessage = null;
            _warningDeleteViewModel.IsDeleting = true;
            
            Tournament tournament = _overviewListingItemViewModel.Tournament;

            try
            {
                await _tournamentStore.Delete(tournament.Id);

                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                _warningDeleteViewModel.ErrorMessage = "Speichern fehlgeschlagen!";
            }
            finally
            {
                _warningDeleteViewModel.IsDeleting = false;

            }
        }
    }
}
