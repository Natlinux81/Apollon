using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Models
{
    public class Tournament
    {
        public Tournament(string organisation, string tournamentname, string competition, string startdate, string enddate, string location, int rounds = 0)
        {
            Organisation = organisation;
            Tournamentname = tournamentname;
            Competition = competition;
            Startdate = startdate;
            Enddate = enddate;
            Location = location;
            Rounds = rounds;
        }

        public string Organisation { get; }
        public string Tournamentname { get; }
        public string Competition { get; }
        public string Startdate { get; }
        public string Enddate { get; }
        public string Location { get; }
        public int Rounds { get; }       
                
    }
}
