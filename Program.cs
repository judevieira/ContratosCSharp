using System;
using ConsoleApp1.Entities;
using ConsoleApp1.Entities.Enums;
using System.Globalization;
using System.Runtime.CompilerServices;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o nome do departamento: ");
            string nomeDepart = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Entre com os dados do trabalhador: ");

            Console.WriteLine();

            Console.Write("Nome: ");
            string nomeTrabalhador = Console.ReadLine();

            Console.Write("Nivel (Junior/MidLevel/Senior): ");
            WorkerLevel nivel = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Salario base: ");
            double salarioBase = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            Department dept = new Department(nomeDepart);
            Worker func = new Worker(nomeTrabalhador, nivel, salarioBase, dept);

            Console.WriteLine();

            Console.WriteLine("Quantos contratos o funcionario tem? ");
            int nroContratos = int.Parse(Console.ReadLine());

            for (int i = 1; i <= nroContratos; i++)
            {
                Console.Write($"Dados do contrato #{i}: ");
                Console.Write("Data (dd/mm/yyyy): ");
                DateTime data = DateTime.Parse(Console.ReadLine());

                Console.Write("valor por hora trabalhada: ");
                double  valorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("quantidade de horas trabalhadas: ");
                int qtdeHoras = int.Parse(Console.ReadLine());

                HourContract contrato = new HourContract(data, valorHora, qtdeHoras);

                func.AddContract(contrato);

            }

            Console.WriteLine();
            Console.Write("digite mes e ano para calculo (mm/yyyy): ");
            string mesAno = Console.ReadLine();
            int mes = int.Parse(mesAno.Substring(0, 2));
            int ano = int.Parse(mesAno.Substring(3));

            Console.Write("Nome: "+ func.Name);
            Console.Write("Departamento: " + func.Department.Name);
            Console.Write("Renda: " + func.inCome(ano, mes));

        }

    }
}
