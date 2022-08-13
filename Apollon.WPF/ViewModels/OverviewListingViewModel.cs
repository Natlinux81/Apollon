using Apollon.WPF.Models;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class OverviewListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<OverviewListingItemViewModel> _apollonOverviewListingItemViewModels;
        private readonly SelectedTournamentStore _selectedTournamentStore;

        public IEnumerable<OverviewListingItemViewModel> ApollonOverviewListingItemViewModels => _apollonOverviewListingItemViewModels;

        private OverviewListingItemViewModel _selectedOverviewListingItemViewModel;

        public OverviewListingItemViewModel SelectedOverviewListingItemViewModel
        {
            get
            {
                return _selectedOverviewListingItemViewModel;
            }
            set
            {
                _selectedOverviewListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedOverviewListingItemViewModel));

                _selectedTournamentStore.SelectedTournament = _selectedOverviewListingItemViewModel.Tournament;
            }
        }

        public OverviewListingViewModel(SelectedTournamentStore selectedTournamentStore)
        {

            _selectedTournamentStore = selectedTournamentStore;
            _apollonOverviewListingItemViewModels = new ObservableCollection<OverviewListingItemViewModel>();

            _apollonOverviewListingItemViewModels.Add(new OverviewListingItemViewModel(new Tournament("DSB", "Deutschemeisterschaft1", "Halle", "01.01.2021", "05.01.2021", "Wiesbaden")));
            _apollonOverviewListingItemViewModels.Add(new OverviewListingItemViewModel(new Tournament("DSB", "Deutschemeisterschaft2", "im Freien", "01.01.2021", "05.01.2021", "Berlin")));
            _apollonOverviewListingItemViewModels.Add(new OverviewListingItemViewModel(new Tournament("DSB", "Deutschemeisterschaft3", "Halle", "01.01.2021", "05.01.2021", "Bruchsal")));
            
        }
    }
}
