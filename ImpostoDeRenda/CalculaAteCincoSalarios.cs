using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpostoDeRenda
{
    public class CalculaAteCincoSalarios : ICalcula
    {
        private const decimal ImpostoDeduzir = 354.80m;

        public ICalcula ProximaAliquota { get; set; }

        public decimal CalcularQtdSalarios(decimal valorRenda, int numDepentes) => (valorRenda - (valorRenda * ((numDepentes * 5) / 100)));

        public decimal Calcular(decimal valorRenda, int numDependentes)
        {
            decimal vlrRendaLiq = CalcularQtdSalarios(valorRenda, numDependentes);

            if (vlrRendaLiq > 4 && vlrRendaLiq <= 5)
            {
                return (vlrRendaLiq * 0.15m) - ImpostoDeduzir;
            }
            return ProximaAliquota.Calcular(valorRenda, numDependentes);
        }
    }
}
