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
                                ModalNavigationStore modalNavigationStore, NavigationService<GroupsViewModel> groupNavigationService, NavigationService<NameListViewModel> NameListNavigationService)
        {
            OverviewListingViewModel = new OverviewListingViewModel(selectedTournamentStore, modalNavigationStore, tournamentStore);
            OverviewDetailsViewModel = new OverviewDetailsViewModel(selectedTournamentStore ,groupNavigationService);

            LoadTournamentsCommand = new LoadTournamentsCommand(this, tournamentStore);
            OpenAddTournamentCommand = new OpenAddTournamentCommand(tournamentStore, modalNavigationStore);
            NavigateNameListCommand = new NavigateCommand<NameListViewModel>(NameListNavigationService);

        }

        public static OverviewViewModel LoadViewModel(SelectedTournamentsStore selectedTournamentStore,
                                                      ModalNavigationStore modalNavigationStore, 
                                                      TournamentsStore tournamentStore,                                                       
                                                      NavigationService<GroupsViewModel> groupNavigationService,
                                                      NavigationService<NameListViewModel> NameListNavigationService)
        {
            OverviewViewModel viewModel = new OverviewViewModel(tournamentStore, selectedTournamentStore, modalNavigationStore,groupNavigationService, NameListNavigationService);

            viewModel.LoadTournamentsCommand.Execute(null);

            return viewModel;
        }
    }
}
