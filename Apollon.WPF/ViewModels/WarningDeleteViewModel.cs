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
    public class WarningDeleteViewModel : ViewModelBase
    {
		private bool _isDeleting;
		public bool IsDeleting
        {
			get
			{
				return _isDeleting;
			}
			set
			{
				_isDeleting = value;
				OnPropertyChanged(nameof(IsDeleting));
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

        public ICommand WarningCloseCommand { get;}
        public ICommand DeleteCommand { get; }
        public WarningDeleteViewModel(ModalNavigationStore modalNavigationStore,TournamentsStore tournamentsStore, OverviewListingItemViewModel overviewListingItemViewModel)
        {
            WarningCloseCommand = new CloseModalCommand(modalNavigationStore);
            DeleteCommand = new DeleteTournamentCommand(this, overviewListingItemViewModel, tournamentsStore, modalNavigationStore);
        }
    }
}
