using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.EntityFramework
{
    public class TournamentsDBContextFactory
    {        
        private readonly DbContextOptions _options;

        public TournamentsDBContextFactory(DbContextOptions options)
        {            
            _options = options;
        }

        public TournamentsDBContext Create()
        {         
            return new TournamentsDBContext(_options);
        }
    }
}
