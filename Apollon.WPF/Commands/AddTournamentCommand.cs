using Apollon.Domain.Models;
using Apollon.WPF.Services;
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
        private readonly NavigationService<PreparationViewModel> _navigationService;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SelectedTournamentsStore _selectedTournamentsStore;
        private AddTournamentViewModel _addTournamentViewModel;

        public AddTournamentCommand(AddTournamentViewModel addTournamentViewModel, NavigationService<PreparationViewModel> navigationService)
        {
        }

        public AddTournamentCommand(TournamentsStore tournamentStore, NavigationService<PreparationViewModel> navigationService, ModalNavigationStore modalNavigationStore,
                                    SelectedTournamentsStore selectedTournamentsStore, AddTournamentViewModel addTournamentViewModel)
        {
            _tournamentStore = tournamentStore;
            _navigationService = navigationService;
            _modalNavigationStore = modalNavigationStore;
            _selectedTournamentsStore = selectedTournamentsStore;
            _addTournamentViewModel = addTournamentViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            AddEditDetailsViewModel detailsViewModel = _addTournamentViewModel.AddEditDetailsViewModel;

            detailsViewModel.ErrorMessage = null;
            detailsViewModel.IsSubmitting = true;

            Tournament tournament = new Tournament(
                Guid.NewGuid(),
                detailsViewModel.Logo,
                detailsViewModel.Organisation,
                detailsViewModel.TournamentName,
                detailsViewModel.Competition,
                detailsViewModel.CompetitionImage,
                detailsViewModel.StartDate,
                detailsViewModel.EndDate,
                detailsViewModel.Location,
                detailsViewModel.Rounds,
                detailsViewModel.Targets);

            try
            {
                await _tournamentStore.Add(tournament);

                _modalNavigationStore.Close();
                _navigationService.Navigate();

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
