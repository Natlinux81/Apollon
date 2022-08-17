using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Models
{
    public class Competition
    {
        public Competition(string competitionName, byte competitionImage)
        {
            CompetitionName = competitionName;
            CompetitionImage = competitionImage;
        }

        public string CompetitionName { get; set; }

        public byte  CompetitionImage { get; set; }
    }
}
