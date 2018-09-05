using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpostoDeRenda
{
    public class CalculadorAteDoisSalarios : ICalcula
    {
        public ICalcula ProximaAliquota { get; set; }

        public decimal CalcularQtdSalarios(decimal valorRenda, int numDepentes, decimal salarioMin) => (valorRenda - (valorRenda * ((numDepentes * 5) / 100m))) / salarioMin;

        public decimal Calcular(decimal valorRenda, int numDependentes, decimal salarioMin)
        {
            decimal vlrRendaLiq = CalcularQtdSalarios(valorRenda, numDependentes, salarioMin);

            if (vlrRendaLiq <= 2)
            {
                return 0;
            }
            return ProximaAliquota.Calcular(valorRenda, numDependentes, salarioMin);
        }
    }
}
