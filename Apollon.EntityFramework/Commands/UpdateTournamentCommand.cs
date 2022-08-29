using Apollon.Domain.Commands;
using Apollon.Domain.Models;
using Apollon.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.EntityFramework.Commands
{
    public class UpdateTournamentCommand : IUpdateTournamentCommand
    {
        private readonly TournamentsDbContextFactory _contextFactory;

        public UpdateTournamentCommand(TournamentsDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Tournament tournament)
        {            
            using (TournamentsDbContext context = _contextFactory.Create())
            {                
                TournamentDto tournamentDto = new TournamentDto()
                {
                    Id = tournament.Id,
                    Organisation = tournament.Organisation,
                    TournamentName = tournament.TournamentName,
                    Competition = tournament.Competition,
                    CompetitionImage = tournament.CompetitionImage,
                    StartDate = tournament.StartDate,
                    EndDate = tournament.EndDate,
                    Location = tournament.Location,
                    Rounds = tournament.Rounds,
                };

                context.Tournaments.Update(tournamentDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
