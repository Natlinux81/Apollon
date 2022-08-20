using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.EntityFramework
{
    public class TournamentsDesignTimeDbContextFactory : IDesignTimeDbContextFactory<TournamentsDbContext>
    {      
        
        public TournamentsDbContext CreateDbContext(string[] args = null)
        {         
            return new TournamentsDbContext(new DbContextOptionsBuilder().UseSqlServer("Data Source=NATHALIE-PC\\NATLINUXDB;Database=Apollon;Trusted_Connection=True;MultipleActiveResultSets=true").Options);
        }
    }
}
