namespace Lanchonete.Interfaces
{
    public interface IPedido
    {
        decimal CalcularTroco(decimal valorRecebido);
        void CalcularTaxaDeServico();
        string ImprimirNotaFiscal();
    }
}
