﻿

namespace MilitaryElite.Models
{
    using Interface;
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return base.ToString() +$" Salary: {Salary:f2}";
        }
    }
}