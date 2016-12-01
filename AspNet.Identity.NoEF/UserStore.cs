using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNet.Identity.NoEF.Data;
using System.Security.Claims;

namespace AspNet.Identity.NoEF
{
    /// <summary>
    /// Class that implements the key ASP.NET Identity user store iterfaces.
    /// </summary>
    public class UserStore : IUserStore<IdentityUser>,
                            IUserClaimStore<IdentityUser>,
                            IUserLoginStore<IdentityUser>,
                            IUserRoleStore<IdentityUser>,
                            IUserPasswordStore<IdentityUser>,
                            IUserEmailStore<IdentityUser>,
                            IUserPhoneNumberStore<IdentityUser>,
        IUserTwoFactorStore<IdentityUser,string>

    {
        private UserHandler UserHandler = new UserHandler();
        private RoleHandler RoleHandler = new RoleHandler();
        private UserRoleHandler UserRoleHandler = new UserRoleHandler();
        private UserClaimHandler UserClaimHandler = new UserClaimHandler();
        private UserLoginHandler UserLoginHandler = new UserLoginHandler();

        public Task CreateAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User is empty.");
            }

            UserHandler.AddUser(user);

            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(IdentityUser user)
        {
            if (user != null)
            {
                UserHandler.RemoveUser(user);
            }

            return Task.FromResult<Object>(null);
        }

        public Task<IdentityUser> FindByIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("Null or empty argument: userId");
            }

            IdentityUser result = UserHandler.GetUserById(userId);
            if (result != null)
            {
                return Task.FromResult<IdentityUser>(result);
            }

            return Task.FromResult<IdentityUser>(null);
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Null or empty argument: userName");
            }

            IdentityUser result = UserHandler.GetUserByUserName(userName);

            if (result != null)
            {
                return Task.FromResult<IdentityUser>(result);
            }

            return Task.FromResult<IdentityUser>(null);
        }

        public Task UpdateAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            UserHandler.SaveUser(user);

            return Task.FromResult<object>(null);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Task AddClaimAsync(IdentityUser user, System.Security.Claims.Claim claim)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User is empty.");
            }

            if (claim == null)
            {
                throw new ArgumentNullException("Claim is empty.");
            }

            UserClaimHandler.AddClaim(claim, user.Id);

            return Task.FromResult<object>(null);
        }

        public Task<IList<System.Security.Claims.Claim>> GetClaimsAsync(IdentityUser user)
        {
            ClaimsIdentity identity = UserClaimHandler.GetClaimsByUserId(user.Id);

            return Task.FromResult<IList<Claim>>(identity.Claims.ToList());
        }

        public Task RemoveClaimAsync(IdentityUser user, System.Security.Claims.Claim claim)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User is empty.");
            }

            if (claim == null)
            {
                throw new ArgumentNullException("Claim is empty.");
            }

            UserClaimHandler.RemoveClaim(claim, user.Id);

            return Task.FromResult<object>(null);
        }

        public Task AddLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User is empty.");
            }

            if (login == null)
            {
                throw new ArgumentNullException("Login is empty.");
            }

            UserLoginHandler.AddLogin(login, user.Id);

            return Task.FromResult<object>(null);
        }

        public Task<IdentityUser> FindAsync(UserLoginInfo login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("Login is empty.");
            }

            var userId = UserLoginHandler.GetUserIdByLogin(login);
            if (userId != null)
            {
                IdentityUser user = UserHandler.GetUserById(userId);
                if (user != null)
                {
                    return Task.FromResult<IdentityUser>(user);
                }
            }

            return Task.FromResult<IdentityUser>(null);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user)
        {
            List<UserLoginInfo> userLogins = new List<UserLoginInfo>();
            if (user == null)
            {
                throw new ArgumentNullException("User is empty.");
            }

            List<UserLoginInfo> logins = UserLoginHandler.GetLoginByUserId(user.Id);
            if (logins != null)
            {
                return Task.FromResult<IList<UserLoginInfo>>(logins);
            }

            return Task.FromResult<IList<UserLoginInfo>>(null);
        }

        public Task RemoveLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User is empty.");
            }

            if (login == null)
            {
                throw new ArgumentNullException("Login is empty.");
            }

            UserLoginHandler.RemoveLogin(login, user.Id);

            return Task.FromResult<Object>(null);
        }

        public Task AddToRoleAsync(IdentityUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User is empty.");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("Argument cannot be null or empty: roleName.");
            }

            IdentityRole role = RoleHandler.GetRoleByName(roleName);
            if (role != null)
            {
                UserRoleHandler.AddRole(user.Id, role.Id);
            }

            return Task.FromResult<object>(null);
        }

        public Task<IList<string>> GetRolesAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User is empty.");
            }

            List<string> roles = UserRoleHandler.GetRolesByUserId(user.Id);
            {
                if (roles != null)
                {
                    return Task.FromResult<IList<string>>(roles);
                }
            }

            return Task.FromResult<IList<string>>(null);
        }

        public Task<bool> IsInRoleAsync(IdentityUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User is empty.");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("roleName is empty.");
            }

            List<string> roles = UserRoleHandler.GetRolesByUserId(user.Id);
            {
                if (roles != null && roles.Contains(roleName))
                {
                    return Task.FromResult<bool>(true);
                }
            }

            return Task.FromResult<bool>(false);
        }

        public Task RemoveFromRoleAsync(IdentityUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User is empty.");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("Argument cannot be null or empty: roleName.");
            }

            IdentityRole role = RoleHandler.GetRoleByName(roleName);
            if (role != null)
            {
                UserRoleHandler.RemoveRole(user.Id, role.Id);
            }

            return Task.FromResult<object>(null);
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            string passwordHash = UserHandler.GetPasswordHash(user.Id);

            return Task.FromResult<string>(passwordHash);
        }

        public Task<bool> HasPasswordAsync(IdentityUser user)
        {
            var hasPassword = !string.IsNullOrEmpty(UserHandler.GetPasswordHash(user.Id));

            return Task.FromResult<bool>(hasPassword);
        }

        public Task SetPasswordHashAsync(IdentityUser user, String passwordHash)
        {
            user.PasswordHash = passwordHash;

            return Task.FromResult<Object>(null);
        }

        public Task SetEmailAsync(IdentityUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.EmailConfirmed = confirmed;

            return Task.FromResult(0);
        }

        public Task<IdentityUser> FindByEmailAsync(string email)
        {
            return Task.FromResult(null as IdentityUser);
        }

        public Task<string> GetPhoneNumberAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public Task SetPhoneNumberAsync(IdentityUser user, string phoneNumber)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.PhoneNumber = phoneNumber;

            return Task.FromResult(0);
        }

        public Task SetPhoneNumberConfirmedAsync(IdentityUser user, bool confirmed)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.PhoneNumberConfirmed = confirmed;

            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(IdentityUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(IdentityUser user)
        {
            return Task.FromResult(false);
        }

        
    }

}
