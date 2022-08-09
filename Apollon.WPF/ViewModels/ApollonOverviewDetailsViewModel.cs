using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class ApollonOverviewDetailsViewModel : ViewModelBase
    {
        public string Organisation { get; }
        public string Tournamentname { get; }
        public string Category { get; }
        public DateTime Datetime { get; }
        public string Location { get; }

        public ApollonOverviewDetailsViewModel()
        {
            Organisation = "Deutscher Schützenbund";
            Tournamentname = "Deutsche Meisterschaft 2021";
            Category = "Bogenschießen im Freien";
            Datetime = DateTime.Now;
            Location = "Wiesbaden";
        }
    }
}
