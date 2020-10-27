using System.Collections.Generic;
using Testing.Roles.Dto;

namespace Testing.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
