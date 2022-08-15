using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Commands
{
    public class AddTournamentCommand : AsyncCommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddTournamentCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }       

        public override async Task ExecuteAsync(object parameter)
        {
            // Add Tournament to Database

            _modalNavigationStore.Close();
        }
    }
}
