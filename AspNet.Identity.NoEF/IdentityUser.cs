using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.NoEF
{
    /// <summary>
    /// Class that implements IUser Interface.
    /// </summary>
    public class IdentityUser : IUser, IApplicationAudit
    {
        /// <summary>
        /// Default constructor 
        /// </summary>
        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
            //TODO : get a solution to set values to audit at time of login.
            Audit = new Audit();
        }

        /// <summary>
        /// Constructor that takes user name as argument
        /// </summary>
        /// <param name="userName"></param>
        public IdentityUser(string userName)
            : this()
        {
            UserName = userName;           
        }

        /// <summary>
        /// User ID
        /// </summary>
        public string Id { get; set; }

        public string AccountUserId { get; set; }

        /// <summary>
        /// User's name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User's password hash
        /// </summary>
        public string PasswordHash { get; set; }


        /// <summary>
        /// User's security stamp
        /// </summary>


        public string ApprovalPasswordHash { get; set; }

        public int AccessFailedCount { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; internal set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; internal set; }

        public long AddressId { get; set; }
        public object IsActive { get; internal set; }
        public object SecurityStamp { get; internal set; }
        public string UserType { get; set; }
        public Audit Audit { get; set; }






        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IdentityUser, Guid> manager, string authenticationType)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

        //    // Add custom user claims here
        //    return userIdentity;
        //}
    }
}
