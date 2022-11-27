using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class ArchersViewModel : ViewModelBase
    {
        public TournamentDetailsViewModel TournamentDetailsViewModel { get; }
        public NavBarPreparationViewModel NavBarPreparationViewModel { get; }

        public ArchersViewModel(NavBarPreparationViewModel navBarPreparationViewModel, SelectedTournamentsStore selectedTournamentsStore)
        {
            TournamentDetailsViewModel = new TournamentDetailsViewModel(selectedTournamentsStore);
            NavBarPreparationViewModel = navBarPreparationViewModel;
        }
    }
}
