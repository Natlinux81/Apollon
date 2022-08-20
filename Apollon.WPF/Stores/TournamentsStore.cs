using Apollon.Domain.Commands;
using Apollon.Domain.Models;
using Apollon.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Stores
{
    public class TournamentsStore
    {
        private readonly IGetAllTournamentsQuery _getAllTournamentQuery;
        private readonly ICreateTournamentCommand _createTournamentCommand;
        private readonly IUpdateTournamentCommand _updateTournamentCommand;
        private readonly IDeleteTournamentCommand _deleteTournamentCommand;
        private readonly List<Tournament> _tournaments;

        public IEnumerable<Tournament> Tournaments => _tournaments;

        public event Action TournamentLoaded;
        public event Action<Tournament> TournamentAdded;
        public event Action<Tournament> TournamentUpdated;
        public event Action<Guid> TournamentDeleted;

        public TournamentsStore(IGetAllTournamentsQuery getAllTournamentQuery,
            ICreateTournamentCommand createTournamentCommand,
            IUpdateTournamentCommand updateTournamentCommand,
            IDeleteTournamentCommand deleteTournamentCommand)
        {
            _getAllTournamentQuery = getAllTournamentQuery;
            _createTournamentCommand = createTournamentCommand;
            _updateTournamentCommand = updateTournamentCommand;
            _deleteTournamentCommand = deleteTournamentCommand;

            _tournaments = new List<Tournament>();
        }
        
        public async Task Load()
        {
            IEnumerable<Tournament> tournaments = await _getAllTournamentQuery.Execute();

            _tournaments.Clear();
            _tournaments.AddRange(tournaments);

            TournamentLoaded?.Invoke();
        }

        public async Task Add(Tournament tournament)
        {
           await _createTournamentCommand.Execute(tournament);
            TournamentAdded?.Invoke(tournament);
        }

        public async Task Update(Tournament tournament)
        {
            await _updateTournamentCommand.Execute(tournament);

            int currentIndex = _tournaments.FindIndex(y => y.Id == tournament.Id);

            if (currentIndex == -1)
            {
                _tournaments[currentIndex] = tournament;
            }
            else
            {
                _tournaments.Add(tournament);
            }

            TournamentUpdated?.Invoke(tournament);
        }

        public async Task Delete(Guid id)
        {
            await _deleteTournamentCommand.Execute(id);

            _tournaments.RemoveAll(y => y.Id == id);

            TournamentDeleted?.Invoke(id);
        }
    }
}
