using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class EditTournamentViewModel : ViewModelBase
    {
        public AddEditDetailsViewModel AddEditDetailsViewModel { get; }
        public EditTournamentViewModel()
        {
            AddEditDetailsViewModel = new AddEditDetailsViewModel();
        }
    }
}
