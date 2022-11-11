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
    public class EditTournamentViewModel : ViewModelBase
    {
        public Guid TournamentId { get;}
        public AddEditDetailsViewModel AddEditDetailsViewModel { get; }

        public EditTournamentViewModel(ModalNavigationStore modalNavigationStore, TournamentsStore tournamentStore, Tournament tournament)
        {
            TournamentId = tournament.Id;

            ICommand submitCommand = new EditTournamentCommand(this, tournamentStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            AddEditDetailsViewModel = new AddEditDetailsViewModel(submitCommand, cancelCommand)

            {
                Logo = tournament.Logo,
                Organisation = tournament.Organisation,
                TournamentName = tournament.TournamentName,
                Competition = tournament.Competition,
                CompetitionImage = tournament.CompetitionImage,
                StartDate = tournament.StartDate,
                EndDate = tournament.EndDate,
                Location = tournament.Location,
                Rounds = tournament.Rounds,
            };
           
        }       
    }
}
