using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class ApollonOverviewViewModel : ViewModelBase
    {
        public ApollonOverviewListingViewModel ApollonOverviewListingViewModel { get; }
        public ApollonOverviewDetailsViewModel ApollonOverviewDetailsViewModel{ get; }
        public ICommand AddTournamentCommand { get; }

        public ApollonOverviewViewModel(SelectedTournamentStore _selectedTournamentStore)
        {
            ApollonOverviewListingViewModel = new ApollonOverviewListingViewModel(_selectedTournamentStore);
            ApollonOverviewDetailsViewModel = new ApollonOverviewDetailsViewModel(_selectedTournamentStore);
        }
    }
}
