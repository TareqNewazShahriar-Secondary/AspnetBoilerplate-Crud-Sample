using System.Threading.Tasks;
using Abp.Application.Services;
using Testing.Authorization.Accounts.Dto;

namespace Testing.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
