using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.EntityFramework.DTOs
{
    public class TournamentDto
    {
        public Guid Id { get; set; }
        public string Organisation { get; set; }
        public string TournamentName { get; set; }
        public string Competition { get; set; }
        public string CompetitionImage { get; set; }
        public DateTime StartDate { get; set;  }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int Rounds { get; set; }
    }
}
