using Apollon.WPF.Models;
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
        private readonly ModalNavigationStore _modalNavigationStore;
        private AddTournamentViewModel _addTournamentViewModel;
        

        public AddTournamentCommand(TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore)
        {
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public AddTournamentCommand(AddTournamentViewModel addTournamentViewModel, TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore)
        {
            _addTournamentViewModel = addTournamentViewModel;
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            AddEditDetailsViewModel detailsViewModel = _addTournamentViewModel.AddEditDetailsViewModel;
            Tournament tournament = new Tournament(
                Guid.NewGuid(),
                detailsViewModel.Organisation,
                detailsViewModel.TournamentName,
                detailsViewModel.Competition,
                detailsViewModel.StartDate,
                detailsViewModel.EndDate,
                detailsViewModel.Location,
                detailsViewModel.Rounds);

            try
            {
                await _tournamentStore.Add(tournament);

                _modalNavigationStore.Close();
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}
