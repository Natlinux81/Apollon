using Apollon.Domain.Models;
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
        private readonly OverviewListingItemViewModel _overviewListingItemViewModel;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly TournamentsStore _tournamentsStore;

        public OpenWarningDeleteCommand(OverviewListingItemViewModel overviewListingItemViewModel, ModalNavigationStore modalNavigationStore, TournamentsStore tournamentsStore)
        {
            _overviewListingItemViewModel = overviewListingItemViewModel;
            _modalNavigationStore = modalNavigationStore;
            _tournamentsStore = tournamentsStore;
        }

        public override void Execute(object parameter)
        {
            Tournament tournament =_overviewListingItemViewModel.Tournament;
            WarningDeleteViewModel warningDeleteViewModel = new WarningDeleteViewModel(_modalNavigationStore,_tournamentsStore,_overviewListingItemViewModel);
            _modalNavigationStore.CurrentViewModel = warningDeleteViewModel;
        }
    }
}
