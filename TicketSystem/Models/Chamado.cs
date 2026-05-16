namespace TicketSystem.Models;

internal class Chamado
{
    private string? idChamado;
    private string? status;

    public Chamado() { }

    // Construtor para criar chamado sem fornecer IdUnico (será gerado pelo banco)
    public Chamado(string titulo, string descricao, DateTime dataCriacao, Enums.Status status)
    {
        IdUnico = 0;
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = dataCriacao;
        Status = status;
    }

    public int IdUnico { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public Enums.Status Status { get; set; }

    public Chamado(int idUnico, string titulo, string descricao, DateTime dataCriacao, Enums.Status status)
    {
        IdUnico = idUnico;
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = dataCriacao;
        Status = status;
    }
}
