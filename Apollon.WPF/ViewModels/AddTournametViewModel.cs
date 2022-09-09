using Apollon.WPF.Commands;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class AddTournamentViewModel : ViewModelBase
    {
        public AddEditDetailsViewModel AddEditDetailsViewModel { get; }

        public AddTournamentViewModel(TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore, NavigationStore navigationStore,SelectedTournamentsStore selectedTournamentsStore)
        {
            ICommand submitCommand = new AddTournamentCommand(this, tournamentStore,modalNavigationStore,navigationStore, selectedTournamentsStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);            
            AddEditDetailsViewModel = new AddEditDetailsViewModel(submitCommand, cancelCommand);
        }

    }
}
