using Apollon.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Stores
{
    public class TournamentStore
    {
        public event Action<Tournament> TournamentAdded;

        public async Task Add(Tournament tournament)
        {
            TournamentAdded?.Invoke(tournament);
        }
    }
}
