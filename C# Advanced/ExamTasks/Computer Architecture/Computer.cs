using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count { get { return Multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            if (Multiprocessor.Any(x => x.Brand == brand))
            {
                Multiprocessor.RemoveAll(x => x.Brand == brand);
                return true;
            }
            else return false;
        }

        public CPU MostPowerful()
        {
            if (!Multiprocessor.Any())
            {
                return null;
            }

            return Multiprocessor.OrderByDescending(s => s.Frequency).First();
        }

        public CPU GetCPU(string brand)
        {
            return Multiprocessor.FirstOrDefault(r => r.Brand == brand);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {Model}:");

            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
