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
        public DateTime Startdate => _selectedTournament?.Startdate ?? DateTime.MinValue;
        public DateTime Enddate => _selectedTournament?.Enddate ?? DateTime.MinValue;
        public string Location => _selectedTournament?.Location ?? "kein Ort";

        public ApollonOverviewDetailsViewModel(SelectedTournamentStore selectedTournamentStore)
        {
           _selectedTournamentStore = selectedTournamentStore;
        }
    }
}
