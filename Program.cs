
using Repositorio;

namespace AppClientes;

class Program
{
    static ClienteRepositorio _clienteRepositorio = new ClienteRepositorio();
    static void Main(string[] args)
    {
        while (true)
        {
            Menu();     
            Console.ReadKey();
        }
       
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("=== Menu de Cadastro de Clientes ===");
        Console.WriteLine("1 - Cadastrar Cliente");
        Console.WriteLine("2 - Listar Clientes");
        Console.WriteLine("3 - Editar Clientes");
        Console.WriteLine("4 - Excluir Clientes");
        Console.WriteLine("5 - Sair");
        Console.Write("Escolha uma opção: ");
        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1: _clienteRepositorio.CadastrarClientes();break;
            case 2: _clienteRepositorio.ExibirListaDeClientes();break;
            case 3: _clienteRepositorio.EditarCliente();break;
            case 4: _clienteRepositorio.ExcluirCliente();break;
            case 0: Environment.Exit(0);break;
            
            
            default: Console.WriteLine("Valor inválido. Digite nova opção!");break;
        }
    }
    
   
}
