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
        public ICommand NavigateOverviewCommand { get; }

        public GroupsViewModel(INavigationService<OverviewViewModel> overviewNavigationService)
        {  
            //NavigateOverviewCommand = new NavigateCommand<OverviewViewModel>(overviewNavigationService);              
        }
    }
}
