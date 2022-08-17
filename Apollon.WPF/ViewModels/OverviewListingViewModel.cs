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

            //_overviewListingItemViewModels.Add(new OverviewListingItemViewModel(new Tournament("DSB", "Meisterschaft", "Halle", DateTime.Now, DateTime.Now, "Bruchsal", 10)));


            //AddTournament(new Tournament("DSB", "Deutschemeisterschaft1", "Halle", "01.01.2021", "05.01.2021", "Wiesbaden",3),modalNavigationStore);
            //AddTournament(new Tournament("DSB", "Deutschemeisterschaft2", "im Freien", "01.01.2021", "05.01.2021", "Berlin",5),modalNavigationStore);
            AddTournament(new Tournament("DSB", "Deutschemeisterschaft3", "Halle", DateTime.Now, DateTime.Today, "Bruchsal", 6), modalNavigationStore);

        }

        private void AddTournament(Tournament tournament, ModalNavigationStore modalNavigationStore)
        {
            // TO DO EditTournamentCommand
            _overviewListingItemViewModels.Add(new OverviewListingItemViewModel(tournament));
        }
    }
}
