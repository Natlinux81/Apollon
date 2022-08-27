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

        public ICommand AddTournamentCommand { get; }
        public ICommand LoadTournamentsCommand { get; }
        public ICommand NavigateNavBarCommand { get; }

        public OverviewViewModel(TournamentsStore tournamentStore, SelectedTournamentsStore selectedTournamentStore, 
                                ModalNavigationStore modalNavigationStore, NavigationStore navigationStore)
        {
            OverviewListingViewModel = new OverviewListingViewModel(selectedTournamentStore, modalNavigationStore, tournamentStore);
            OverviewDetailsViewModel = new OverviewDetailsViewModel(selectedTournamentStore);

            LoadTournamentsCommand = new LoadTournamentsCommand(this, tournamentStore);
            AddTournamentCommand = new OpenAddTournamentCommand(tournamentStore, modalNavigationStore);
            NavigateNavBarCommand = new NavigatCommand<NavBarViewModel>(navigationStore, () => new NavBarViewModel(navigationStore));

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
