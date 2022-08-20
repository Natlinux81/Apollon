using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Commands
{
    public class LoadTournamentsCommand : AsyncCommandBase
    {
        private readonly TournamentsStore _tournamentStore;

        public LoadTournamentsCommand(TournamentsStore tournamentStore)
        {
            _tournamentStore = tournamentStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _tournamentStore.Load();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
