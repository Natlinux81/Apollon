using Apollon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Stores
{
    public class TournamentsStore
    {
        public event Action<Tournament> TournamentAdded;
        public event Action<Tournament> TournamentUpdated;

        public async Task Add(Tournament tournament)
        {
            TournamentAdded?.Invoke(tournament);
        }

        public async Task Update (Tournament tournament)
        {
            TournamentUpdated?.Invoke(tournament);
        }
    }
}
