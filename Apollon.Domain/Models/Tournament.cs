using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.Domain.Models
{
    public class Tournament
    {       
        public Guid Id { get; }
        public string Organisation { get; }
        public string TournamentName { get; }
        public string Competition { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string Location { get; }
        public int Rounds { get; }

        public Tournament(Guid id, string organisation, string tournamentName, string competition, DateTime startDate, DateTime endDate, string location, int rounds = 0)
        {
            Id = id;
            Organisation = organisation;
            TournamentName = tournamentName;
            Competition = competition;
            StartDate = startDate;
            EndDate = endDate;
            Location = location;
            Rounds = rounds;
        }
    }
}
