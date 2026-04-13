namespace TicketSystem.Models;

internal class Chamado
{
    public int IdUnico { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public Enums.Status Status { get; set; }
}
