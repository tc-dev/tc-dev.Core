using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tc_dev.Core.Identity.Models;

namespace tc_dev.Core.Identity
{
    public interface IAppRoleManager : IDisposable
    {
        Task<AppIdentityResult> CreateAsync(ApplicationRole role);
        AppIdentityResult Create(ApplicationRole role);
        Task<AppIdentityResult> DeleteAsync(int roleId);
        Task<ApplicationRole> FindByIdAsync(int roleId);
        ApplicationRole FindByName(string roleName);
        Task<ApplicationRole> FindByNameAsync(string roleName);
        IEnumerable<ApplicationRole> GetRoles();
        Task<IEnumerable<ApplicationRole>> GetRolesAsync();
        Task<bool> RoleExistsAsync(string roleName);
        Task<AppIdentityResult> UpdateAsync(int roleId, string roleName);
    }
}
