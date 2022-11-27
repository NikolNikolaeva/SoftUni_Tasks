
using MilitaryElite.Core;
using MilitaryElite.Core.Interfaces;
using MilitaryElite.Models.IO;
using MilitaryElite.Models.IO.Interfaces;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();

        }
    }
}
