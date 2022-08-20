using Apollon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Stores
{
    public class SelectedTournamentsStore
    {
		private readonly TournamentsStore _tournamentStore;       

        private Tournament _selectedTournament;

		public Tournament SelectedTournament
		{
			get
			{
				return _selectedTournament;
			}
			set
			{
				_selectedTournament = value;
				SelectedTournamentChanged?.Invoke();
			}
		}

		public event Action SelectedTournamentChanged;

        public SelectedTournamentsStore(TournamentsStore tournamentstore)
        {
            _tournamentStore = tournamentstore;

			_tournamentStore.TournamentUpdated += TournamentStore_TournamentUpdated;
			_tournamentStore.TournamentAdded += TournamentStore_TournamentAdded;
        }

		private void TournamentStore_TournamentAdded(Tournament tournament)
		{
			SelectedTournament = tournament;
		}

		private void TournamentStore_TournamentUpdated(Tournament tournament)
		{
			if(tournament.Id == SelectedTournament?.Id)
			{
				SelectedTournament = tournament;
			}
		}

	}
}
