using Apollon.Domain.Models;
using Apollon.WPF.Commands;
using Apollon.WPF.Services;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class GroupsViewModel : ViewModelBase
    {      

        public TournamentDetailsViewModel TournamentDetailsViewModel { get; }
        public NavBarPreparationViewModel NavBarPreparationViewModel { get; }
        public ICommand NavigateOverviewCommand { get; }

        public GroupsViewModel(NavBarPreparationViewModel navBarPreparationViewModel, SelectedTournamentsStore selectedTournamentStore, NavigationService<OverviewViewModel> overviewNavigationService)
        {    
            TournamentDetailsViewModel = new TournamentDetailsViewModel(selectedTournamentStore);
            
            NavBarPreparationViewModel = navBarPreparationViewModel;

            NavigateOverviewCommand = new NavigateCommand<OverviewViewModel>(overviewNavigationService);              
        }
    }
}
