namespace Lanchonete.Classes
{
    public class Pizza : ItemConsumo
    {
        public Pizza(string sabor,
            string borda,
            string molho,
            decimal precoPorKg,
            DateTime dataValidade,
            decimal peso) : base(precoPorKg, dataValidade, peso)
        {
            Sabor = sabor;
            Borda = borda;
            Molho = molho;
        }

        public string Sabor { get; private set; }
        public string Borda { get; private set; }
        public string Molho { get; private set; }

        public void SetSabor(string sabor)
        {
            Sabor = sabor;
        }

        public void SetBorda(string borda)
        {
            Borda = borda;
        }

        public void SetMolho(string molho)
        {
            Molho = molho;
        }
    }
}
