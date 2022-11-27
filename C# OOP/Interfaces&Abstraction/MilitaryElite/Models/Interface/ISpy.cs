using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Interface
{
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
