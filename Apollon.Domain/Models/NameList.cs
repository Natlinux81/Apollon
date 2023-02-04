using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.Domain.Models
{
    public class NameList
    {
        public NameList(Guid id, string firstName, string lastName, int passNumber, string society, int societyNumber, DateTime birthday, string country, int qualification)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PassNumber = passNumber;
            Society = society;
            SocietyNumber = societyNumber;
            Birthday = birthday;
            Country = country;
            Qualification = qualification;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int PassNumber { get; }
        public string Society { get; }
        public int SocietyNumber { get; }
        public DateTime Birthday { get; }
        public string Country { get; }
        public int Qualification { get; }
    }
}
