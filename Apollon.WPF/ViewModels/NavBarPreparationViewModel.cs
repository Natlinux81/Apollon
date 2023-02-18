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
        public ICommand NavigateNamelistCommand { get;}
        public ICommand NavigateArchersCommand { get;}

        public NavBarPreparationViewModel(INavigationService<OverviewViewModel> overviewNavigationService, 
                                          INavigationService<GroupsViewModel> groupNavigationService, 
                                          INavigationService<NameListViewModel> namelistNavigationService,
                                          INavigationService<ClassesViewModel> classNavigationService,
                                          INavigationService<ArchersViewModel> archersNavigationService)
        {
            NavigateOverviewCommand = new NavigateCommand<OverviewViewModel>(overviewNavigationService);
            NavigateGroupsCommand = new NavigateCommand<GroupsViewModel>(groupNavigationService);
            NavigateClassesCommand = new NavigateCommand<ClassesViewModel>(classNavigationService);
            NavigateNamelistCommand = new NavigateCommand<NameListViewModel>(namelistNavigationService);
            NavigateArchersCommand = new NavigateCommand<ArchersViewModel>(archersNavigationService);
        }
    }
}
