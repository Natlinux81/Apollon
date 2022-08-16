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
        private readonly TournamentStore _tournamentStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddTournamentCommand(TournamentStore tournamentStore, ModalNavigationStore modalNavigationStore)
        {
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            AddTournamentViewModel addTournamentViewModel = new AddTournamentViewModel(_tournamentStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = addTournamentViewModel;
        }
    }
}
