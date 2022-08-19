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
    public class OverviewListingItemViewModel : ViewModelBase
    { 
        public Tournament Tournament { get; private set; }        

        public string TournamentName => Tournament.TournamentName;
        public string Location => Tournament.Location;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public OverviewListingItemViewModel(Tournament tournament, TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore)
        {
            Tournament = tournament;

            EditCommand = new OpenEditTournamentCommand(this, tournamentStore, modalNavigationStore);
        }

        public void Update(Tournament tournament)
        {
            Tournament = tournament;

            OnPropertyChanged(nameof(TournamentName));
            OnPropertyChanged(nameof(Location));
        }
    }
}
