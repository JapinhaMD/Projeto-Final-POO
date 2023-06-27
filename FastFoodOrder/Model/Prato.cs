namespace FastFoodOrder.Model;

public class Prato
{
    public int Id { get; set; }
    public string? Produto { get; set; }
    public int Quantidade { get; set; }
    public double PrecoUnit { get; set; }
    public int PedidoId { get; set; }

    public Prato(int id, string? produto, int quantidade, double precoUnit, int pedidoId)
    {
        if (string.IsNullOrWhiteSpace(produto))
        {
            throw new ArgumentException("Nome do Prato não pode ser nulo.");
        }
        if (quantidade <= 0)
        {
            throw new ArgumentException("Quantidade do Prato não pode ser nula.");
        }
        if (precoUnit <= 0)
        {
            throw new ArgumentException("Preço unitário deve ser maior que zero.");
        }
        
        Id = id;
        Produto = produto;
        Quantidade = quantidade;
        PrecoUnit = precoUnit;
        PedidoId = pedidoId;
    }

    public Prato(string? produto, int quantidade, double precoUnit, int pedidoId)
    {
        if (string.IsNullOrWhiteSpace(produto))
        {
            throw new ArgumentException("Nome do Prato não pode nulo.");
        }
        if (quantidade <= 0)
        {
            throw new ArgumentException("Quantidade do Prato deve ser maior que zero.");
        }
        if (precoUnit <= 0)
        {
            throw new ArgumentException("Preço unitário deve ser maior que zero.");
        }
        
        Produto = produto;
        Quantidade = quantidade;
        PrecoUnit = precoUnit;
        PedidoId = pedidoId;
    }


}

