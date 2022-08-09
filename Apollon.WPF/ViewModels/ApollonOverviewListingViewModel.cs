using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class ApollonOverviewListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ApollonOverviewListingItemViewModel> _apollonOverviewListingItemViewModels;
        public IEnumerable<ApollonOverviewListingItemViewModel> ApollonOverviewListingItemViewModels => _apollonOverviewListingItemViewModels;

        public ApollonOverviewListingViewModel()
        {
            _apollonOverviewListingItemViewModels = new ObservableCollection<ApollonOverviewListingItemViewModel>();

            _apollonOverviewListingItemViewModels.Add(new ApollonOverviewListingItemViewModel("Testmeisterschaft1"));
            _apollonOverviewListingItemViewModels.Add(new ApollonOverviewListingItemViewModel("Testmeisterschaft2"));
            _apollonOverviewListingItemViewModels.Add(new ApollonOverviewListingItemViewModel("Testmeisterschaft3"));
        }
    }
}
