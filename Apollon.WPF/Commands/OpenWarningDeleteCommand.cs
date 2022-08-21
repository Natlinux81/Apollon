using Apollon.WPF.Stores;
using Apollon.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Commands
{
    public class OpenWarningDeleteCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenWarningDeleteCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            WarningDeleteViewModel warningDeleteViewModel = new WarningDeleteViewModel(_modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = warningDeleteViewModel;
        }
    }
}
