using Apollon.Domain.Models;
using Apollon.WPF.Commands;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class NavBarViewModel : ViewModelBase

    {
        
        private readonly SelectedTournamentsStore _selectedTournamentsStore;

        private Tournament SelectedTournament => _selectedTournamentsStore.SelectedTournament;

        public bool HasSelectedTournament => SelectedTournament != null;
        public string Organisation => SelectedTournament?.Organisation ?? "keine Organisation";
        public string TournamentName => SelectedTournament?.TournamentName ?? "kein Name";
        public string Competition => SelectedTournament?.Competition ?? "keine Kategorie";
        public string CompetitionImage => SelectedTournament?.CompetitionImage ?? "D:\\Projekte\\Apollon\\Apollon\\Apollon.WPF\\Images\\Archery.png";
        public string StartDate => SelectedTournament?.StartDate.ToString("d") ?? "kein Datum";
        public string EndDate => SelectedTournament?.EndDate.ToString("d") ?? "kein Datum";
        public string Location => SelectedTournament?.Location ?? "kein Ort";
        public int Rounds => SelectedTournament?.Rounds ?? 0;

        public AddEditDetailsViewModel AddEditDetailsViewModel { get; }
        public ICommand NavigateOverviewCommand { get; }
        public NavBarViewModel(NavigationStore navigationStore, SelectedTournamentsStore selectedTournamentsStore, ModalNavigationStore modalNavigationStore, TournamentsStore tournamentsStore)
        {
            NavigateOverviewCommand = new NavigateCommand<OverviewViewModel>(navigationStore, () => new OverviewViewModel(tournamentsStore, selectedTournamentsStore, modalNavigationStore,navigationStore));
            
            _selectedTournamentsStore = selectedTournamentsStore;
        }
    }
}
