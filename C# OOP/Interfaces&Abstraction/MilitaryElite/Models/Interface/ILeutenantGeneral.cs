
namespace MilitaryElite.Models.Interface
{
    using System.Collections.Generic;
    public interface ILeutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
