﻿using Apollon.Domain.Models;
using Apollon.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class AddEditDetailsViewModel : ViewModelBase
    {
		private string logo;
		public string Logo
		{
			get
			{
				return logo;
			}
			set
			{
				logo = value;
				OnPropertyChanged(nameof(Logo));
			}
		}	

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
				OnPropertyChanged(nameof(CompetitionImage));;
			}
		}

		private Competition _currentCompetition;
		public Competition CurrentCompetition
		{
			get
			{
				return _currentCompetition;
			}
			set
			{
				_currentCompetition = value;
				CompetitionImage = _currentCompetition.CompetitionImage;
				OnPropertyChanged(nameof(CurrentCompetition));
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

		private int _groups;
		public int Groups
		{
			get
			{
				return _groups;
			}
			set
			{
				_groups = value;
				OnPropertyChanged(nameof(Groups));
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

		private int _targets;
		public int Targets
		{
			get
			{
				return _targets;
			}
			set
			{
				_targets = value;
				OnPropertyChanged(nameof(Targets));
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

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public bool CanSubmit => !string.IsNullOrEmpty(TournamentName);

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
		public ICommand ChooseLogoCommand { get; }

        public ObservableCollection<Competition> CompetitionList { get; }
		
		
		public AddEditDetailsViewModel(ICommand submitCommand, ICommand cancelCommand)
		{
			SubmitCommand = submitCommand;
			CancelCommand = cancelCommand;
			ChooseLogoCommand = new ChooseLogoCommand(this);	

            CompetitionList = new ObservableCollection<Competition>
            {
				new Competition
				{
					CompetitionName = "Halle",
					CompetitionImage = @"\Images\targetHall.png"
                },
				new Competition
				{
					CompetitionName = "im Freien",
					CompetitionImage = @"\Images\targetOutdoor.png"
                },
				new Competition
				{
					CompetitionName = "Feld",
					CompetitionImage = @"\Images\targetField.png"
                },

                new Competition
                {
                    CompetitionName = "3D",
                    CompetitionImage = @"\Images\3d.png"
                }
            };            
        }
	}	
}
