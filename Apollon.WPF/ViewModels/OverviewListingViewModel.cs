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
        
        public OverviewListingItemViewModel SelectedOverviewListingItemViewModel
        {
            get
            {
                return _overviewListingItemViewModels.
                    FirstOrDefault(y => y.Tournament?.Id == _selectedTournamentStore.SelectedTournament?.Id); 
            }
            set
            {           
                _selectedTournamentStore.SelectedTournament = value?.Tournament;                
            }
        }

        public OverviewListingViewModel(SelectedTournamentsStore selectedTournamentStore, ModalNavigationStore modalNavigationStore, TournamentsStore tournamentStore)
        {
            _tournamentStore = tournamentStore;
            _selectedTournamentStore = selectedTournamentStore;
            _modalNavigationStore = modalNavigationStore;
            _overviewListingItemViewModels = new ObservableCollection<OverviewListingItemViewModel>();           

            _selectedTournamentStore.SelectedTournamentChanged += SelectedTournamentStore_SelectedTournamentChanged;

            _tournamentStore.TournamentLoaded += TournamentStore_TournamentLoaded;
            _tournamentStore.TournamentAdded += TournamentStore_TournamentAdded;
            _tournamentStore.TournamentUpdated += TournamentStore_TournamentUpdated;
            _tournamentStore.TournamentDeleted += TournamentStore_TournamentDeleted;

            _overviewListingItemViewModels.CollectionChanged += OverviewListingItemViewModels_CollectionChanged;
        }  

        protected override void Dispose()
        {
            _selectedTournamentStore.SelectedTournamentChanged += SelectedTournamentStore_SelectedTournamentChanged;

            _tournamentStore.TournamentLoaded -= TournamentStore_TournamentLoaded;
            _tournamentStore.TournamentAdded -= TournamentStore_TournamentAdded;
            _tournamentStore.TournamentUpdated -= TournamentStore_TournamentUpdated;
            _tournamentStore.TournamentDeleted -= TournamentStore_TournamentDeleted;

            base.Dispose();
        }

        private void SelectedTournamentStore_SelectedTournamentChanged()
        {
            OnPropertyChanged(nameof(SelectedOverviewListingItemViewModel));
        }

        private void TournamentStore_TournamentLoaded()
        {
            _overviewListingItemViewModels.Clear();

            foreach (Tournament tournament in _tournamentStore.Tournaments)
            {
                AddTournament(tournament);
            }
        }

        private void TournamentStore_TournamentAdded(Tournament tournament)
        {
            AddTournament(tournament);
        }

        private void TournamentStore_TournamentUpdated(Tournament tournament)
        {
            OverviewListingItemViewModel overviewViewModel =
                _overviewListingItemViewModels.FirstOrDefault(y => y.Tournament?.Id == tournament.Id);

            if(overviewViewModel != null)
            {
                overviewViewModel.Update(tournament);
            }
        }

        private void TournamentStore_TournamentDeleted(Guid id)
        {
            OverviewListingItemViewModel itemViewModel = _overviewListingItemViewModels.FirstOrDefault(y => y.Tournament?.Id == id);

            if (itemViewModel != null)
            {
                _overviewListingItemViewModels.Remove(itemViewModel);
            }
        }

        private void OverviewListingItemViewModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedOverviewListingItemViewModel));
        }

        private void AddTournament(Tournament tournament)
        {
            OverviewListingItemViewModel itemViewModel =
                new OverviewListingItemViewModel(tournament, _tournamentStore, _modalNavigationStore);
            _overviewListingItemViewModels.Add(itemViewModel);
        }        
    }
}
