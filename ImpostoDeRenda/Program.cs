using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImpostoDeRenda
{
    class Program
    {
        public static ICollection<Contribuinte> contribuintes = new List<Contribuinte>();

        private static decimal salarioMin;

        #region stringsInforme
        private static string informeNome => "Informe o nome do contribuinte";
        private static string informeNumDependetes => "Informe o número de dependentes";
        private static string informeRendaBruta => "Informe a renda bruta mensal";
        private static string informeSalMin => "Informe o valor do salário mínimo";
        private static string informeCpf => "Informe o CPF do contribuinte";
        #endregion

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
                Console.WriteLine(informeCpf);
                var cpf = Console.ReadLine();

                if (cpf.Equals("0"))
                {
                    Console.WriteLine(informeSalMin);
                    salarioMin = VerificarCaracteres(new SalarioMinimo(Convert.ToDecimal(Console.ReadLine())).InformarSalarioMinimo(),informeSalMin);
                    return;
                }

                Console.WriteLine(informeNome);
                var nome = Console.ReadLine();

                Console.WriteLine(informeNumDependetes);
                var numDependentes = VerificarCaracteres(Console.ReadLine(), informeNumDependetes);

                Console.WriteLine(informeRendaBruta);
                var valorRendaBruta = VerificarCaracteres(Convert.ToDecimal(Console.ReadLine()),informeRendaBruta);

                contribuintes.Add(new Contribuinte
                {
                    Nome = nome,
                    Depententes = Convert.ToInt32(numDependentes),
                    RendaMensalBruta = valorRendaBruta,
                    Cpf = cpf
                });
            }
        }

        private static void CalcularValores()
        {
            foreach (var item in contribuintes)
            {
                CalculadorIR calcIr = new CalculadorIR();
                item.ValorIr = calcIr.ExecutarCalculo(item.RendaMensalBruta, item.Depententes, salarioMin);
            }
        }

        private static void MostrarValores()
        {
            foreach (var result in contribuintes.Where(x => x.Cpf != "0").OrderBy(x => x.ValorIr).ThenBy(x => x.Nome))
            {
                Console.WriteLine("Contribuinte: " + result.Nome);
                Console.WriteLine("Valor IR: " + result.ValorIr.ToString("C", new CultureInfo("pt-BR")));
            }

            Console.WriteLine("F I M!");
            Console.ReadKey();
        }

        private static T VerificarCaracteres<T>(T valor, string msgTela)
        {
            if (Regex.IsMatch(valor.ToString(), @"^[a-zA-Z]"))
            {
                Console.WriteLine("Entrada inválida! Informe somente números");

                Console.WriteLine(msgTela);

               var numDependentes = Console.ReadLine();

                if (numDependentes != null) VerificarCaracteres(valor: numDependentes, msgTela: msgTela);
            }
            return valor;
        }
    }
}
