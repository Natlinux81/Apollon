using Apollon.WPF.Commands;
using Apollon.WPF.Models;
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
        private readonly SelectedTournamentStore _selectedTournamentStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly TournamentStore _tournamentStore;
        

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

        public OverviewListingViewModel(SelectedTournamentStore selectedTournamentStore, ModalNavigationStore modalNavigationStore, TournamentStore tournamentStore)
        {
            _tournamentStore = tournamentStore;
            _selectedTournamentStore = selectedTournamentStore;
            _modalNavigationStore = modalNavigationStore;
            _overviewListingItemViewModels = new ObservableCollection<OverviewListingItemViewModel>();

            _tournamentStore.TournamentAdded += _tournamentStore_TournamentAdded;

            //AddTournament(new Tournament("DSB", "Deutschemeisterschaft1", "Halle", "01.01.2021", "05.01.2021", "Wiesbaden",3),modalNavigationStore);
            //AddTournament(new Tournament("DSB", "Deutschemeisterschaft2", "im Freien", "01.01.2021", "05.01.2021", "Berlin",5),modalNavigationStore);
            //AddTournament(new Tournament("DSB", "Deutschemeisterschaft3", "Halle", "01.01.2021", "05.01.2021", "Bruchsal", 6),modalNavigationStore);
            
        }

        protected override void Dispose()
        {
            _tournamentStore.TournamentAdded -= _tournamentStore_TournamentAdded;

            base.Dispose();
        }

        private void _tournamentStore_TournamentAdded(Tournament tournament)
        {
            AddTournament(tournament);
        }

        private void AddTournament(Tournament tournament)
        {
            //ICommand editTournamentCommand = new OpenEditTournamentCommand(_modalNavigationStore);
            _overviewListingItemViewModels.Add(new OverviewListingItemViewModel(tournament
                //,editTournamentCommand
                ));
        }
    }
    
    
}
