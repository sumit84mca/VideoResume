using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNet.Identity.NoEF.Data;

namespace AspNet.Identity.NoEF
{
    /// <summary>
    /// Class that implements the key ASP.NET Identity role store iterfaces.
    /// </summary>
    public class RoleStore: IRoleStore<IdentityRole>
    {

        private RoleHandler handler = new RoleHandler();

        public Task CreateAsync(IdentityRole role)
        {
            if (role == null) 
            {
                throw new ArgumentNullException("Role is empty.");
            }

            handler.AddRole(role);

            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(IdentityRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("user");
            }

            handler.RemoveRole(role.Id);

            return Task.FromResult<Object>(null);
        }

        public Task<IdentityRole> FindByIdAsync(String roleId)
        {
            IdentityRole result = handler.GetRoleById(roleId);

            return Task.FromResult<IdentityRole>(result);
        }

        public Task<IdentityRole> FindByNameAsync(String roleName)
        {
            IdentityRole result = handler.GetRoleByName(roleName);

            return Task.FromResult<IdentityRole>(result);
        }

        public Task UpdateAsync(IdentityRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("Role is empty.");
            }

            handler.SaveRole(role);

            return Task.FromResult<Object>(null);
        }

        public void Dispose()
        {
            
        }
    }
}
