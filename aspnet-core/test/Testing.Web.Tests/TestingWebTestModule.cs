using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Testing.EntityFrameworkCore;
using Testing.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Testing.Web.Tests
{
    [DependsOn(
        typeof(TestingWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TestingWebTestModule : AbpModule
    {
        public TestingWebTestModule(TestingEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestingWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TestingWebMvcModule).Assembly);
        }
    }
}