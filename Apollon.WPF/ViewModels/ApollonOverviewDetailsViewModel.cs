using Apollon.WPF.Models;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class ApollonOverviewDetailsViewModel : ViewModelBase
    {
        private readonly SelectedTournamentStore _selectedTournamentStore;

        private Tournament _selectedTournament => _selectedTournamentStore.SelectedTournament; 

        public bool hasSelectedTournament => _selectedTournament != null;
        public string Organisation => _selectedTournament?.Organisation ?? "keine Organisation";
        public string Tournamentname => _selectedTournament?.Tournamentname ?? "kein Name";
        public string Category => _selectedTournament?.Category ?? "keine Kategorie";
        public string Startdate => _selectedTournament?.Startdate ?? "kein Datum";
        public string Enddate => _selectedTournament?.Enddate ?? "kein Datum";
        public string Location => _selectedTournament?.Location ?? "kein Ort";

        public ApollonOverviewDetailsViewModel(SelectedTournamentStore selectedTournamentStore)
        {
           _selectedTournamentStore = selectedTournamentStore;

            _selectedTournamentStore.SelectedTournamentChanged += SelectedTournamentStore_SelectedTournamentChanged;
        }

        protected override void Dispose()
        {
            _selectedTournamentStore.SelectedTournamentChanged -= SelectedTournamentStore_SelectedTournamentChanged; 
            base.Dispose();
        }

        private void SelectedTournamentStore_SelectedTournamentChanged()
        {
            OnPropertyChanged(nameof(hasSelectedTournament));
            OnPropertyChanged(nameof(Organisation));
            OnPropertyChanged(nameof(Tournamentname));
            OnPropertyChanged(nameof(Category));
            OnPropertyChanged(nameof(Startdate));
            OnPropertyChanged(nameof(Enddate));
            OnPropertyChanged(nameof(Location));
        }
    }
}
