using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpostoDeRenda
{
    public class CalculadorAteSeteSalarios : ICalcula
    {
        private const decimal ImpostoDeduzir = 636.13m;

        public ICalcula ProximaAliquota { get; set; }

        public decimal CalcularQtdSalarios(decimal valorRenda, int numDepentes, decimal salarioMin) => (valorRenda - (valorRenda * ((numDepentes * 5) / 100m))) / salarioMin;

        public decimal Calcular(decimal valorRenda, int numDependentes, decimal salarioMin)
        {
            decimal vlrRendaLiq = CalcularQtdSalarios(valorRenda, numDependentes,salarioMin);

            if (vlrRendaLiq > 5 && vlrRendaLiq <= 7)
            {
                return (vlrRendaLiq * 0.225m) - ImpostoDeduzir;
            }
            return ProximaAliquota.Calcular(valorRenda, numDependentes, salarioMin);
        }
    }
}
