﻿using Apollon.Domain.Models;
using Apollon.WPF.Stores;
using Apollon.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Commands
{
    public class EditTournamentCommand : AsyncCommandBase
    {
        private readonly EditTournamentViewModel _editTournamentViewModel;
        private readonly TournamentsStore _tournamentStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditTournamentCommand(EditTournamentViewModel editTournamentViewModel, TournamentsStore tournamentStore, ModalNavigationStore modalNavigationStore)
        {
            _editTournamentViewModel = editTournamentViewModel;
            _tournamentStore = tournamentStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            AddEditDetailsViewModel detailsViewModel = _editTournamentViewModel.AddEditDetailsViewModel;

            detailsViewModel.ErrorMessage = null;
            detailsViewModel.IsSubmitting = true;

            Tournament tournament = new Tournament(
                _editTournamentViewModel.TournamentId,
                detailsViewModel.Logo,
                detailsViewModel.Organisation,
                detailsViewModel.TournamentName,
                detailsViewModel.Competition,
                detailsViewModel.CompetitionImage,
                detailsViewModel.StartDate,
                detailsViewModel.EndDate,
                detailsViewModel.Location,
                detailsViewModel.Groups,
                detailsViewModel.Targets);

            try
            {
                await _tournamentStore.Update(tournament);

                _modalNavigationStore.Close();

            }
            catch (Exception)
            {

                detailsViewModel.ErrorMessage = "Daten konnten nicht gespeichert werden!";
            }
            finally
            {
                detailsViewModel.IsSubmitting = false;
            }
        }
    }
}
