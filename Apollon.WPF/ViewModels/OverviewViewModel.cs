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

        public OverviewViewModel(SelectedTournamentStore _selectedTournamentStore)
        {
            OverviewListingViewModel = new OverviewListingViewModel(_selectedTournamentStore);
            OverviewDetailsViewModel = new OverviewDetailsViewModel(_selectedTournamentStore);
        }
    }
}
