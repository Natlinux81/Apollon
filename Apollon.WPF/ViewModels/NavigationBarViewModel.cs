using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateNameListCommand { get;}
        public ICommand GroupsCommand { get;}

    }
}
