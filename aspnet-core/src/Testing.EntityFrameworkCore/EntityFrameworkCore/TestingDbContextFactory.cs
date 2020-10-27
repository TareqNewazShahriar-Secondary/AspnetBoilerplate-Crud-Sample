using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Testing.Configuration;
using Testing.Web;

namespace Testing.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TestingDbContextFactory : IDesignTimeDbContextFactory<TestingDbContext>
    {
        public TestingDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TestingDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TestingDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TestingConsts.ConnectionStringName));

            return new TestingDbContext(builder.Options);
        }
    }
}
