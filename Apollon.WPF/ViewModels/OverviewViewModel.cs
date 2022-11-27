using Apollon.WPF.Commands;
using Apollon.WPF.Stores;
using System.Windows.Input;
using Apollon.WPF.Services;

namespace Apollon.WPF.ViewModels
{
    public class OverviewViewModel : ViewModelBase
    {
        public OverviewListingViewModel OverviewListingViewModel { get; }
        public OverviewDetailsViewModel OverviewDetailsViewModel{ get; }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand OpenAddTournamentCommand { get; }
        public ICommand LoadTournamentsCommand { get; } 
        public ICommand NavigateNameListCommand { get; }

        public OverviewViewModel(TournamentsStore tournamentStore, SelectedTournamentsStore selectedTournamentStore, 
                                ModalNavigationStore modalNavigationStore, NavigationStore navigationStore)
        {
            OverviewListingViewModel = new OverviewListingViewModel(selectedTournamentStore, modalNavigationStore, tournamentStore);
            OverviewDetailsViewModel = new OverviewDetailsViewModel(selectedTournamentStore ,navigationStore, modalNavigationStore,tournamentStore);

            LoadTournamentsCommand = new LoadTournamentsCommand(this, tournamentStore);
            OpenAddTournamentCommand = new OpenAddTournamentCommand(tournamentStore, modalNavigationStore, navigationStore, selectedTournamentStore);
            NavigateNameListCommand = new NavigateCommand<NameListViewModel>(new NavigationService<NameListViewModel>(
                navigationStore, () => new NameListViewModel()));

        }

        public static OverviewViewModel LoadViewModel(SelectedTournamentsStore selectedTournamentStore,
                                                      ModalNavigationStore modalNavigationStore, 
                                                      TournamentsStore tournamentStore, 
                                                      NavigationStore navigationStore)
        {
            OverviewViewModel viewModel = new OverviewViewModel(tournamentStore, selectedTournamentStore, modalNavigationStore, navigationStore);

            viewModel.LoadTournamentsCommand.Execute(null);

            return viewModel;
        }
    }
}
