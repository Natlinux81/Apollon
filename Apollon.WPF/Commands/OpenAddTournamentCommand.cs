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
    public class OpenAddTournamentCommand : CommandBase
    {
        private readonly TournamentsStore _tournamentStore;      
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly NavigationService<GroupsViewModel> _navigationService;

        public OpenAddTournamentCommand(TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore, NavigationService<GroupsViewModel> navigationService)
        {
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            AddTournamentViewModel addTournamentViewModel = new AddTournamentViewModel(_tournamentStore, _modalNavigationStore, _navigationService);
            _modalNavigationStore.CurrentViewModel = addTournamentViewModel;
        }
    }
}
