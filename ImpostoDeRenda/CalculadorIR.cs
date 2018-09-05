using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpostoDeRenda
{
    public class CalculadorIR
    {
        public decimal ExecutarCalculo(decimal valorRenda, int numDependentes, decimal salarioMin)
        {
            ICalcula calcular1 =new CalculadorAteDoisSalarios();
            ICalcula calcular2 = new CalculadorAteQuatroSalarios();
            ICalcula calcular3 = new CalculadorAteCincoSalarios();
            ICalcula calcular4 = new CalculadorAteSeteSalarios();
            ICalcula calcular5 = new CalculadorAcimaSeteSalarios();

            calcular1.ProximaAliquota = calcular2;
            calcular2.ProximaAliquota = calcular3;
            calcular3.ProximaAliquota = calcular4;
            calcular4.ProximaAliquota = calcular5;

            return calcular1.Calcular(valorRenda, numDependentes, salarioMin);
        }
    }
}
