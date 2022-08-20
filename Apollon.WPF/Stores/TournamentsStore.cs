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

        public TournamentsStore(IGetAllTournamentsQuery getAllTournamentQuery,
            ICreateTournamentCommand createTournamentCommand,
            IUpdateTournamentCommand updateTournamentCommand,
            IDeleteTournamentCommand deleteTournamentCommand)
        {
            _getAllTournamentQuery = getAllTournamentQuery;
            _createTournamentCommand = createTournamentCommand;
            _updateTournamentCommand = updateTournamentCommand;
            _deleteTournamentCommand = deleteTournamentCommand;
        }

        public event Action<Tournament> TournamentAdded;
        public event Action<Tournament> TournamentUpdated;

        public async Task Add(Tournament tournament)
        {
           await _createTournamentCommand.Execute(tournament);
            TournamentAdded?.Invoke(tournament);
        }

        public async Task Update (Tournament tournament)
        {
            await _updateTournamentCommand.Execute(tournament);
            TournamentUpdated?.Invoke(tournament);
        }
    }
}
