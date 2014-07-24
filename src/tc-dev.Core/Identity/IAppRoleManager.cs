using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tc_dev.Core.Identity.Models;

namespace tc_dev.Core.Identity
{
    public interface IAppRoleManager : IDisposable
    {
        AppIdentityResult Create(AppRole role);
        Task<AppIdentityResult> CreateAsync(AppRole role);

        AppIdentityResult Delete(int roleId);
        Task<AppIdentityResult> DeleteAsync(int roleId);

        AppRole FindById(int roleId);
        Task<AppRole> FindByIdAsync(int roleId);

        AppRole FindByName(string roleName);
        Task<AppRole> FindByNameAsync(string roleName);

        IEnumerable<AppRole> GetRoles();
        Task<IEnumerable<AppRole>> GetRolesAsync();

        bool RoleExists(string roleName);
        Task<bool> RoleExistsAsync(string roleName);

        AppIdentityResult Update(int roleId, string roleName);
        Task<AppIdentityResult> UpdateAsync(int roleId, string roleName);
    }
}
