using Apollon.WPF.Stores;
using Apollon.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Commands
{
    internal class OpenAddTournamentCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddTournamentCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            AddTournametViewModel addTournametViewModel = new AddTournametViewModel(_modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = addTournametViewModel;
        }
    }
}
