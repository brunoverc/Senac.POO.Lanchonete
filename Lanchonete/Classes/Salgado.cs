using Lanchonete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete.Classes
{
    public class Salgado : ItemConsumo
    {
        public Salgado(string sabor, 
            string massa, 
            TipoSalgado tipo,
            decimal precoPorKg,
            DateTime dataValidade,
            decimal peso) : base(precoPorKg, dataValidade, peso)
        {
            Sabor = sabor;
            Massa = massa;
            Tipo = tipo;
        }

        public string Sabor { get; private set; }
        public string Massa { get; private set; }
        public TipoSalgado Tipo { get; private set; }

        public void SetSabor(string sabor)
        {
            Sabor = sabor;
        }

        public void SetMassa(string massa)
        {
            Massa = massa;
        }

        public void SetTipo(TipoSalgado tipo)
        {
            Tipo = tipo;
        }
        
    }
}
