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
    public class OverviewViewModel : ViewModelBase
    {
        public OverviewListingViewModel OverviewListingViewModel { get; }
        public OverviewDetailsViewModel OverviewDetailsViewModel{ get; }

        public ICommand AddTournamentCommand { get; }
        public ICommand EditTournamentCommand { get; }

        public OverviewViewModel(SelectedTournamentStore _selectedTournamentStore, ModalNavigationStore modalNavigationStore)
        {
            OverviewListingViewModel = new OverviewListingViewModel(_selectedTournamentStore);
            OverviewDetailsViewModel = new OverviewDetailsViewModel(_selectedTournamentStore);

            AddTournamentCommand = new OpenAddTournamentCommand(modalNavigationStore);
            EditTournamentCommand = new OpenEditTournamentCommand(modalNavigationStore);
        }
    }
}
