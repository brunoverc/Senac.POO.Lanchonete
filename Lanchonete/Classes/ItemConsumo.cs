using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete.Classes
{
    public class ItemConsumo
    {
        public ItemConsumo(decimal precoPorKg, 
            DateTime dataValidade, 
            decimal peso)
        {
            PrecoPorKg = precoPorKg;
            DataValidade = dataValidade;
            Peso = peso;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public decimal PrecoPorKg { get; private set; }
        public DateTime DataValidade { get; private set; }
        public decimal Peso { get; private set; }
        public string Nome { get; private set; }

        public decimal GetPrecoItem()
        {
            return PrecoPorKg * Peso;
        }

        public void SetPrecoPorKg(decimal precoPorKg)
        {
            PrecoPorKg = precoPorKg;
        }

        public void SetDataValidade(DateTime dataValidade)
        {
            DataValidade = dataValidade;
        }

        public void SetPeso(decimal peso)
        {
            Peso = peso;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Item | Nome: {Nome}, Preço: {GetPrecoItem()}, " +
                $"Data de Validade {DataValidade.ToShortDateString()}, Peso: {Peso}";
        }
    }
}
