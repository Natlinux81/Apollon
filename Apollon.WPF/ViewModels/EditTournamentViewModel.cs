﻿using Apollon.WPF.Commands;
using Apollon.WPF.Models;
using Apollon.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apollon.WPF.ViewModels
{
    public class EditTournamentViewModel : ViewModelBase
    {
        public AddEditDetailsViewModel AddEditDetailsViewModel { get; }

        public EditTournamentViewModel(ModalNavigationStore modalNavigationStore, Tournament tournament)
        {
            ICommand submitCommand = new EditTournamentCommand(modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            AddEditDetailsViewModel = new AddEditDetailsViewModel(submitCommand, cancelCommand )
            {
                Organisation = tournament.Organisation,
                Tournamentname = tournament.Tournamentname,
                Competition = tournament.Competition,
                Startdate = tournament.Startdate,
                Enddate = tournament.Enddate,
                Location = tournament.Location,
                Rounds = tournament.Rounds,
            };
        }       
    }
}