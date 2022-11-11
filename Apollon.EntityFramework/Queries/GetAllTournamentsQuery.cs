using Apollon.Domain.Models;
using Apollon.Domain.Queries;
using Apollon.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.EntityFramework.Queries
{
    public class GetAllTournamentsQuery : IGetAllTournamentsQuery
    {
        private readonly ApplicationDBContextFactory _contextFactory;

        public GetAllTournamentsQuery(ApplicationDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Tournament>> Execute()
        {       
            using (ApplicationDbContext context = _contextFactory.Create())
            {
                IEnumerable<TournamentDto> tournamentsDtos = await context.Tournaments.ToListAsync();

                return tournamentsDtos.Select(y => new Tournament(
                    y.Id,
                    y.Logo,
                    y.Organisation,
                    y.TournamentName,
                    y.Competition,
                    y.CompetitionImage,
                    y.StartDate,
                    y.EndDate,
                    y.Location,
                    y.Rounds));
            }
        }
    }
}
