using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.Domain.Models
{
    public class Tournament
    {
        public Tournament(Guid id, string logo, string organisation, string tournamentName, string competition, string competitionImage, DateTime startDate, DateTime endDate, string location, int rounds)
        {
            Id = id;
            Logo = logo;
            Organisation = organisation;
            TournamentName = tournamentName;
            Competition = competition;
            CompetitionImage = competitionImage;
            StartDate = startDate;
            EndDate = endDate;
            Location = location;
            Rounds = rounds;
        }

        public Guid Id { get; }
        public string Logo { get; }
        public string Organisation { get; }
        public string TournamentName { get; }
        public string Competition { get; }
        public string CompetitionImage { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string Location { get; }
        public int Rounds { get; }
       
    }
}
