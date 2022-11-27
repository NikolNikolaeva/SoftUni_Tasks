using MilitaryElite.Models.Enums;
using MilitaryElite.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName,State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            State = State.Finish;
        }

        public override string ToString()
        {
            return $"  Code Name: {CodeName} Freedom State: {State.ToString()}";
        }
    }
}
