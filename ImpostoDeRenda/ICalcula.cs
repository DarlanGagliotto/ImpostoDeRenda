namespace ImpostoDeRenda
{
    public interface ICalcula
    {   
        decimal Calcular(decimal valorRenda, int numDependentes, decimal salarioMin);
        decimal CalcularQtdSalarios(decimal valorRenda, int numDepentes, decimal salarioMin);
        ICalcula ProximaAliquota { get; set; }
    }
}
