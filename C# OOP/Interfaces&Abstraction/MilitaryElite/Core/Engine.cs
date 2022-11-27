using MilitaryElite.Core.Interfaces;
using MilitaryElite.Models;
using MilitaryElite.Models.Interface;

namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using MilitaryElite.Models.Enums;
    using Models.IO.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<ISoldier> allSoldiers;

        public Engine()
        {
            allSoldiers = new HashSet<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer):this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            this.CreateSoldiers();
            this.PrintSoldiers();
        }

        private void CreateSoldiers()
        {

            string command;

            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ');

                string solfirType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                ISoldier soldier = null;

                if (solfirType == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (solfirType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    ICollection<IPrivate> privates = FindPrivates(cmdArgs);

                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);

                }
                else if (solfirType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corpsText = cmdArgs[5];
                    bool isCorpsValid = Enum.TryParse<Corps>(corpsText, true, out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }
                    ICollection<IRepair> repairs = this.CreateRepairs(cmdArgs);
                    soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                }
                else if (solfirType == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corpsText = cmdArgs[5];
                    bool isCorpsValid = Enum.TryParse<Corps>(corpsText, false, out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICollection<IMission> missions = this.CreateMissions(cmdArgs);
                    soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                }
                else if (solfirType == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                else
                {
                    continue;
                }

                this.allSoldiers.Add(soldier);

            }
        }

        private ICollection<IPrivate> FindPrivates(string[] cmdArgs)
        {
            int[] privatesIds = cmdArgs.Skip(5).Select(int.Parse).ToArray();

            ICollection<IPrivate> privates = new HashSet<IPrivate>();
            foreach (var privateId in privatesIds)
            {
                IPrivate currPrivate = (IPrivate)this.allSoldiers
                    .FirstOrDefault(s => s.Id == privateId);

                privates.Add(currPrivate);
            }

            return privates;
        }

        private ICollection<IRepair> CreateRepairs(string[] cmdArgs)
        {
            ICollection<IRepair> repairs = new HashSet<IRepair>();
            string[] repairsInfo = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < repairsInfo.Length; i+=2)
            {
                string partName = repairsInfo[i];
                int hoursWorked = int.Parse(repairsInfo[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                repairs.Add(repair);
            }

            return repairs;
        }

        private ICollection<IMission> CreateMissions(string[] cmdArgs)
        {
            ICollection<IMission> missions = new HashSet<IMission>();

            string[] missionsInfo = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < missionsInfo.Length; i+=2)
            {
                string codeName = missionsInfo[i];
                string stateText = missionsInfo[i + 1];

                bool isStateValid = Enum.TryParse<State>(stateText, false, out State state);
                if (!isStateValid)
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);
                missions.Add(mission);
            }

            return missions;
        }

        private void PrintSoldiers()
        {
            foreach (var soldier in allSoldiers)
            {
                writer.WriteLine(soldier.ToString());
            }
        }
    }
}
