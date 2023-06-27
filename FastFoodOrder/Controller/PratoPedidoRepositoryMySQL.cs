using FastFoodOrder.Interfaces;
using FastFoodOrder.Model;
using MySql.Data.MySqlClient;

namespace FastFoodOrder.Controller;

public class PratoPedidoRepositoryMySQL : PratoPedidoRepository
{
    private MySqlConnection _mySqlConnection = new MySqlConnection("Persist Security Info=False;server=localhost;database=fastfoodorder;uid=root;pwd=''");
    private void InicializeDatabase()
    {
        try{
            //abre a conexao
            _mySqlConnection.Open();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    
    public void Adicionar(Prato itemPedido)
    {
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();

        cmd.CommandText =
            "INSERT INTO ITEMPEDIDO(nome, quantidade, preco_unit, pedido_id) VALUES(@nome, @quantidade, @preco_unit, @pedido_id); SELECT LAST_INSERT_ID();";

        cmd.Parameters.AddWithValue("@nome", itemPedido.Produto);
        cmd.Parameters.AddWithValue("@quantidade", itemPedido.Quantidade);
        cmd.Parameters.AddWithValue("@preco_unit", itemPedido.PrecoUnit);
        cmd.Parameters.AddWithValue("@pedido_id", itemPedido.PedidoId);

        cmd.Connection = _mySqlConnection;

        itemPedido.Id = Convert.ToInt32(cmd.ExecuteScalar());
        //cmd.ExecuteReader();
        _mySqlConnection.Close();
    }

    public void Atualizar(Prato itemPedido)
    {
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();

        cmd.CommandText = "UPDATE SET nome = @nome, quantidade = @quantidade, preco_unit = @preco_unit, pedido_id = @pedido_id WHERE id = @id";

        cmd.Parameters.AddWithValue("@nome", itemPedido.Produto);
        cmd.Parameters.AddWithValue("@quantidade", itemPedido.Quantidade);
        cmd.Parameters.AddWithValue("@preco_unit", itemPedido.PrecoUnit);
        cmd.Parameters.AddWithValue("@pedido_id", itemPedido.PedidoId);
        cmd.Parameters.AddWithValue("@id", itemPedido.Id);

        cmd.Connection = _mySqlConnection;
        cmd.ExecuteReader();
        _mySqlConnection.Close();
    }

    public void Excluir(int id)
    {
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();

        cmd.CommandText = "DELETE * FROM ItemPedido WHERE id = @id";

        cmd.Parameters.AddWithValue("@id", id);

        cmd.Connection = _mySqlConnection;
        cmd.ExecuteReader();
        _mySqlConnection.Close();
    }

    public Prato ObterPorId(int id)
    {
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();

        cmd.CommandText = "SELECT * FROM pedido WHERE id = @id";

        cmd.Connection = _mySqlConnection;
        cmd.Parameters.AddWithValue("@id", id);

        var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Prato(Convert.ToInt32(reader["id"]),
                Convert.ToString(reader["nome"]),
                Convert.ToInt32(reader["quantidade"]),
                Convert.ToDouble(reader["preco_unit"]),
                Convert.ToInt32(reader["pedido_id"])
            );
        }
        
        _mySqlConnection.Close();
        return null!;
    }

    public IEnumerable<Prato> ListarTodos()
    {
        List<Prato> itemPedidos = new List<Prato>();

        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();

        cmd.CommandText = "SELECT * FROM ItemPedido";

        cmd.Connection = _mySqlConnection;
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Prato itemPedido = new Prato(Convert.ToInt32(reader["id"]),
                Convert.ToString(reader["nome"]),
                Convert.ToInt32(reader["quantidade"]),
                Convert.ToDouble(reader["preco_unit"]),
                Convert.ToInt32(reader["pedido_id"])
            );

            itemPedidos.Add(itemPedido);
        }
        
        _mySqlConnection.Close();
        return itemPedidos;
    }
    
    public IEnumerable<Prato> ListarTodosPorId(int pedidoId)
    {
        List<Prato> itemPedidos = new List<Prato>();

        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();

        cmd.CommandText = "SELECT * FROM ItemPedido WHERE pedido_id = @pedido_id";

        cmd.Connection = _mySqlConnection;
        cmd.Parameters.AddWithValue("@pedido_id", pedidoId);
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Prato itemPedido = new Prato(Convert.ToInt32(reader["id"]),
                Convert.ToString(reader["nome"]),
                Convert.ToInt32(reader["quantidade"]),
                Convert.ToDouble(reader["preco_unit"]),
                Convert.ToInt32(reader["pedido_id"])
            );

            itemPedidos.Add(itemPedido);
        }
        
        _mySqlConnection.Close();
        return itemPedidos;
    }
}
