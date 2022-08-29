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
    public class DeleteTournamentCommand : IDeleteTournamentCommand
    {
        private readonly TournamentsDbContextFactory _contextFactory;

        public DeleteTournamentCommand(TournamentsDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {            
            using (TournamentsDbContext context = _contextFactory.Create())
            {
                TournamentDto tournamentDto = new TournamentDto()
                {
                    Id = id,                    
                };

                context.Tournaments.Remove(tournamentDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
