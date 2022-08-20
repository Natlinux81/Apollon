using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.EntityFramework
{
    public class TournamentsDbContextFactory
    {        
        private readonly DbContextOptions _options;

        public TournamentsDbContextFactory(DbContextOptions options)
        {            
            _options = options;
        }

        public TournamentsDbContext Create()
        {         
            return new TournamentsDbContext(_options);
        }
    }
}
