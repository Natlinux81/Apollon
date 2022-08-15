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
        private readonly ObservableCollection<OverviewListingItemViewModel> _OverviewListingItemViewModels;
        private readonly SelectedTournamentStore _selectedTournamentStore;

        public IEnumerable<OverviewListingItemViewModel> OverviewListingItemViewModels => _OverviewListingItemViewModels;

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
            _OverviewListingItemViewModels = new ObservableCollection<OverviewListingItemViewModel>();

            _OverviewListingItemViewModels.Add(new OverviewListingItemViewModel(new Tournament("DSB", "Deutschemeisterschaft1", "Halle", "01.01.2021", "05.01.2021", "Wiesbaden",3)));
            _OverviewListingItemViewModels.Add(new OverviewListingItemViewModel(new Tournament("DSB", "Deutschemeisterschaft2", "im Freien", "01.01.2021", "05.01.2021", "Berlin",5)));
            _OverviewListingItemViewModels.Add(new OverviewListingItemViewModel(new Tournament("DSB", "Deutschemeisterschaft3", "Halle", "01.01.2021", "05.01.2021", "Bruchsal", 6)));
            
        }
    }
}
