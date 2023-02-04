using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.ViewModels
{
    public class NameListViewModel : ViewModelBase
    {
		private string _firstName;
		public string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				_firstName = value;
				OnPropertyChanged(nameof(FirstName));
			}
		}

		private string _lastName;
		public string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				_lastName = value;
				OnPropertyChanged(nameof(LastName));
			}
		}

		private int _passNumber;
		public int PassNumber
		{
			get
			{
				return _passNumber;
			}
			set
			{
				_passNumber = value;
				OnPropertyChanged(nameof(PassNumber));
			}
		}

		private string _society;
		public string Society
		{
			get
			{
				return _society;
			}
			set
			{
				_society = value;
				OnPropertyChanged(nameof(Society));
			}
		}

		private int _societyNumber;
		public int SocietyNumber
		{
			get
			{
				return _societyNumber;
			}
			set
			{
				_societyNumber = value;
				OnPropertyChanged(nameof(SocietyNumber));
			}
		}

		private DateTime _birthday;
		public DateTime Birthday
		{
			get
			{
				return _birthday;
			}
			set
			{
				_birthday = value;
				OnPropertyChanged(nameof(Birthday));
			}
		}

		private string _country;
		public string Country
		{
			get
			{
				return _country;
			}
			set
			{
				_country = value;
				OnPropertyChanged(nameof(Country));
			}
		}

		private int _qualification;
		public int Qualification
		{
			get
			{
				return _qualification;
			}
			set
			{
				_qualification = value;
				OnPropertyChanged(nameof(Qualification));
			}
		}

		private bool _isreadOnly;
		public bool IsReadOnly
		{
			get
			{
				return _isreadOnly;
			}
			set
			{
				_isreadOnly = value;
				OnPropertyChanged(nameof(IsReadOnly));
			}
		}
	}
}
