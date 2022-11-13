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
    public class GetAllNamesQuery : IGetAllNamesQuery
    {
        private readonly ApplicationDBContextFactory _contextFactory;

        public GetAllNamesQuery(ApplicationDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<NameList>> Execute()
        {
            using (ApplicationDbContext context = _contextFactory.Create())
            {
                IEnumerable<NameListDto> nameListDtos = await context.NameList.ToListAsync();

                return nameListDtos.Select(y => new NameList(
                    y.Id,
                    y.FirstName,
                    y.LastName,
                    y.PassNumber,
                    y.Society,
                    y.SocietyNumber,
                    y.Birthday,
                    y.Country,
                    y.Qualification));
            }
        }
    }
}
