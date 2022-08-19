using Apollon.WPF.Commands;
using Apollon.Domain.Models;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class OverviewListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<OverviewListingItemViewModel> _overviewListingItemViewModels;
        private readonly SelectedTournamentsStore _selectedTournamentStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly TournamentsStore _tournamentStore;
        

        public IEnumerable<OverviewListingItemViewModel> OverviewListingItemViewModels => _overviewListingItemViewModels;

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

        public OverviewListingViewModel(SelectedTournamentsStore selectedTournamentStore, ModalNavigationStore modalNavigationStore, TournamentsStore tournamentStore)
        {
            _tournamentStore = tournamentStore;
            _selectedTournamentStore = selectedTournamentStore;
            _modalNavigationStore = modalNavigationStore;
            _overviewListingItemViewModels = new ObservableCollection<OverviewListingItemViewModel>();

            _tournamentStore.TournamentAdded += TournamentStore_TournamentAdded;
            _tournamentStore.TournamentUpdated += TournamentStore_TournamentUpdated;
        }       

        protected override void Dispose()
        {
            _tournamentStore.TournamentAdded -= TournamentStore_TournamentAdded;
            _tournamentStore.TournamentUpdated -= TournamentStore_TournamentUpdated;

            base.Dispose();
        }
        private void TournamentStore_TournamentAdded(Tournament tournament)
        {
            AddTournament(tournament);
        }

        private void TournamentStore_TournamentUpdated(Tournament tournament)
        {
            OverviewListingItemViewModel overviewViewModel =
                _overviewListingItemViewModels.FirstOrDefault(y => y.Tournament.Id == tournament.Id);

            if(overviewViewModel != null)
            {
                overviewViewModel.Update(tournament);
            }
        }

        private void AddTournament(Tournament tournament)
        {
            OverviewListingItemViewModel itemViewModel = new OverviewListingItemViewModel(tournament, _tournamentStore, _modalNavigationStore);
            _overviewListingItemViewModels.Add(itemViewModel);
        }
    }
}
