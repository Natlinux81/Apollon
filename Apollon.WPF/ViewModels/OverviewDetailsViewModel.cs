using Apollon.WPF.Models;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class OverviewDetailsViewModel : ViewModelBase
    {
        private readonly SelectedTournamentStore _selectedTournamentStore;

        private Tournament SelectedTournament => _selectedTournamentStore.SelectedTournament; 

        public bool HasSelectedTournament => SelectedTournament != null;
        public string Organisation => SelectedTournament?.Organisation ?? "keine Organisation";
        public string Tournamentname => SelectedTournament?.Tournamentname ?? "kein Name";
        public string Category => SelectedTournament?.Category ?? "keine Kategorie";
        public string Startdate => SelectedTournament?.Startdate ?? "kein Datum";
        public string Enddate => SelectedTournament?.Enddate ?? "kein Datum";
        public string Location => SelectedTournament?.Location ?? "kein Ort";

        public OverviewDetailsViewModel(SelectedTournamentStore selectedTournamentStore)
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
            OnPropertyChanged(nameof(HasSelectedTournament));
            OnPropertyChanged(nameof(Organisation));
            OnPropertyChanged(nameof(Tournamentname));
            OnPropertyChanged(nameof(Category));
            OnPropertyChanged(nameof(Startdate));
            OnPropertyChanged(nameof(Enddate));
            OnPropertyChanged(nameof(Location));
        }
    }
}
