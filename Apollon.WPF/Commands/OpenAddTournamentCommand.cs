using Apollon.WPF.Stores;
using Apollon.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Commands
{
    public class OpenAddTournamentCommand : CommandBase
    {
        private readonly TournamentsStore _tournamentStore;
        private readonly SelectedTournamentsStore _selectedTournamentsStore;
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddTournamentCommand(TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore, NavigationStore navigationStore, SelectedTournamentsStore selectedTournamentsStore)
        {
            _tournamentStore = tournamentStore;
            _navigationStore = navigationStore;
            _modalNavigationStore = modalNavigationStore;
            _selectedTournamentsStore = selectedTournamentsStore;
        }

        public override void Execute(object parameter)
        {
            AddTournamentViewModel addTournamentViewModel = new AddTournamentViewModel(_tournamentStore, _modalNavigationStore, _navigationStore, _selectedTournamentsStore);
            _modalNavigationStore.CurrentViewModel = addTournamentViewModel;
        }
    }
}
