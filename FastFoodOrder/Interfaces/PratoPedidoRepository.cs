using FastFoodOrder.Model;
namespace FastFoodOrder.Interfaces;


public interface PratoPedidoRepository
{
    void Adicionar(Prato itemPedido);
    void Atualizar(Prato itemPedido);
    void Excluir(int id);
    Prato ObterPorId(int id);
    IEnumerable<Prato> ListarTodos();
}