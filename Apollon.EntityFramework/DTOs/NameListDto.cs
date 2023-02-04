using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.EntityFramework.DTOs
{
    public class NameListDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PassNumber { get; set; }
        public string Society { get; set; }
        public int SocietyNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
        public int Qualification { get; set; }
    }
}
