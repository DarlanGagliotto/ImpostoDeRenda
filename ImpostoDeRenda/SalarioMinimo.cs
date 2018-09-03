using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpostoDeRenda
{
    public class SalarioMinimo
    {
        public decimal ValorAtual { get; set; }

        public SalarioMinimo(decimal valor)
        {
            this.ValorAtual = valor;
        }

        public decimal InformarSalarioMinimo()
        {
            return ValorAtual;
        }

    }
}
