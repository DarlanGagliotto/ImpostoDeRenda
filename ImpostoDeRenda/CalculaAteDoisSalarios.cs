using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpostoDeRenda
{
    public class CalculaAteDoisSalarios : ICalcula
    {
        public ICalcula ProximaAliquota { get; set; }

        public decimal CalcularQtdSalarios(decimal valorRenda, int numDepentes) => (valorRenda - (valorRenda * ((numDepentes * 5) / 100)));

        public decimal Calcular(decimal valorRenda, int numDependentes)
        {
            decimal vlrRendaLiq = CalcularQtdSalarios(valorRenda, numDependentes);

            if (vlrRendaLiq <= 2)
            {
                return 0;
            }
            return ProximaAliquota.Calcular(valorRenda, numDependentes);
        }
    }
}
