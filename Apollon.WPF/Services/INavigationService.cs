using Apollon.WPF.ViewModels;

namespace Apollon.WPF.Services
{
    public interface INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        void Navigate();
    }
}