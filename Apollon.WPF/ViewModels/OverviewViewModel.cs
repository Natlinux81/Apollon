using Apollon.WPF.Commands;
using Apollon.Domain.Models;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public ICommand AddTournamentCommand { get; }
        public ICommand LoadTournamentsCommand { get; }
        public ICommand NavigateNavBarCommand { get; }

        public OverviewViewModel(TournamentsStore tournamentStore, SelectedTournamentsStore selectedTournamentStore, 
                                ModalNavigationStore modalNavigationStore, NavigationStore navigationStore)
        {
            OverviewListingViewModel = new OverviewListingViewModel(selectedTournamentStore, modalNavigationStore, tournamentStore);
            OverviewDetailsViewModel = new OverviewDetailsViewModel(selectedTournamentStore);

            LoadTournamentsCommand = new LoadTournamentsCommand(this, tournamentStore);
            AddTournamentCommand = new OpenAddTournamentCommand(tournamentStore, modalNavigationStore, navigationStore, selectedTournamentStore);
            NavigateNavBarCommand = new NavigateCommand<NavBarViewModel>(navigationStore, () => new NavBarViewModel(navigationStore,selectedTournamentStore,modalNavigationStore,tournamentStore));

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
