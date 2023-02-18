using Apollon.WPF.Stores;
using Apollon.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<NavBarPreparationViewModel> _createNavBarPreparationViewModel;
                
        public LayoutNavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel, Func<NavBarPreparationViewModel> createNavBarPreparationViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createNavBarPreparationViewModel = createNavBarPreparationViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(_createNavBarPreparationViewModel(), _createViewModel());
        }
    }
}
