using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class AddTournametViewModel : ViewModelBase
    {
        public AddEditDetailsViewModel AddEditDetailsViewModel { get; }

        public AddTournametViewModel()
        {
            AddEditDetailsViewModel = new AddEditDetailsViewModel();
        }

    }
}
