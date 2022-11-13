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
    public class UpdateNameListCommand : IUpdateNameListCommand
    {
        private readonly ApplicationDBContextFactory _ContextFactory;

        public UpdateNameListCommand(ApplicationDBContextFactory contextFactory)
        {
            _ContextFactory = contextFactory;
        }

        public async Task Exexute(NameList nameList)
        {
            using (ApplicationDbContext context = _ContextFactory.Create())
            {
                NameListDto nameListDto = new NameListDto()
                {
                    Id = nameList.Id,
                    FirstName = nameList.FirstName,
                    LastName = nameList.LastName,
                    PassNumber = nameList.PassNumber,
                    Society = nameList.Society,
                    SocietyNumber = nameList.SocietyNumber,
                    Birthday = nameList.Birthday,
                    Country = nameList.Country,
                };
                context.NameList.Update(nameListDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
