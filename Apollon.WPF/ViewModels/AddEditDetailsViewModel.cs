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

		private string _tournamentName;
		public string TournamentName
		{
			get
			{
				return _tournamentName;
			}
			set
			{
				_tournamentName = value;
				OnPropertyChanged(nameof(TournamentName));
				OnPropertyChanged(nameof(CanSubmit));
			}
		}

		private string _competition;
		public string Competition
		{
			get
			{
				return _competition;
			}
			set
			{
				_competition = value;
				OnPropertyChanged(nameof(Competition));
			}
		}

		private string _competitionImage;
		public string CompetitionImage
		{
			get
			{
				return _competitionImage;
			}
			set
			{
				_competitionImage = value;
				OnPropertyChanged(nameof(CompetitionImage));
			}
		}

		private DateTime _startDate = DateTime.Today;		
		public DateTime StartDate 
		{
			
			get
			{
				
				return _startDate;
			}
			set
			{
				_startDate = value;
				
				OnPropertyChanged(nameof(StartDate));
			}
		}

		private DateTime _endDate = DateTime.Today;
		public DateTime EndDate
		{
			get
			{
				return _endDate;
			}
			set
			{
				_endDate = value;
				OnPropertyChanged(nameof(EndDate));
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

		private bool _isSubmitting;
		public bool IsSubmitting
		{
			get
			{
				return _isSubmitting;
			}
			set
			{
				_isSubmitting = value;
				OnPropertyChanged(nameof(IsSubmitting));
			}
		}

		public bool CanSubmit => !string.IsNullOrEmpty(TournamentName);

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddEditDetailsViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }	
	
}
