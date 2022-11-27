using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class ArchersViewModel : ViewModelBase
    {
        public NavBarPreparationViewModel NavBarPreparationViewModel { get; }

        public ArchersViewModel(NavBarPreparationViewModel navBarPreparationViewModel)
        {
            NavBarPreparationViewModel = navBarPreparationViewModel;
        }
    }
}
