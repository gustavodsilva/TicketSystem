using System.ComponentModel.Design;

Console.WriteLine("Bem-vindo ao sistema de chamados!");
Console.WriteLine("Selecione uma opção:\n");
Console.WriteLine("1 - Criar chamado");
Console.WriteLine("2 - Listar chamados");
Console.WriteLine("3 - Buscar chamados");
Console.WriteLine("4 - Atualizar status");
Console.WriteLine("0 - Sair do sistema");

int Menu = int.Parse(Console.ReadLine());


switch (Menu)
{
    case 1:
        Console.Clear();
        Console.WriteLine("Título: ");
        Console.ReadLine();
        Console.WriteLine("\nDescreva seu problema:");
        Console.ReadLine();
        break;
    case 2:
        Console.WriteLine("Aqui está sua lista de chamdos: ");
        break;
    case 3:
        Console.WriteLine("Qual o número do ticket?");
        int ChamadoId = int.Parse(Console.ReadLine());
        break;
    case 4:
        Console.WriteLine("Qual chamado você quer atualizar status?");
        int StatusId = int.Parse(Console.ReadLine());
        break;
    case 0:
        Console.WriteLine("Saindo do sistema, até logo!");
        break;
    default:
        Console.WriteLine("Opção inválida, tente novamente.");
        break;
}


