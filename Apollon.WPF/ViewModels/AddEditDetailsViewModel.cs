using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class AddEditDetailsViewModel : ViewModelBase
    {
		private string _organisation;
		public string Organisation
		{
			get
			{
				return _organisation;
			}
			set
			{
				_organisation = value;
				OnPropertyChanged(nameof(Organisation));
			}
		}

		private string _tournamentname;
		public string Tournamentname
		{
			get
			{
				return _tournamentname;
			}
			set
			{
				_tournamentname = value;
				OnPropertyChanged(nameof(Tournamentname));
				OnPropertyChanged(nameof(CanSubmit));
			}
		}

		private string _category;
		public string Category
		{
			get
			{
				return _category;
			}
			set
			{
				_category = value;
				OnPropertyChanged(nameof(Category));
			}
		}

		private string _startdate;
		public string Startdate
		{
			get
			{
				return _startdate;
			}
			set
			{
				_startdate = value;
				OnPropertyChanged(nameof(Startdate));
			}
		}

		private string _enddate;
		public string Enddate
		{
			get
			{
				return _enddate;
			}
			set
			{
				_enddate = value;
				OnPropertyChanged(nameof(Enddate));
			}
		}

		private int _rounds;
		public int Rounds
		{
			get
			{
				return _rounds;
			}
			set
			{
				_rounds = value;
				OnPropertyChanged(nameof(Rounds));
			}
		}

		private string _location;
		public string Location
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
				OnPropertyChanged(nameof(Location));
			}
		}

        public bool CanSubmit => !string.IsNullOrEmpty(Tournamentname);

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddEditDetailsViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }

	
	
}
