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
        private readonly TournamentStore _tournamentStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private AddTournamentViewModel _addTournamentViewModel;
        

        public AddTournamentCommand(TournamentStore tournamentStore, ModalNavigationStore modalNavigationStore)
        {
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public AddTournamentCommand(AddTournamentViewModel addTournamentViewModel, TournamentStore tournamentStore, ModalNavigationStore modalNavigationStore)
        {
            _addTournamentViewModel = addTournamentViewModel;
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            AddEditDetailsViewModel formViewModel = _addTournamentViewModel.AddEditDetailsViewModel;
            Tournament tournament = new Tournament(
                formViewModel.Organisation,
                formViewModel.TournamentName,
                formViewModel.Competition,
                formViewModel.StartDate,
                formViewModel.EndDate,
                formViewModel.Location,
                formViewModel.Rounds);

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
