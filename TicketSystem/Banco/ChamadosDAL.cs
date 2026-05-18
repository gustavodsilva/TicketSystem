using Microsoft.Data.SqlClient;
using TicketSystem.Enums;
using TicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TicketSystem.Banco;

internal class ChamadosDAL
{
    private readonly TicketSystemContext context;

    public ChamadosDAL(TicketSystemContext context)
    {
        this.context = context;
    }

    public IEnumerable<Chamado> Listar()
    {
        return context.Chamados_v1.ToList();
    }
    
    public void Adicionar(Chamado chamado)
    {
        context.Chamados_v1.Add(chamado);
        context.SaveChanges();
    }

    public void AtualizarStatus(int id, Status novoStatus)
    {
        context.Chamados_v1.Update(new Chamado { IdUnico = id, Status = novoStatus });
        context.SaveChanges();
    }

    public void Deletar(int id)
     {
        context.Chamados_v1.Remove(new Chamado { IdUnico = id });
        context.SaveChanges();
     }
}

