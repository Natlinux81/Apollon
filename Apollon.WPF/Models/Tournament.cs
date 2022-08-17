using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Models
{
    public class Tournament
    {
        public Tournament(string organisation, string tournamentName, string competition, DateTime startDate, DateTime endDate, string location, int rounds = 0)
        {
            Organisation = organisation;
            TournamentName = tournamentName;
            Competition = competition;
            StartDate = startDate;
            EndDate = endDate;
            Location = location;
            Rounds = rounds;
        }

        public string Organisation { get; }
        public string TournamentName { get; }
        public string Competition { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string Location { get; }
        public int Rounds { get; }       
                
    }
}
