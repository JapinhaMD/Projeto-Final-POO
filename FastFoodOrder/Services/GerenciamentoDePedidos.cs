using FastFoodOrder.Controller;
using FastFoodOrder.Model;

namespace FastFoodOrder.Services;

using Interfaces;

public class GerenciamentoDePedidos : GerenciamentoDePedidoRepository
{
    private readonly PedidoRepositoryMySql _pr = new PedidoRepositoryMySql();
    private readonly PratoPedidoRepositoryMySQL _ipr = new PratoPedidoRepositoryMySQL();
    public void CriarPedido()
    {
        Console.WriteLine("PREENCHA OS DADOS DO PEDIDO:");
        Console.Write("Data do pedido: ");
        string? dataPedido = Console.ReadLine();

        Console.Write("Cliente: ");
        string? cliente = Console.ReadLine();

        Console.Write("Status: ");
        string? status = Console.ReadLine();
        
        Pedido pedido = new Pedido(dataPedido, cliente, status);

        _pr.Adicionar(pedido);
    }
    public void AdicionarItemPedidos()
    {
        Console.WriteLine("PREENCHA OS DADOS DO ITEM:");
        Console.Write("ID do pedido: ");
        int pedidoId = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Nome do Prato: ");
        string? produto = Console.ReadLine();

        Console.Write("Quantidade: ");
        int quantidade = int.Parse(Console.ReadLine()!);

        Console.Write("Preço unitário: ");
        double precoUnitario = double.Parse(Console.ReadLine()!);

        Prato itemPedido = new Prato(produto, quantidade, precoUnitario, pedidoId);
        
        _ipr.Adicionar(itemPedido);
    }

    public void AtualizarStatus()
    {
        Console.Write("ID do pedido: ");
        int pedidoId = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Status: ");
        string? status = Console.ReadLine();

        _pr.AtualizarStatus(pedidoId, status);
    }

    public void RemoverPedido()
    {   
        Console.Write("ID do pedido: ");
        int pedidoId = Convert.ToInt32(Console.ReadLine());
        
        _pr.Excluir(pedidoId);
    }


    public void ListarPedidos(string filtro)
    {
        IEnumerable<Pedido> pedidos = new List<Pedido>();

        if (filtro == "Cliente")
        {
            Console.Write("Cliente: ");
            string? cliente = Console.ReadLine();

            if (cliente != null) pedidos = _pr.ObterPorNome(cliente);
        }
        else if (filtro == "Status")
        {
            Console.Write("Status: ");
            string? status = Console.ReadLine();

            if (status != null) pedidos = _pr.ObterPorStatus(status);
        }
        else if (filtro == "Data")
        {
            Console.Write("Data do pedido: ");
            string? dataPedido = Console.ReadLine();

            if (dataPedido != null) pedidos = _pr.ObterPorData(dataPedido);
        }
        else
        {
            string? pratos = Console.ReadLine();

            if (pratos != null) pedidos = _pr.ListarTodos();
        }

        foreach (var pedido in pedidos)
        {
            Console.WriteLine(pedido.ToString());

            IEnumerable<Prato> itens = _ipr.ListarTodosPorId(pedido.Id);

            foreach (var item in itens)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public void CalcularValorPedido()
    {
        double sum = 0;
        
        Console.Write("ID do pedido: ");
        int pedidoId = Convert.ToInt32(Console.ReadLine());
        
        IEnumerable<Prato> itens = _ipr.ListarTodosPorId(pedidoId);

        foreach (var item in itens)
        {
            sum += item.Quantidade * item.PrecoUnit;
        }
        
        Console.WriteLine("Valor Total Pedido: " + sum);
    }
}