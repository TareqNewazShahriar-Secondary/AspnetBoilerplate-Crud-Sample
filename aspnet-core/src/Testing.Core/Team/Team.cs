using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
