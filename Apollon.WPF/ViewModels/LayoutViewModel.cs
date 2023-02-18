using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
        public LayoutViewModel(NavBarPreparationViewModel navBarPreparationViewModel, ViewModelBase contentVieModel)
        {
            NavBarPreparationViewModel = navBarPreparationViewModel;
            ContentVieModel = contentVieModel;
        }

        public NavBarPreparationViewModel NavBarPreparationViewModel { get;}
        public ViewModelBase ContentVieModel { get;}
    }
}
