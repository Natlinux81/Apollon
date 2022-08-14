using Apollon.WPF.Commands;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class EditTournamentViewModel : ViewModelBase
    {
        public AddEditDetailsViewModel AddEditDetailsViewModel { get; }

        public EditTournamentViewModel(ModalNavigationStore modalNavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            AddEditDetailsViewModel = new AddEditDetailsViewModel(null, cancelCommand); ;
        }
    }
}
