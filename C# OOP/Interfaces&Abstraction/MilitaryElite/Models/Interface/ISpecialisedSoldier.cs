
namespace MilitaryElite.Models.Interface
{
    using MilitaryElite.Models.Enums;
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
