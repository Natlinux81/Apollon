using Apollon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.Domain.Queries
{
    public interface IGetAllTournamentsQuery
    {
        Task<IEnumerable<Tournament>> Execute();        
    }
}
