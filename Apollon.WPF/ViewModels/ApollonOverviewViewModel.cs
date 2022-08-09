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

        public ApollonOverviewViewModel()
        {
            ApollonOverviewListingViewModel = new ApollonOverviewListingViewModel();
            ApollonOverviewDetailsViewModel = new ApollonOverviewDetailsViewModel();
        }
    }
}
