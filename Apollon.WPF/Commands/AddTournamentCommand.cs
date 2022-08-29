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
    public class AddTournamentCommand : AsyncCommandBase
    {
        private readonly TournamentsStore _tournamentStore;
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private AddTournamentViewModel _addTournamentViewModel;

        public AddTournamentCommand(AddTournamentViewModel addTournamentViewModel, TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore, NavigationStore navigationStore)
        {
            _addTournamentViewModel = addTournamentViewModel;
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;
            _navigationStore = navigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            AddEditDetailsViewModel detailsViewModel = _addTournamentViewModel.AddEditDetailsViewModel;

            detailsViewModel.IsSubmitting = true;

            Tournament tournament = new Tournament(
                Guid.NewGuid(),
                detailsViewModel.Organisation,
                detailsViewModel.TournamentName,
                detailsViewModel.Competition,
                detailsViewModel.CompetitionImage,
                detailsViewModel.StartDate,
                detailsViewModel.EndDate,
                detailsViewModel.Location,
                detailsViewModel.Rounds);

            try
            {
                await _tournamentStore.Add(tournament);

                _modalNavigationStore.Close();
                _navigationStore.CurrentViewModel = new NavBarViewModel(_navigationStore);
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                detailsViewModel.IsSubmitting = false;
            }
        }
    }
}
