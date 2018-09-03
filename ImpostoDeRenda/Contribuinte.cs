using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpostoDeRenda
{
    public class Contribuinte
    {
        public string Nome { get; set; }
        public int Depententes { get; set; }
        public decimal RendaMensalBruta { get; set; }
        public string Cpf { get; set; }
        public decimal ValorIr { get; set; }
    }
}
