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
    public class OpenEditTournamentCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly Tournament _tournament;

        public OpenEditTournamentCommand(ModalNavigationStore modalNavigationStore, Tournament tournament)
        {
            _modalNavigationStore = modalNavigationStore;
            _tournament = tournament;
        }

        public override void Execute(object parameter)
        {
            EditTournamentViewModel editTournamentViewModel = new EditTournamentViewModel(_tournament,_modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editTournamentViewModel;
        }
    }
}
