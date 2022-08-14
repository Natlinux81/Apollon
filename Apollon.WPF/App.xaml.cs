using Apollon.WPF.Stores;
using Apollon.WPF.ViewModels;
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
        private readonly SelectedTournamentStore _selectedTournamentStore;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _selectedTournamentStore = new SelectedTournamentStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            OverviewViewModel overviewViewModel = new OverviewViewModel(_selectedTournamentStore, _modalNavigationStore);

            MainWindow = new MainWindow()
            {
               DataContext = new MainViewModel(_modalNavigationStore, overviewViewModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
