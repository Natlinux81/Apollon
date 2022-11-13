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
        private readonly ApplicationDBContextFactory _contextFactory;

        public CreateTournamentCommand(ApplicationDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public  async Task Execute(Tournament tournament)
        {     
            using (ApplicationDbContext context = _contextFactory.Create())
            {        
                TournamentDto tournamentDto = new TournamentDto()
                {
                    Id = tournament.Id,
                    Logo = tournament.Logo,
                    Organisation = tournament.Organisation,
                    TournamentName = tournament.TournamentName,
                    Competition = tournament.Competition,  
                    CompetitionImage = tournament.CompetitionImage,
                    StartDate = tournament.StartDate,
                    EndDate = tournament.EndDate,
                    Location = tournament.Location,
                    Rounds = tournament.Rounds,
                    Targets = tournament.Targets,
                };

                context.Tournaments.Add(tournamentDto);
                await context.SaveChangesAsync();
            }
        }
    }    
}
