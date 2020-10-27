using System.Threading.Tasks;
using Abp.Application.Services;
using Testing.Sessions.Dto;

namespace Testing.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
