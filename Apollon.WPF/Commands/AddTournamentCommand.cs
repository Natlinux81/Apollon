using Apollon.Domain.Models;
using Apollon.WPF.Services;
using Apollon.WPF.Stores;
using Apollon.WPF.ViewModels;
using System;
using System.Threading.Tasks;

namespace Apollon.WPF.Commands
{
    public class AddTournamentCommand : AsyncCommandBase
    {
        private readonly TournamentsStore _tournamentStore;        
        private readonly ModalNavigationStore _modalNavigationStore;       
        private AddTournamentViewModel _addTournamentViewModel;
        


        public AddTournamentCommand(AddTournamentViewModel addTournamentViewModel, TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore)
        {
            _addTournamentViewModel = addTournamentViewModel;
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;            
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
                detailsViewModel.Groups,
                detailsViewModel.Targets);

            try
            {
                await _tournamentStore.Add(tournament);

                _modalNavigationStore.Close();                
                
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
