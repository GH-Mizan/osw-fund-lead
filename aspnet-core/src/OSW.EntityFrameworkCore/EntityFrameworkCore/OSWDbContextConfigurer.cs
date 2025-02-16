using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace OSW.EntityFrameworkCore;

public static class OSWDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<OSWDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<OSWDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
