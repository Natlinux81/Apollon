﻿using Apollon.Domain.Models;
using Apollon.WPF.Commands;
using Apollon.WPF.Services;
using Apollon.WPF.Stores;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class OverviewDetailsViewModel : ViewModelBase
    {
        private readonly SelectedTournamentsStore _selectedTournamentStore;
        private Tournament SelectedTournament => _selectedTournamentStore.SelectedTournament; 

        public bool HasSelectedTournament => SelectedTournament != null;
        public string Logo => SelectedTournament?.Logo ?? @"\images\Archery.png";
        public string Organisation => SelectedTournament?.Organisation ?? "keine Organisation";
        public string TournamentName => SelectedTournament?.TournamentName ?? "kein Name";
        public string Competition => SelectedTournament?.Competition ?? "keine Kategorie";
        public string CompetitionImage => SelectedTournament?.CompetitionImage ?? @"\images\Archery.png";
        public string StartDate => SelectedTournament?.StartDate.ToString("d") ?? "kein Datum"; 
        public string EndDate => SelectedTournament?.EndDate.ToString("d") ?? "kein Datum";
        public string Location => SelectedTournament?.Location ?? "kein Ort";
        public int Rounds => SelectedTournament?.Rounds ?? 0;
        public int Targets => SelectedTournament?.Targets ?? 0;

        public ICommand NavigatePreparationCommand { get; }
        public SelectedTournamentsStore SelectedTournamentStore { get; }
        

        public OverviewDetailsViewModel(SelectedTournamentsStore selectedTournamentStore, INavigationService<GroupsViewModel> groupNavigationService)
        {
           _selectedTournamentStore = selectedTournamentStore;

            _selectedTournamentStore.SelectedTournamentChanged += SelectedTournamentStore_SelectedTournamentChanged;

            NavigatePreparationCommand = new NavigateCommand<GroupsViewModel>(groupNavigationService);
        }        

        protected override void Dispose()
        {
           
            _selectedTournamentStore.SelectedTournamentChanged -= SelectedTournamentStore_SelectedTournamentChanged; 

            base.Dispose();
        }

        private void SelectedTournamentStore_SelectedTournamentChanged()
        {
            OnPropertyChanged(nameof(HasSelectedTournament));
            OnPropertyChanged(nameof(Logo));
            OnPropertyChanged(nameof(Organisation));
            OnPropertyChanged(nameof(TournamentName));
            OnPropertyChanged(nameof(Competition));
            OnPropertyChanged(nameof(CompetitionImage));
            OnPropertyChanged(nameof(StartDate));
            OnPropertyChanged(nameof(EndDate));
            OnPropertyChanged(nameof(Location));
            OnPropertyChanged(nameof(Rounds));
            OnPropertyChanged(nameof(Targets));
        }
    }
}
