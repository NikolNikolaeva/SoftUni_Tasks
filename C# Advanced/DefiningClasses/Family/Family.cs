using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        public List<Person> Members { get; set; }

        public Family()
        {
           Members = new List<Person>();
        }
        public void AddMember(Person member)
        {
            Members.Add(member);
        }
        public Person GetOldestMember()
        {
            Person oldest = Members.OrderByDescending(x => x.Age).FirstOrDefault();

            return oldest;
        }



    }
}
