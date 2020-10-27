using System.Collections.Generic;
using Testing.Roles.Dto;

namespace Testing.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
