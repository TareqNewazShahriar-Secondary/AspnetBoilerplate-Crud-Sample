using System.Collections.Generic;
using Testing.Roles.Dto;

namespace Testing.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}