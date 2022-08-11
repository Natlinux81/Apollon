using Apollon.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Stores
{
    public class SelectedTournamentStore
    {
		private Tournament _selectedTournament;

		public Tournament SelectedTournament
		{
			get
			{
				return _selectedTournament;
			}
			set
			{
				_selectedTournament = value;
				SelectedTournamentChanged?.Invoke();
			}
		}

		public event Action SelectedTournamentChanged;
	}
}
