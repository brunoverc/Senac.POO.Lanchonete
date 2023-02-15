namespace Lanchonete.Classes
{
    public class Lanche : ItemConsumo
    {
        public Lanche(string pao,
            string recheio,
            string molho,
            decimal precoPorKg,
            DateTime dataValidade,
            decimal peso) : base(precoPorKg, dataValidade, peso)
        {
            Pao = pao;
            Recheio = recheio;
            Molho = molho;
        }

        public string Pao { get; private set; }
        public string Recheio { get; private set; }
        public string Molho { get; private set; }

        public void SetPao(string pao)
        {
            Pao = pao;
        }

        public void SetRecheio(string recheio)
        {
            Recheio = recheio;
        }

        public void SetMolho(string molho)
        {
            Molho = molho;
        }
    }
}
