using TicketSystem.Services;
using TicketSystem.Enums;

class Program
{
    static void Main(string[] args)
    {
        ChamadoService chamadoService = new ChamadoService();
        bool executando = true;

        Console.WriteLine(@"
░▀█▀░▀█▀░█▀▀░█░█░█▀▀░▀█▀░░░█▀▀░█░█░█▀▀░▀█▀░█▀▀░█▄█
░░█░░░█░░█░░░█▀▄░█▀▀░░█░░░░▀▀█░░█░░▀▀█░░█░░█▀▀░█░█
░░▀░░▀▀▀░▀▀▀░▀░▀░▀▀▀░░▀░░░░▀▀▀░░▀░░▀▀▀░░▀░░▀▀▀░▀░▀");

        Console.WriteLine("\nBem-vindo ao sistema de gerenciamento de chamados!");

        while (executando)
        {
            chamadoService.ExibirMenu();
            Console.Write("\nDigite sua opção: ");
            string input = Console.ReadLine();
            int opcao;

            if (!int.TryParse(input, out opcao))
            {
                Console.WriteLine("\nERRO: Digite um número válido!\n");
                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();

                try
                {
                    Console.Clear();
                }
                catch
                {
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                }
                continue;
            }

            Console.WriteLine();

            switch (opcao)
            {
                case 1: 
                    CriarChamado(chamadoService);
                    break;

                case 2: 
                    ListarChamados(chamadoService);
                    break;

                case 3:
                    BuscarChamado(chamadoService);
                    break;

                case 4:
                    AtualizarStatus(chamadoService);
                    break;

                case 0:
                    executando = false;
                    Console.WriteLine("Saindo do sistema...");
                    Console.WriteLine("Obrigado por usar o Sistema de Chamados. Até logo!");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.\n");
                    break;
            }

            if (executando)
            {
                Console.WriteLine("\nPressione Enter para voltar ao menu...");
                Console.ReadLine();
                
                try
                {
                    Console.Clear();
                }
                catch
                {
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                }
            }
        }
    }

    static void CriarChamado(ChamadoService service)
    {
        Console.WriteLine("--- CRIAR NOVO CHAMADO ---");
        
        Console.Write("Título do chamado: ");
        string titulo = Console.ReadLine();

        Console.Write("Descrição do problema: ");
        string descricao = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(descricao))
        {
            Console.WriteLine("\nERRO: Título e descrição são obrigatórios!");
            return;
        }

        service.CriarChamado(titulo, descricao);
        Console.WriteLine("\nChamado criado com sucesso!");
    }

    static void ListarChamados(ChamadoService service)
    {
        Console.WriteLine("--- LISTA DE CHAMADOS ---");
        
        if (service.Chamados.Count == 0)
        {
            Console.WriteLine("Nenhum chamado cadastrado no momento.");
            return;
        }

        Console.WriteLine($"Total de chamados: {service.Chamados.Count}\n");
        service.ListarChamados();
    }

    static void BuscarChamado(ChamadoService service)
    {
        Console.WriteLine("--- BUSCAR CHAMADO ---");
        
        Console.Write("Digite o ID do chamado: ");
        string input = Console.ReadLine();
        int id;

        if (!int.TryParse(input, out id))
        {
            Console.WriteLine("\nERRO: Digite um ID válido!");
            return;
        }

        Console.WriteLine();
        service.BuscarChamado(id);
    }

    static void AtualizarStatus(ChamadoService service)
    {
        Console.WriteLine("--- ATUALIZAR STATUS ---");
        
        Console.Write("Digite o ID do chamado: ");
        string idInput = Console.ReadLine();
        int id;

        if (!int.TryParse(idInput, out id))
        {
            Console.WriteLine("\nERRO: Digite um ID válido!");
            return;
        }

        Console.WriteLine("\nNovo status:");
        Console.WriteLine("1 - Aberto");
        Console.WriteLine("2 - Em Andamento");
        Console.WriteLine("3 - Fechado");
        Console.Write("Digite a opção desejada: ");

        string statusInput = Console.ReadLine();
        int statusOpcao;

        if (!int.TryParse(statusInput, out statusOpcao) || statusOpcao < 1 || statusOpcao > 3)
        {
            Console.WriteLine("\nERRO: Opção de status inválida!");
            return;
        }

        Status novoStatus = statusOpcao switch
        {
            1 => Status.Aberto,
            2 => Status.EmAndamento,
            3 => Status.Fechado,
            _ => Status.Aberto
        };

        service.AtualizarStatus(id, novoStatus);
    }
}