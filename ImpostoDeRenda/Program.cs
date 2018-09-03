using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ImpostoDeRenda
{
    class Program
    {
        public static ICollection<Contribuinte> contribuintes = new List<Contribuinte>();

        private static decimal salarioMin;

        static void Main(string[] args)
        {
            ReceberValores();
            CalcularValores();
            MostrarValores();
        }

        private static void ReceberValores()
        {
            while (true)
            {
                Console.WriteLine("Informe o CPF do contribuinte");
                var cpf = Console.ReadLine();

                if (cpf.Equals("0"))
                {
                    Console.WriteLine("Informe o valor do salário mínimo");
                    salarioMin = new SalarioMinimo(Convert.ToDecimal(Console.ReadLine())).InformarSalarioMinimo();
                    return;
                }

                Console.WriteLine("Informe o nome do contribuinte");
                var nome = Console.ReadLine();
                Console.WriteLine("Informe o número de dependentes");
                var numDependentes = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Informe a renda bruta mensal");
                var valorRendaBruta = Convert.ToDecimal(Console.ReadLine());

                contribuintes.Add(new Contribuinte
                {
                    Nome = nome,
                    Depententes = numDependentes,
                    RendaMensalBruta = valorRendaBruta,
                    Cpf = cpf
                });
            }
        }

        

        private static void CalcularValores()
        {
            foreach (var item in contribuintes)
            {
                CalculaIR calcIr = new CalculaIR();

                item.ValorIr = calcIr.ExecutarCalculo(item.RendaMensalBruta, item.Depententes);
            }
        }

        private static void MostrarValores()
        {
            foreach (var result in contribuintes.Where(x => x.Cpf != "0").OrderBy(x => x.Nome))
            {
                Console.WriteLine("Contribuinte: " + result.Nome);
                Console.WriteLine("Valor IR: " + result.ValorIr);
            }

            Console.WriteLine("F I M!");
            Console.ReadKey();
        }
    }
}
