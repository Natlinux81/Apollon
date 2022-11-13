using Apollon.Domain.Commands;
using Apollon.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.EntityFramework.Commands
{
    public class DeleteNameListCommand : IDeleteNameListCommand
    {
        private readonly ApplicationDBContextFactory _contextFactory;

        public DeleteNameListCommand(ApplicationDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (ApplicationDbContext context = _contextFactory.Create())
            {
                NameListDto nameListDto = new NameListDto()
                {
                    Id = id,
                };

                context.NameList.Remove(nameListDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
