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
       

        public OpenEditTournamentCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
            
        }

        public override void Execute(object parameter)
        {
            EditTournamentViewModel editTournamentViewModel = new EditTournamentViewModel(_modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editTournamentViewModel;
        }
    }
}
