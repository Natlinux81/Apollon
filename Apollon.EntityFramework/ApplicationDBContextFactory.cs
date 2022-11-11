using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.EntityFramework
{
    public class ApplicationDBContextFactory
    {        
        private readonly DbContextOptions _options;

        public ApplicationDBContextFactory(DbContextOptions options)
        {            
            _options = options;
        }

        public ApplicationDbContext Create()
        {         
            return new ApplicationDbContext(_options);
        }
    }
}
