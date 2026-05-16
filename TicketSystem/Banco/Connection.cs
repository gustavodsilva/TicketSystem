using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TicketSystem.Models;
using TicketSystem.Enums;

namespace TicketSystem.Banco
{
    internal class Connection
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TicketSystem;Integrated Security=True;";

        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }

    }
}

