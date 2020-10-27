using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Testing.EntityFrameworkCore
{
    public static class TestingDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TestingDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TestingDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
