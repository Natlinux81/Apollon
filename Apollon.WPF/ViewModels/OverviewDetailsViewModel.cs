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
        private readonly SelectedTournamentsStore _selectedTournamentStore;

        private Tournament SelectedTournament => _selectedTournamentStore.SelectedTournament; 

        public bool HasSelectedTournament => SelectedTournament != null;
        public string Organisation => SelectedTournament?.Organisation ?? "keine Organisation";
        public string TournamentName => SelectedTournament?.TournamentName ?? "kein Name";
        public string Competition => SelectedTournament?.Competition ?? "keine Kategorie";
        public string StartDate => SelectedTournament?.StartDate.ToString("d") ?? "kein Datum"; 
        public string EndDate => SelectedTournament?.EndDate.ToString("d") ?? "kein Datum";
        public string Location => SelectedTournament?.Location ?? "kein Ort";
        public int Rounds => SelectedTournament?.Rounds ?? 0;

        public OverviewDetailsViewModel(SelectedTournamentsStore selectedTournamentStore)
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
            //OnPropertyChanged(nameof(HasSelectedTournament));
            OnPropertyChanged(nameof(Organisation));
            OnPropertyChanged(nameof(TournamentName));
            OnPropertyChanged(nameof(Competition));
            OnPropertyChanged(nameof(StartDate));
            OnPropertyChanged(nameof(EndDate));
            OnPropertyChanged(nameof(Location));
            OnPropertyChanged(nameof(Rounds));
        }
    }
}
