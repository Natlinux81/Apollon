using Apollon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.Domain.Commands
{
    public interface IUpdateNameListCommand
    {
       Task Exexute(NameList nameList);
    }
}
