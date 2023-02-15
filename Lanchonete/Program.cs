
using Lanchonete.Classes;
using Lanchonete.Enums;

List<ItemConsumo> pratosDisponiveis = new List<ItemConsumo>();
List<Pedido> pedidos = new List<Pedido>();

CarregarDados();

while (true)
{
    Console.WriteLine("---Bem vindos ao Senac Lanches---");
    Console.WriteLine("1) Fazer Pedido. 2) Sair");
    var op = Convert.ToInt32(Console.ReadLine());
    switch(op)
    {
        case 1:
            FazerPedido();
            break;
        case 2:
            return;
    }
}

void CarregarDados()
{
    DateTime dataEmTresDias = DateTime.Now.AddDays(3);
    DateTime dataEmQuatroDias = DateTime.Now.AddDays(4);

    Pizza p1 = new Pizza("Bolonhesa", "catupiry", "Normal", 40, dataEmTresDias, 0.6m);
    Pizza p2 = new Pizza("3 Queijos", "calabresa", "Bolonhesa", 40, dataEmTresDias, 0.7m);
    Pizza p3 = new Pizza("Chocolate com morango", "Nenhuma", "Normal", 55, dataEmTresDias, 0.62m);

    Lanche l1 = new Lanche("Brioche", "calabresa", "Catshup mostarda", 70, dataEmQuatroDias, 0.3m);
    Lanche l2 = new Lanche("Francês", "Ovos e bacon", "Catupiry", 60, dataEmQuatroDias, 0.4m);
    Lanche l3 = new Lanche("Hamburguer", "Frango catupiry", "Requeijão", 70, dataEmQuatroDias, 0.37m);

    Salgado s1 = new Salgado("Frango", "Batata", TipoSalgado.Frito, 55, dataEmQuatroDias, 0.4m);
    Salgado s2 = new Salgado("Calabresa", "Mandioca", TipoSalgado.Frito, 60, dataEmQuatroDias, 0.3m);
    Salgado s3 = new Salgado("Carne moída", "Batata", TipoSalgado.Assado, 78, dataEmQuatroDias, 0.46m);


    pratosDisponiveis.Add(p1);
    pratosDisponiveis.Add(p2);
    pratosDisponiveis.Add(p3);

    pratosDisponiveis.Add(l1);
    pratosDisponiveis.Add(l2);
    pratosDisponiveis.Add(l3);

    pratosDisponiveis.Add(s1);
    pratosDisponiveis.Add(s2);
    pratosDisponiveis.Add(s3);
}

void FazerPedido()
{
    Console.WriteLine("Nome do cliente: ");
    string nomeCliente = Console.ReadLine();

    Pedido p = new Pedido(nomeCliente);
    string continuar = "S";

    int contador = 1;
    foreach (var prato in pratosDisponiveis)
    {
        Console.WriteLine($"Digite: {contador} para: {prato.Nome.ToString()}");
        contador++;
    }
    Console.WriteLine("Digite 0 para finalizar o pedido.");

    while (continuar == "S")
    {
        int numItem = Convert.ToInt32(Console.ReadLine());

        if (numItem != 0)
        {
            p.ItensConsumo.Add(pratosDisponiveis[numItem - 1]);
            Console.WriteLine($"Item: {pratosDisponiveis[numItem - 1].Nome} adicionado com sucesso!");
            Console.WriteLine("Digite o número de mais um item ou 0 para sair");
        }
        else
        {
            continuar = "N";
        }
    }

    Console.WriteLine(p.ImprimirNotaFiscal());
    Console.WriteLine("Digite o valor recebido:");
    decimal valorRecebido = Convert.ToDecimal(Console.ReadLine());
    decimal valorTroco = p.CalcularTroco(valorRecebido);

    Console.Write("Troco: R$ " + Math.Round(valorTroco, 2));
}
