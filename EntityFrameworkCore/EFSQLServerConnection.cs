using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore;

public class EFSQLServerConnection : IEFDBConnection
{
    public EFSQLServerConnection()
    {
    }
    string IEFDBConnection.ConnectionString => "DefaultConnection";

    public DbContextOptionsBuilder UseDatabase(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = ((IEFDBConnection)this).GetConnectionString();
        return optionsBuilder.UseSqlServer(connectionString);
    }
}