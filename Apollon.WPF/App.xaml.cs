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
        private readonly SelectedTournamentStore _selectedTournamentStore;

        public App()
        {
            _selectedTournamentStore = new SelectedTournamentStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
               DataContext = new ApollonOverviewViewModel(_selectedTournamentStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
