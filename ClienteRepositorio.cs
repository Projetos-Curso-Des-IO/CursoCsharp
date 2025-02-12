using Cadastro;
namespace Repositorio;

public class ClienteRepositorio
{
    public List<Cliente> listaClientes = new List<Cliente>();


    public void ImprimirCliente(Cliente cliente)
    {
        Console.WriteLine("ID........: " + cliente.Id);
        Console.WriteLine("Nome........: " + cliente.Nome);
        Console.WriteLine("Desconto........: " + cliente.Desconto);
        Console.WriteLine("Data de nasc........: " + cliente.DataNascimento);
        Console.WriteLine("Data Cadastro........: " + cliente.CadastradoEm);
        Console.WriteLine("------------------------[ENTER]");
    }

    public void ExibirListaDeClientes()
    {
        Console.Clear();
        try
        {
            if (!File.Exists("clientes.txt"))
            {
                Console.WriteLine("Arquivo inexistente.");
                Console.WriteLine("------------------[ENTER]");
                return;
            }

            if (listaClientes.Count != 0)
            {
                foreach (var clientes in listaClientes)
                {
                    ImprimirCliente(clientes);
                }
            }
            else
            {
                Console.WriteLine("Lista de clientes está vazia...[ENTER]");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro não identificado..." + ex.Message);
            throw;
        }
    }


    public void CadastrarClientes()
    {
        Console.Clear();
        try
        {
            Cliente cliente = new Cliente();
            cliente.Id = listaClientes.Count() + 1;
            cliente.Nome = SolicitarNome();
            cliente.DataNascimento = SolicitarDataNascimento();
            cliente.Desconto = SolicitarDesconto();
            cliente.CadastradoEm = DateTime.Now;

            listaClientes.Add(cliente);

            Console.WriteLine("Cliente cadastrado com sucesso!!");
            GravarDadosClientes();
            ImprimirCliente(cliente);
        }
        catch (Exception exception)
        {
            Console.WriteLine("Erro não identificado..." + exception.Message);
        }


    }


    public void EditarCliente()
    {
        try
        {
            Console.WriteLine("Informe o ID do cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int idPesquisa))
            {
                Console.WriteLine("ID digitado inválido. Por favor informe um ID válido.");
                return;
            }

            Cliente clienteEncontrado = listaClientes.FirstOrDefault(c => c.Id == idPesquisa);
            if (clienteEncontrado == null)
            {
                Console.WriteLine("Cliente não encontado.");
                return;
            }

            clienteEncontrado.Nome = SolicitarNome();
            clienteEncontrado.DataNascimento = SolicitarDataNascimento();
            clienteEncontrado.CadastradoEm = DateTime.Now;
            clienteEncontrado.Desconto = SolicitarDesconto();

            Console.WriteLine("Cliente alterado com sucesso!!");
            ImprimirCliente(clienteEncontrado);
            Console.ReadKey();
        }
        catch (Exception exception)
        {
            Console.WriteLine("Erro não identificado: " + exception.Message);
        }
    }


    public void ExcluirCliente()
    {
        try
        {
            Console.WriteLine("Informe o ID do cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int idPesquisa))
            {
                Console.WriteLine("ID inválido. Por favor digite um valor válido.");
                return;
            }

            if (!listaClientes.Any(c => c.Id == idPesquisa))
            {
                Console.WriteLine("Cliente não encontrados.");
                return;
            }
            listaClientes.RemoveAll(c => c.Id == idPesquisa);
            Console.WriteLine("Cliente removido com sucesso.");
            Console.WriteLine("-------------------[ENTER].");
        }
        catch (Exception exception)
        {
            Console.WriteLine("Erro não identificado: " + exception.Message);
        }
    }


    public void GravarDadosClientes()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(listaClientes);
        File.WriteAllText("clientes.txt", json);
        Console.WriteLine("Dados gravados com sucesso.");
    }


    public void LerDadosClientes()
    {
        if (File.Exists("clientes.txt"))
        {
            var dados = File.ReadAllText("clientes.txt");
            var clientesArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(dados);

            listaClientes.AddRange(clientesArquivo);
        }

    }





    public string SolicitarNome()
    {
        Console.Write("Nome do cliente:");
        return Console.ReadLine();
    }

    public DateOnly SolicitarDataNascimento()
    {
        while (true)
        {
            Console.Write("Data de nascimento (yyyy-MM-dd): ");
            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly dataNascimento))
            {
                return dataNascimento;
            }
            Console.WriteLine("Data inválida. Por favor, insira no formato yyyy-MM-dd.");
        }
    }

    public decimal SolicitarDesconto()
    {
        while (true)
        {
            Console.Write("Desconto:");
            if (decimal.TryParse(Console.ReadLine(), out decimal desconto))
            {
                return desconto;
            }
            Console.WriteLine("Valor inválido. Por favor insira um valor válido.");
        }
    }


}