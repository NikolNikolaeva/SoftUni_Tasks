using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Interface
{
    public interface ICommando : ISpecialisedSoldier
    {
         IReadOnlyCollection<IMission> Missions { get; }
    }
}
