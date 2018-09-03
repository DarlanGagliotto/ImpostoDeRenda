using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpostoDeRenda
{
    public class CalculaAteSeteSalarios : ICalcula
    {
        private const decimal ImpostoDeduzir = 636.13m;

        public ICalcula ProximaAliquota { get; set; }

        public decimal CalcularQtdSalarios(decimal valorRenda, int numDepentes) => (valorRenda - (valorRenda * ((numDepentes * 5) / 100)));

        public decimal Calcular(decimal valorRenda, int numDependentes)
        {
            decimal vlrRendaLiq = CalcularQtdSalarios(valorRenda, numDependentes);

            if (vlrRendaLiq > 5 && vlrRendaLiq <= 7)
            {
                return (vlrRendaLiq * 0.225m) - ImpostoDeduzir;
            }
            return ProximaAliquota.Calcular(valorRenda, numDependentes);
        }
    }
}
