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
    public class CreateNameListCommand : ICreateNameListCommand
    {
        private readonly ApplicationDBContextFactory _contextFactory;

        public CreateNameListCommand(ApplicationDBContextFactory dbContextFactory)
        {
            _contextFactory = dbContextFactory;
        }

        public async Task Execute(NameList nameList)
        {
            using (ApplicationDbContext context = _contextFactory.Create())
            {
                NameListDto nameListDto = new NameListDto()
                {
                    Id = nameList.Id,
                    FirstName = nameList.FirstName,
                    LastName = nameList.Country,
                    PassNumber = nameList.PassNumber,
                    Society = nameList.Society,
                    SocietyNumber = nameList.SocietyNumber,
                    Birthday = nameList.Birthday,
                    Country = nameList.Country,
                };

                context.NameList.Add(nameListDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
