
namespace MilitaryElite.Models.Interface
{
    using Enums;
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
