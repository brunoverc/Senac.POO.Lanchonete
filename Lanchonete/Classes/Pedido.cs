using Lanchonete.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete.Classes
{
    public class Pedido : IPedido
    {
        public Pedido(string nomeCliente, decimal taxaServico)
        {
            NomeCliente = nomeCliente;
            TaxaServico = taxaServico;

            //Inicializo ele aqui no construtor para evitar erros ao tentar adicionar
            ItensConsumo = new List<ItemConsumo>();

            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string NomeCliente { get; private set; }
        public decimal TaxaServico { get; private set; }
        public IList<ItemConsumo> ItensConsumo { get; private set; }

        public void GetNomeCliente(string nomeCliente)
        {
            NomeCliente = nomeCliente;
        }

        public void SetItemConsumo(ItemConsumo item)
        {
            ItensConsumo.Add(item);
        }

        public void CalcularTaxaDeServico()
        {
            var somaItens = GetValorFinal();
            var taxaServico = somaItens * 0.1m;
            TaxaServico = taxaServico;
        }

        public decimal CalcularTroco(decimal valorRecebido)
        {
            CalcularTaxaDeServico();
            var valorTotal = GetValorFinal() + TaxaServico;
            decimal troco = valorRecebido - valorTotal;

            return troco;
        }

        public string ImprimirNotaFiscal()
        {
            StringBuilder notaFiscal = new StringBuilder();
            notaFiscal.AppendLine("-----Nota Fiscal-----");
            notaFiscal.AppendLine("Itens Consumidos");

            var valorFinal = GetValorFinal();
            foreach (ItemConsumo item in ItensConsumo)
            {
                notaFiscal.AppendLine(item.Nome + " | Peso: " + item.Peso + " | Valor: R$ " +
                    item.GetPrecoItem());
            }

            notaFiscal.AppendLine("Valor total a pagar: R$ " + valorFinal);
            notaFiscal.AppendLine("A taxa de serviço é: R$ " + TaxaServico);
            notaFiscal.AppendLine("Valor final: R$ " + (valorFinal + TaxaServico));
            notaFiscal.AppendLine("---------------------------");

            return notaFiscal.ToString();
        }

        private decimal GetValorFinal()
        {
            return ItensConsumo.Sum(ic => ic.PrecoPorKg * ic.Peso);
        }

        public override string ToString()
        {
            return $"Pedido | Nome do cliente: {NomeCliente}, taxa de serviço: {TaxaServico}, " +
                $"itens consumidos: {ItensConsumo}";
        }
    }
}
