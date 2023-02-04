using Apollon.Domain.Commands;
using Apollon.Domain.Models;
using Apollon.Domain.Queries;
using Apollon.EntityFramework;
using Apollon.EntityFramework.Commands;
using Apollon.EntityFramework.Queries;
using Apollon.WPF.Services;
using Apollon.WPF.Stores;
using Apollon.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Apollon.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ApplicationDBContextFactory _tournamentsDbContextFactory;
        private readonly IGetAllTournamentsQuery _getAllTournamentQuery;
        private readonly ICreateTournamentCommand _createTournamentCommand;
        private readonly IUpdateTournamentCommand _updateTournamentCommand;
        private readonly IDeleteTournamentCommand _deleteTournamentCommand;
        private readonly TournamentsStore _tournamentStore;
        private readonly SelectedTournamentsStore _selectedTournamentStore;
        private readonly NavBarPreparationViewModel _navBarPreparationViewModel;

        public App()
        {
            string connectionString = "Server=NATHALIE-PC\\NATLINUXDB;Database=Apollon;Trusted_Connection=True;MultipleActiveResultSets=true";

            _navigationStore = new NavigationStore();
            _modalNavigationStore = new ModalNavigationStore();
            _tournamentsDbContextFactory = new ApplicationDBContextFactory(
                new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);
            _getAllTournamentQuery = new GetAllTournamentsQuery(_tournamentsDbContextFactory);
            _createTournamentCommand = new CreateTournamentCommand(_tournamentsDbContextFactory);
            _updateTournamentCommand = new UpdateTournamentCommand(_tournamentsDbContextFactory);
            _deleteTournamentCommand = new DeleteTournamentCommand(_tournamentsDbContextFactory);
            _tournamentStore = new TournamentsStore(_getAllTournamentQuery, _createTournamentCommand, _updateTournamentCommand, _deleteTournamentCommand);
            _selectedTournamentStore = new SelectedTournamentsStore(_tournamentStore);

            _navBarPreparationViewModel = new NavBarPreparationViewModel(CreateOverviewNavigationService(),
                                                                         CreateGroupsNavigationService(),
                                                                         CreateNamelistNavigationService(),
                                                                         CreateClassesNavigationService(),                                                                        
                                                                         CreateArchersNavigationService());
        }       

        protected override void OnStartup(StartupEventArgs e)
        {
            using(ApplicationDbContext context = _tournamentsDbContextFactory.Create())
            {
                context.Database.Migrate();
            }
            
            OverviewViewModel overviewViewModel = OverviewViewModel.LoadViewModel(
                _selectedTournamentStore,
                _modalNavigationStore,
                _tournamentStore,
                _navigationStore,
                CreateGroupsNavigationService());

            _navigationStore.CurrentViewModel = OverviewViewModel.LoadViewModel(
                _selectedTournamentStore,
                _modalNavigationStore,
                _tournamentStore,
                _navigationStore,
                CreateGroupsNavigationService());

            

            MainWindow = new MainWindow()
            {
               DataContext = new MainViewModel(_modalNavigationStore, overviewViewModel,_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

         private NavigationService<OverviewViewModel> CreateOverviewNavigationService()
        {
            return new NavigationService<OverviewViewModel>(
                _navigationStore, () => OverviewViewModel.LoadViewModel(_selectedTournamentStore, _modalNavigationStore, _tournamentStore, _navigationStore, CreateGroupsNavigationService()));
        }

        private NavigationService<GroupsViewModel> CreateGroupsNavigationService()
        {
            return new NavigationService<GroupsViewModel>(
                _navigationStore, () => new GroupsViewModel( _navBarPreparationViewModel, _selectedTournamentStore, _navigationStore, _modalNavigationStore, _tournamentStore, CreateGroupsNavigationService()));
        }

        private NavigationService<ClassesViewModel> CreateClassesNavigationService()
        {
            return new NavigationService<ClassesViewModel>(
                _navigationStore, ()=> new ClassesViewModel(_navBarPreparationViewModel, _selectedTournamentStore));
        }

        private NavigationService<NameListViewModel> CreateNamelistNavigationService()
        {
            return new NavigationService<NameListViewModel>(
                _navigationStore, () => new NameListViewModel());
        }

        private NavigationService<ArchersViewModel> CreateArchersNavigationService()
        {
            return new NavigationService<ArchersViewModel>(
                _navigationStore, () => new ArchersViewModel(_navBarPreparationViewModel, _selectedTournamentStore));
        }
    }
}
