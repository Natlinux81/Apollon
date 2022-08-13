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
        public OverviewListingViewModel ApollonOverviewListingViewModel { get; }
        public OverviewDetailsViewModel ApollonOverviewDetailsViewModel{ get; }
        public ICommand AddTournamentCommand { get; }

        public OverviewViewModel(SelectedTournamentStore _selectedTournamentStore)
        {
            ApollonOverviewListingViewModel = new OverviewListingViewModel(_selectedTournamentStore);
            ApollonOverviewDetailsViewModel = new OverviewDetailsViewModel(_selectedTournamentStore);
        }
    }
}
