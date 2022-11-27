using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Interface
{
    public interface ISoldier
    {
        int Id { get; }

        string FirstName { get; }

        string LastName { get; }

    }
}
