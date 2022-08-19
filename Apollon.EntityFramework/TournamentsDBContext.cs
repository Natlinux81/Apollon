using Apollon.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.EntityFramework
{
    public class TournamentsDBContext : DbContext
    {
        public TournamentsDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TournamentDto> Tournaments { get; set; }
    }
}
