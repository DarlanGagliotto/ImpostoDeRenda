namespace ImpostoDeRenda
{
    public interface ICalcula
    {   
        decimal Calcular(decimal valorRenda, int numDependentes);
        decimal CalcularQtdSalarios(decimal valorRenda, int numDepentes);
        ICalcula ProximaAliquota { get; set; }
    }
}
