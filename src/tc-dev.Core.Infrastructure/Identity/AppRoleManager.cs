using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using tc_dev.Core.Common.Utilities;
using tc_dev.Core.Identity;
using tc_dev.Core.Identity.Models;
using tc_dev.Core.Infrastructure.Identity.Models;
using tc_dev.Core.Infrastructure.Identity.Utilities;

namespace tc_dev.Core.Infrastructure.Identity
{
    public class AppRoleManager : IAppRoleManager
    {
        private readonly RoleManager<AppIdentityRole, int> _roleManager;
        private bool _disposed;

        public AppRoleManager(RoleManager<AppIdentityRole, int> roleManager) {
            roleManager.ThrowIfNull("roleManager");

            _roleManager = roleManager;
        }

        public AppIdentityResult Create(AppRole role) {
            role.ThrowIfNull("role");

            var identityRole = IdentityModelFactory.Create(role);
            var identityResult = _roleManager.Create(identityRole);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            // if create succeedes, copy properties from the new IdentityRole to the 
            // passed in AppRole
            if (appIdentityResult.Succeeded)
                role.CopyFrom(identityRole);

            return appIdentityResult;
        }

        public async Task<AppIdentityResult> CreateAsync(AppRole role) {
            role.ThrowIfNull("role");

            var identityRole = IdentityModelFactory.Create(role);
            var identityResult = await _roleManager.CreateAsync(identityRole);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            // if create succeedes, copy properties from the new IdentityRole to the 
            // passed in AppRole
            if (appIdentityResult.Succeeded)
                role.CopyFrom(identityRole);

            return appIdentityResult;
        }

        public AppIdentityResult Delete(int roleId) {
            var identityRole = _roleManager.FindById(roleId);

            if (identityRole == null)
                return CreateErrorResult(new[] {"Invalid roleId"});

            var identityResult = _roleManager.Delete(identityRole);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AppIdentityResult> DeleteAsync(int roleId) {
            var identityRole = await _roleManager.FindByIdAsync(roleId);

            if (identityRole == null)
                return CreateErrorResult(new[] { "Invalid roleId" });

            var identityResult = await _roleManager.DeleteAsync(identityRole);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public AppRole FindById(int roleId) {
            var identityRole = _roleManager.FindById(roleId);
            var appRole = IdentityModelFactory.Create(identityRole);

            return appRole;
        }

        public async Task<AppRole> FindByIdAsync(int roleId) {
            var identityRole = await _roleManager.FindByIdAsync(roleId);
            var appRole = IdentityModelFactory.Create(identityRole);

            return appRole;
        }

        public AppRole FindByName(string roleName) {
            roleName.ThrowIfNull("roleName");

            var identityRole = _roleManager.FindByName(roleName);
            var appRole = IdentityModelFactory.Create(identityRole);

            return appRole;
        }

        public async Task<AppRole> FindByNameAsync(string roleName) {
            roleName.ThrowIfNull("roleName");

            var identityRole = await _roleManager.FindByNameAsync(roleName);
            var appRole = IdentityModelFactory.Create(identityRole);

            return appRole;
        }

        public IEnumerable<AppRole> GetRoles() {
            var identityRoles = _roleManager.Roles.ToList();
            var appRoles = identityRoles.Select(IdentityModelFactory.Create);

            return appRoles;
        }

        public async Task<IEnumerable<AppRole>> GetRolesAsync() {
            var identityRoles = await _roleManager.Roles.ToListAsync();
            var appRoles = identityRoles.Select(IdentityModelFactory.Create);

            return appRoles;
        }

        public bool RoleExists(string roleName) {
            roleName.ThrowIfNull("roleName");

            return _roleManager.RoleExists(roleName);
        }

        public async Task<bool> RoleExistsAsync(string roleName) {
            roleName.ThrowIfNull("roleName");

            return await _roleManager.RoleExistsAsync(roleName);
        }

        public AppIdentityResult Update(int roleId, string roleName) {
            roleName.ThrowIfNull("roleName");

            var identityRole = _roleManager.FindById(roleId);
            if (identityRole == null)
                return CreateErrorResult(new[] {"Invalid roleId."});

            identityRole.Name = roleName;
            var identityResult = _roleManager.Update(identityRole);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AppIdentityResult> UpdateAsync(int roleId, string roleName) {
            roleName.ThrowIfNull("roleName");

            var identityRole = await _roleManager.FindByIdAsync(roleId);
            if (identityRole == null)
                return CreateErrorResult(new[] { "Invalid roleId." });

            identityRole.Name = roleName;
            var identityResult = await _roleManager.UpdateAsync(identityRole);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        private AppIdentityResult CreateErrorResult(IEnumerable<string> errors) {
            return new AppIdentityResult(errors, false);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing) {
            if (!_disposed && disposing) {
                if (_roleManager != null) {
                    _roleManager.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
