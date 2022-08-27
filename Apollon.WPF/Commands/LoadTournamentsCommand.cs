using Apollon.WPF.Stores;
using Apollon.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Commands
{
    public class LoadTournamentsCommand : AsyncCommandBase
    {
        private readonly OverviewViewModel _overviewViewModel;
        private readonly TournamentsStore _tournamentStore;

        public LoadTournamentsCommand(OverviewViewModel overviewViewModel, TournamentsStore tournamentStore)
        {
            _overviewViewModel = overviewViewModel;
            _tournamentStore = tournamentStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _overviewViewModel.IsLoading = true;

            try
            {
                await _tournamentStore.Load();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _overviewViewModel.IsLoading = false;
            }
        }
    }
}
