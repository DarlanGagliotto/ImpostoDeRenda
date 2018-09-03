using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpostoDeRenda
{
    public class CalculaIR
    {
        public decimal ExecutarCalculo(decimal valorRenda, int numDependentes)
        {
            ICalcula calcular1 =new CalculaAteDoisSalarios();
            ICalcula calcular2 = new CalculaAteQuatroSalarios();
            ICalcula calcular3 = new CalculaAteCincoSalarios();
            ICalcula calcular4 = new CalculaAteSeteSalarios();
            ICalcula calcular5 = new CalculaAcimaSeteSalarios();

            calcular1.ProximaAliquota = calcular2;
            calcular2.ProximaAliquota = calcular3;
            calcular3.ProximaAliquota = calcular4;
            calcular4.ProximaAliquota = calcular5;

            return calcular1.Calcular(valorRenda, numDependentes);
        }
    }
}
