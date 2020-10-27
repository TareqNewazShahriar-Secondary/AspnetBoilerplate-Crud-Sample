using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Testing.Authorization;

namespace Testing
{
    [DependsOn(
        typeof(TestingCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TestingApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TestingAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TestingApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
