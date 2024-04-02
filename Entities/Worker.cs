using ConsoleApp1.Entities.Enums;
using System;


namespace ConsoleApp1.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();//instanciar a lista para que não apareça null

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department) //não inclui lista no construtor
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }


        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double inCome(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if(contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }

            return sum;
        }
    }
}
