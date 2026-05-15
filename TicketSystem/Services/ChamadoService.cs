using System.ComponentModel;
using TicketSystem.Models;

namespace TicketSystem.Services;

internal class ChamadoService
{
    public List<Chamado> Chamados { get; set; }
    public ChamadoService()
    {
        Chamados = new List<Chamado>();
    }
    public void CriarChamado(string titulo, string descricao)
    {
        var chamado = new Chamado
        {
            IdUnico = Chamados.Count + 1,
            Titulo = titulo,
            Descricao = descricao,
            DataCriacao = DateTime.Now,
            Status = Enums.Status.Aberto
        };
        Chamados.Add(chamado);
    }
    public void ListarChamados()
    {
        foreach (var chamado in Chamados)
        {
            Console.WriteLine($"ID: {chamado.IdUnico} | Título: {chamado.Titulo} | Status: {chamado.Status}");
        }
    }
    public void BuscarChamado(int id)
    {
        var chamado = Chamados.FirstOrDefault(c => c.IdUnico == id);
        if (chamado != null)
        {
            Console.WriteLine($"ID: {chamado.IdUnico}\nTítulo: {chamado.Titulo}\nDescrição: {chamado.Descricao}\nData de Criação: {chamado.DataCriacao}\nStatus: {chamado.Status}");
        }
        else
        {
            Console.WriteLine("Chamado não encontrado.");
        }
    }
    public void AtualizarStatus(int id, Enums.Status novoStatus)
    {
        var chamado = Chamados.FirstOrDefault(c => c.IdUnico == id);
        if (chamado != null)
        {
            chamado.Status = novoStatus;
            Console.WriteLine("Status atualizado com sucesso.");
        }
        else
        {
            Console.WriteLine("Chamado não encontrado.");
        }
    }
    
    public void ExibirMenu()
    {
        Console.WriteLine("1 - Criar chamado");
        Console.WriteLine("2 - Listar chamados");
        Console.WriteLine("3 - Buscar chamados");
        Console.WriteLine("4 - Atualizar status");
        Console.WriteLine("0 - Sair do sistema");
    }
}
