using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class ClassesViewModel : ViewModelBase
    {
        public NavBarPreparationViewModel NavBarPreparationViewModel { get; }

        public ClassesViewModel(NavBarPreparationViewModel navBarPreparationViewModel)
        {
            NavBarPreparationViewModel = navBarPreparationViewModel;
        }
    }
}
