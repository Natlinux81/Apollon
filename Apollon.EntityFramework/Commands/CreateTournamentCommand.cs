using Apollon.Domain.Commands;
using Apollon.Domain.Models;
using Apollon.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.EntityFramework.Commands
{
    public class CreateTournamentCommand : ICreateTournamentCommand
    {
        private readonly TournamentsDbContextFactory _contextFactory;

        public CreateTournamentCommand(TournamentsDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public  async Task Execute(Tournament tournament)
        {
            using (TournamentsDbContext context = _contextFactory.Create())
            {                
                TournamentDto tournamentDto = new TournamentDto()
                {
                    Id = tournament.Id,
                    Organisation = tournament.Organisation,
                    TournamentName = tournament.TournamentName,
                    Competition = tournament.Competition,   
                    StartDate = tournament.StartDate,
                    EndDate = tournament.EndDate,
                    Location = tournament.Location,
                    Rounds = tournament.Rounds,
                };

                context.Tournaments.Add(tournamentDto);
                await context.SaveChangesAsync();
            }
        }
    }    
}
