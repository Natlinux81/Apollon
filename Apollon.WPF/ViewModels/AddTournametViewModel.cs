using Apollon.WPF.Commands;
using Apollon.WPF.Services;
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
            ICommand submitCommand = new AddTournamentCommand(this, new NavigationService<PreparationViewModel>(navigationStore, () => new PreparationViewModel( selectedTournamentsStore, navigationStore, modalNavigationStore, tournamentStore)));
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);            
            AddEditDetailsViewModel = new AddEditDetailsViewModel(submitCommand, cancelCommand);
        }

    }
}
