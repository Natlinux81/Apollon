using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Models
{
    public class Tournament
    {
        public Tournament(string organisation, string tournamentname, string category, DateTime datetime, string location)
        {
            Organisation = organisation;
            Tournamentname = tournamentname;
            Category = category;
            Datetime = datetime;
            Location = location;
        }

        public string Organisation { get; }
        public string Tournamentname { get; }
        public string Category { get; }
        public DateTime Datetime { get; }
        public string Location { get; }
    }
}
