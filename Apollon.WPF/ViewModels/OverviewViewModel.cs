using Apollon.WPF.Commands;
using Apollon.WPF.Models;
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

        public ICommand AddTournamentCommand { get; }
        public ICommand EditTournamentCommand { get; set ; }

        

        public OverviewViewModel(TournamentStore tournamentStore, SelectedTournamentStore selectedTournamentStore, ModalNavigationStore modalNavigationStore)
        {
            OverviewListingViewModel = new OverviewListingViewModel(selectedTournamentStore, modalNavigationStore, tournamentStore);
            OverviewDetailsViewModel = new OverviewDetailsViewModel(selectedTournamentStore);

            AddTournamentCommand = new OpenAddTournamentCommand(tournamentStore, modalNavigationStore);
            EditTournamentCommand = new OpenEditTournamentCommand(modalNavigationStore);

            AddTournament(new Tournament("DSB", "Deutschemeisterschaft3", "Halle", DateTime.Now, DateTime.Today, "Bruchsal", 6), modalNavigationStore);
        }

        private void AddTournament(Tournament tournament, ModalNavigationStore modalNavigationStore)
        {
            ICommand editTournamentCommand = new EditTournamentCommand(modalNavigationStore);

        }
    }
}
