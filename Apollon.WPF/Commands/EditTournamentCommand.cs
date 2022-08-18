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
    public class EditTournamentCommand : AsyncCommandBase
    {
        private readonly EditTournamentViewModel _editTournamentViewModel;
        private readonly TournamentsStore _tournamentStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditTournamentCommand(EditTournamentViewModel editTournamentViewModel, TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore)
        {
            _editTournamentViewModel = editTournamentViewModel;
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            AddEditDetailsViewModel detailsViewModel = _editTournamentViewModel.AddEditDetailsViewModel;
            Tournament tournament = new Tournament(
                _editTournamentViewModel.TournamentId,
                detailsViewModel.Organisation,
                detailsViewModel.TournamentName,
                detailsViewModel.Competition,
                detailsViewModel.StartDate,
                detailsViewModel.EndDate,
                detailsViewModel.Location,
                detailsViewModel.Rounds);

            try
            {
                await _tournamentStore.Update(tournament);

                _modalNavigationStore.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
