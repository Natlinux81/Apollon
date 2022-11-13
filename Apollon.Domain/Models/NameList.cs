using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.Domain.Models
{
    public class NameList
    {
        public NameList(Guid id,string firstName, string lastName, int passNumber, string society, int societyNumber, string birthday, string country)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PassNumber = passNumber;
            Society = society;
            SocietyNumber = societyNumber;
            Birthday = birthday;
            Country = country;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int PassNumber { get; }
        public string Society { get;  }
        public int SocietyNumber { get;  }
        public string Birthday { get;  }
        public string Country { get;  }
     }
}
