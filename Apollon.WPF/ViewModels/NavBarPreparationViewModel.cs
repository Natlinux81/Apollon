using Apollon.WPF.Commands;
using Apollon.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class NavBarPreparationViewModel : ViewModelBase
    {
        public ICommand NavigateOverviewCommand { get; }
        public ICommand NavigateGroupsCommand { get;}
        public ICommand NavigateClassesCommand { get;}  
        public ICommand NavigateArchersCommand { get;}

        public NavBarPreparationViewModel(NavigationService<OverviewViewModel> overviewNavigationService, NavigationService<GroupsViewModel> groupNavigationService, 
            NavigationService<ClassesViewModel> classNavigationService, NavigationService<ArchersViewModel> archersNavigationService)
        {
            NavigateOverviewCommand = new NavigateCommand<OverviewViewModel>(overviewNavigationService);
            NavigateGroupsCommand = new NavigateCommand<GroupsViewModel>(groupNavigationService);
            NavigateClassesCommand = new NavigateCommand<ClassesViewModel>(classNavigationService);
            NavigateArchersCommand = new NavigateCommand<ArchersViewModel>(archersNavigationService);
        }
    }
}
