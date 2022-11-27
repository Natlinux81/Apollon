using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class ClassesViewModel : ViewModelBase
    {
        public TournamentDetailsViewModel TournamentDetailsViewModel { get; }
        public NavBarPreparationViewModel NavBarPreparationViewModel { get; }

        public ClassesViewModel(NavBarPreparationViewModel navBarPreparationViewModel, SelectedTournamentsStore selectedTournamentsStore)
        {
            TournamentDetailsViewModel = new TournamentDetailsViewModel(selectedTournamentsStore);
            NavBarPreparationViewModel = navBarPreparationViewModel;
        }
    }
}
