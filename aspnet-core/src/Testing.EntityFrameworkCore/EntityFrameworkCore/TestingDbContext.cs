using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Testing.Authorization.Roles;
using Testing.Authorization.Users;
using Testing.MultiTenancy;
using Testing.Teams;

namespace Testing.EntityFrameworkCore
{
    public class TestingDbContext : AbpZeroDbContext<Tenant, Role, User, TestingDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TestingDbContext(DbContextOptions<TestingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
    }
}
