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
        private readonly SelectedTournamentsStore _selectedTournamentsStore;
        private AddTournamentViewModel _addTournamentViewModel;


        public AddTournamentCommand(AddTournamentViewModel addTournamentViewModel, TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore, NavigationStore navigationStore, SelectedTournamentsStore selectedTournamentsStore)
        {
            _addTournamentViewModel = addTournamentViewModel;
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;
            _navigationStore = navigationStore;
            _selectedTournamentsStore = selectedTournamentsStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            AddEditDetailsViewModel detailsViewModel = _addTournamentViewModel.AddEditDetailsViewModel;

            detailsViewModel.ErrorMessage = null;
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
                //_navigationStore.CurrentViewModel = new NavBarViewModel(_navigationStore, _selectedTournamentsStore, _modalNavigationStore,_tournamentStore);
                
            }
            catch (Exception)
            {
                detailsViewModel.ErrorMessage = "Daten konnten nicht gespeichert werden!";
            }
            finally
            {
                detailsViewModel.IsSubmitting = false;
            }
        }
    }
}
