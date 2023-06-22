using Gamification03.Services;

namespace Gamification03;

public static class Program
{
    public static void Main()
        {
            GerenciamentoDePedidos gerenciamento = new GerenciamentoDePedidos();
            
            int sair = 0;

            while (sair != 1)
            {
                switch (Menu())
                {
                    case 1:
                        gerenciamento.CriarPedido();
                        break;
                    case 2:
                        gerenciamento.AdicionarItemPedidos();
                        break;
                    case 3:
                        gerenciamento.AtualizarStatus();
                        break;
                    case 4:
                        gerenciamento.RemoverPedido();
                        break;
                    case 5:
                        switch (MenuBusca())
                        {
                            case 1:
                                gerenciamento.ListarPedidos("Cliente");
                                break;
                            case 2:
                                gerenciamento.ListarPedidos("Data");
                                break;
                            case 3:
                                gerenciamento.ListarPedidos("Status");
                                break;
                        }
                        break;
                    case 6:
                        gerenciamento.CalcularValorPedido();
                        break;
                    default:
                        sair = 1;
                        break;
                }
            }
        }

        public static int Menu()
        {
            Console.WriteLine("-=: Digite a opção desejada :=-");
            Console.WriteLine("1 - Adicionar novo pedido");
            Console.WriteLine("2 - Adicionar itens a um pedido");
            Console.WriteLine("3 - Atualizar status pedido");
            Console.WriteLine("4 - Remover pedido");
            Console.WriteLine("5 - Listar pedido com filtro");
            Console.WriteLine("6 - Calcular valor de pedido");
            Console.WriteLine("0 - Sair");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int MenuBusca()
        {
            Console.WriteLine("-=: Digite a opção desejada :=-");
            Console.WriteLine("1 - Buscar por cliente");
            Console.WriteLine("2 - Buscar por data");
            Console.WriteLine("3 - Buscar por status");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
