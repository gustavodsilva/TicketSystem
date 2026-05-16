using Microsoft.Data.SqlClient;
using TicketSystem.Enums;
using TicketSystem.Models;

namespace TicketSystem.Banco;

internal class ChamadosDAL
{
    public IEnumerable<Chamado> Listar()
    {
        var lista = new List<Chamado>();
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = "SELECT IdUnico, Titulo, Descricao, DataCriacao, Status FROM Chamados_v1";
        using SqlCommand command = new SqlCommand(sql, connection);
        using SqlDataReader dataReader = command.ExecuteReader();

        if (!dataReader.HasRows)
        {
            Console.WriteLine($"Consulta executada com sucesso, mas não houve linhas retornadas. Fonte: {connection.DataSource}, Banco: {connection.Database}");
            return lista;
        }

        while (dataReader.Read())
        {
            int id = dataReader["IdUnico"] != DBNull.Value ? Convert.ToInt32(dataReader["IdUnico"]) : 0;
            string titulo = dataReader["Titulo"] != DBNull.Value ? dataReader["Titulo"].ToString()! : string.Empty;
            string descricao = dataReader["Descricao"] != DBNull.Value ? dataReader["Descricao"].ToString()! : string.Empty;

            DateTime dataCriacao;
            if (dataReader["DataCriacao"] != DBNull.Value && DateTime.TryParse(dataReader["DataCriacao"].ToString(), out var dt))
            {
                dataCriacao = dt;
            }
            else
            {
                dataCriacao = DateTime.MinValue;
            }

            Status statusParsed = Status.Aberto;
            if (dataReader["Status"] != DBNull.Value)
            {
                var rawStatus = dataReader["Status"].ToString();
                if (!string.IsNullOrEmpty(rawStatus))
                {
                    if (int.TryParse(rawStatus, out var statusInt) && Enum.IsDefined(typeof(Status), statusInt))
                    {
                        statusParsed = (Status)statusInt;
                    }
                    else if (!Enum.TryParse<Status>(rawStatus, out statusParsed))
                    {
                        statusParsed = Status.Aberto;
                    }
                }
            }

            Chamado chamado = new Chamado(id, titulo, descricao, dataCriacao, statusParsed);
            lista.Add(chamado);
        }

        return lista;
    }

    public void GarantirTabelaChamadosV1()
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = @"IF OBJECT_ID('dbo.Chamados_v1', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Chamados_v1
    (
        IdUnico INT IDENTITY(1,1) PRIMARY KEY,
        Titulo NVARCHAR(255) NOT NULL,
        Descricao NVARCHAR(MAX) NULL,
        DataCriacao DATETIME2 NOT NULL,
        Status INT NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM dbo.Chamados_v1)
BEGIN
    INSERT INTO dbo.Chamados_v1 (Titulo, Descricao, DataCriacao, Status)
    VALUES ('Chamado Exemplo', 'Registro inicial criado automaticamente', GETDATE(), 0);
END";

        using SqlCommand command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();
    }

    public void GarantirColunaDataCriacao()
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = @"IF COL_LENGTH('dbo.Chamados', 'DataCriacao') IS NULL
BEGIN
    ALTER TABLE dbo.Chamados ADD DataCriacao DATETIME2 NULL;
    UPDATE dbo.Chamados SET DataCriacao = GETDATE() WHERE DataCriacao IS NULL;
END";

        using SqlCommand command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();
    }

    public void Adicionar(Chamado chamado)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = "INSERT INTO Chamados_v1 (Titulo, Descricao, DataCriacao, Status) VALUES (@Titulo, @Descricao, @DataCriacao, @Status)";
        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Titulo", chamado.Titulo);
        command.Parameters.AddWithValue("@Descricao", chamado.Descricao ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@DataCriacao", chamado.DataCriacao);
        command.Parameters.AddWithValue("@Status", (int)chamado.Status);

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"{retorno} linha(s) afetada(s).");
    }

    public void AtualizarStatus(int id, Status novoStatus)
    {
        using var connection = new Connection().ObterConexao();
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
        using var connection = new Connection().ObterConexao();
        connection.Open();
        string sql = "DELETE FROM Chamados_v1 WHERE IdUnico = @IdUnico";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@IdUnico", id);
        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"{retorno} linha(s) afetada(s).");
    }
}

