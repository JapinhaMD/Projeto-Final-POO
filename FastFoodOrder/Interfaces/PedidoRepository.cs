using FastFoodOrder.Model;
namespace FastFoodOrder.Interfaces;

public interface PedidoRepository
{
    void Adicionar(Pedido pedido);
    void Atualizar(Pedido pedido);
    void Excluir(int id);
    Pedido ObterPorId(int id);
    IEnumerable<Pedido> ListarTodos();
    
}