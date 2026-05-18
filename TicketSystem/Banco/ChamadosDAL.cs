using Microsoft.Data.SqlClient;
using TicketSystem.Enums;
using TicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TicketSystem.Banco;

internal class ChamadosDAL
{
    public IEnumerable<Chamado> Listar()
    {
        using var context = new TicketSystemContext();
        try
        {
            var conn = context.Database.GetDbConnection();
            Console.WriteLine($"EF conectado em: {conn.DataSource} | Database: {conn.Database}");

            int count = context.Chamados_v1.Count();
            Console.WriteLine($"Registros encontrados em Chamados_v1: {count}");

            return context.Chamados_v1.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao listar via EF: " + ex.Message);
            return new List<Chamado>();
        }
    }
    
    public void Adicionar(Chamado chamado)
    {
        using var context = new TicketSystemContext();
        context.Chamados_v1.Add(chamado);
        context.SaveChanges();
    }

    /*public void AtualizarStatus(int id, Status novoStatus)
    {
        using var connection = new TicketSystemContext().ObterConexao();
        connection.Open();
        string sql = "UPDATE Chamados_v1 SET Status = @Status WHERE IdUnico = @IdUnico";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Status", (int)novoStatus);
        command.Parameters.AddWithValue("@IdUnico", id);
        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"{retorno} linha(s) afetada(s).");
    }

    public void Deletar(int id)
    {
        using var connection = new TicketSystemContext().ObterConexao();
        connection.Open();
        string sql = "DELETE FROM Chamados_v1 WHERE IdUnico = @IdUnico";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@IdUnico", id);
        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"{retorno} linha(s) afetada(s).");
    }*/
}

