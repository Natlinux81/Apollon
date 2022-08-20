using Apollon.Domain.Commands;
using Apollon.Domain.Models;
using Apollon.Domain.Queries;
using Apollon.EntityFramework;
using Apollon.EntityFramework.Commands;
using Apollon.EntityFramework.Queries;
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
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly TournamentsDbContextFactory _tournamentsDbContextFactory;
        private readonly IGetAllTournamentsQuery _getAllTournamentQuery;
        private readonly ICreateTournamentCommand _createTournamentCommand;
        private readonly IUpdateTournamentCommand _updateTournamentCommand;
        private readonly IDeleteTournamentCommand _deleteTournamentCommand;
        private readonly TournamentsStore _tournamentStore;
        private readonly SelectedTournamentsStore _selectedTournamentStore;
        

        public App()
        {
            string connectionString = "Server=NATHALIE-PC\\NATLINUXDB;Database=Apollon;Trusted_Connection=True;MultipleActiveResultSets=true";

            _modalNavigationStore = new ModalNavigationStore();
            _tournamentsDbContextFactory = new TournamentsDbContextFactory(
                new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);
            _getAllTournamentQuery = new GetAllTournamentsQuery(_tournamentsDbContextFactory);
            _createTournamentCommand = new CreateTournamentCommand(_tournamentsDbContextFactory);
            _updateTournamentCommand = new UpdateTournamentCommand(_tournamentsDbContextFactory);
            _deleteTournamentCommand = new DeleteTournamentCommand(_tournamentsDbContextFactory);
            _tournamentStore = new TournamentsStore(_getAllTournamentQuery, _createTournamentCommand, _updateTournamentCommand, _deleteTournamentCommand);
            _selectedTournamentStore = new SelectedTournamentsStore(_tournamentStore);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using(TournamentsDbContext context = _tournamentsDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

            OverviewViewModel overviewViewModel = new OverviewViewModel(
                _tournamentStore,
                _selectedTournamentStore,
                _modalNavigationStore);

            MainWindow = new MainWindow()
            {
               DataContext = new MainViewModel(_modalNavigationStore, overviewViewModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
