using Abp.Domain.Entities;

namespace Testing.Teams
{
    public class Team : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TenantId { get; set; }

        public bool IsTransient()
        {
            return false;
        }
    }
}
