using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Interface
{
    public interface IEngineer: ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
