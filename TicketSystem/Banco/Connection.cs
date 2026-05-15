using Microsoft.Data.SqlClient;

namespace TicketSystem.Banco;

internal class Connection
{
    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TicketSystem;Integrated Security=True;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
    
    public SqlConnection ObterConexao()
    {
        return new SqlConnection(connectionString);
    }
}

