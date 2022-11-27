using Apollon.WPF.Commands;
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
        public ICommand NavigateOverviewCommand { get;}
        public ICommand NavigateGroupsCommand { get;}
        public ICommand NavigateClassesCommand { get;}
        public ICommand NavigateArchersCommand { get;}       
    }
}
